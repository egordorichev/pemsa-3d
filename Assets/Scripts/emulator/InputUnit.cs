using AOT;
using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace emulator
{
	public class InputUnit : Unit
	{
		private const int ButtonCount = 7;
		private const int PlayerCount = 8;

		private static bool[,] buttonsDown = new bool[ButtonCount, PlayerCount];
		private static bool[,] buttonsPressed = new bool[ButtonCount, PlayerCount];
		private static bool[,] buttonsDownLast = new bool[ButtonCount, PlayerCount];

		private static Vector2 mousePosition;
		private static int mouseButtonsMask;

		private static bool isAnyKeyDown;
		private static string lastKeyDown = "";

		private EmulatorInput input;

		public InputUnit(Emulator emulator) : base(emulator)
		{
			input = new EmulatorInput();

			input.PemsaControls.Left.performed += _ => UpdateButtonDownState(0, 0, true);
			input.PemsaControls.Left.canceled += _ => UpdateButtonDownState(0, 0, false);

			input.PemsaControls.Right.performed += _ => UpdateButtonDownState(1, 0, true);
			input.PemsaControls.Right.canceled += _ => UpdateButtonDownState(1, 0, false);

			input.PemsaControls.Up.performed += _ => UpdateButtonDownState(2, 0, true);
			input.PemsaControls.Up.canceled += _ => UpdateButtonDownState(2, 0, false);

			input.PemsaControls.Down.performed += _ => UpdateButtonDownState(3, 0, true);
			input.PemsaControls.Down.canceled += _ => UpdateButtonDownState(3, 0, false);

			input.PemsaControls.Z.performed += _ => UpdateButtonDownState(4, 0, true);
			input.PemsaControls.Z.canceled += _ => UpdateButtonDownState(4, 0, false);

			input.PemsaControls.X.performed += _ => UpdateButtonDownState(5, 0, true);
			input.PemsaControls.X.canceled += _ => UpdateButtonDownState(5, 0, false);

			input.PemsaControls.Pause.performed += _ => UpdateButtonDownState(6, 0, true);
			input.PemsaControls.Pause.canceled += _ => UpdateButtonDownState(6, 0, false);

			input.PemsaControls.Analog.performed += ctx => {
				buttonsDown[0, 0] = false;
				buttonsDown[1, 0] = false;
				buttonsDown[2, 0] = false;
				buttonsDown[3, 0] = false;

				var dir = ctx.ReadValue<Vector2>();
				if (Math.Abs(dir.x) > 0.5)
                {
					buttonsDown[0, 0] = dir.x < 0;
					buttonsDown[1, 0] = dir.x > 0;
				}

				if (Math.Abs(dir.y) > 0.5)
				{
					buttonsDown[2, 0] = dir.y > 0;
					buttonsDown[3, 0] = dir.y < 0;
				}
			};

			input.PemsaControls.Analog.canceled += ctx => {
				buttonsDown[0, 0] = false;
				buttonsDown[1, 0] = false;
				buttonsDown[2, 0] = false;
				buttonsDown[3, 0] = false;
			};

			Keyboard.current.onTextInput += character =>
			{
				lock(lastKeyDown)
                {
					lastKeyDown = character.ToString();
				}
			};

			input.Enable();
		}

        public override void Update()
		{
			base.Update();

            lock (buttonsPressed)
            {
				buttonsPressed[0, 0] = buttonsDown[0, 0] && !buttonsDownLast[0, 0];
				buttonsPressed[1, 0] = buttonsDown[1, 0] && !buttonsDownLast[1, 0];
				buttonsPressed[2, 0] = buttonsDown[2, 0] && !buttonsDownLast[2, 0];
				buttonsPressed[3, 0] = buttonsDown[3, 0] && !buttonsDownLast[3, 0];
                buttonsPressed[4, 0] = buttonsDown[4, 0] && !buttonsDownLast[4, 0];
                buttonsPressed[5, 0] = buttonsDown[5, 0] && !buttonsDownLast[5, 0];
                buttonsPressed[6, 0] = buttonsDown[6, 0] && !buttonsDownLast[6, 0];
			}

            //isAnyKeyDown = Input.anyKeyDown;


            //mouseButtonsMask = 0;
            //mouseButtonsMask |= Input.GetKey(KeyCode.Mouse0) ? 1 : 0;
            //mouseButtonsMask |= Input.GetKey(KeyCode.Mouse1) ? 2 : 0;
            //mouseButtonsMask |= Input.GetKey(KeyCode.Mouse2) ? 4 : 0;

            // Needs fixes: no rect transform

            /*RectTransform rectTransform = emulator.GetComponent<RectTransform>();
			RectTransformUtility.ScreenPointToLocalPointInRectangle(rectTransform, Input.mousePosition, Camera.main, out mousePosition);

			mousePosition += new Vector2(rectTransform.rect.width / 2, rectTransform.rect.height / 2);
	        mousePosition = new Vector2((mousePosition.x / rectTransform.rect.width) * 128, (mousePosition.y / rectTransform.rect.height) * 128);*/
        }

		public void UpdateButtonDownState(int i, int j, bool v)
        {
			buttonsDownLast[i, j] = buttonsDown[i, j];
			buttonsDown[i, j] = v;
		}

        #region Api
        [MonoPInvokeCallback(typeof(PemsaEmulator.ManagedIsButtonDown))]
		public static bool IsButtonDown(int i, int p)
		{
			lock (buttonsPressed)
			{
				return buttonsDown[i, p];
			}
		}

		[MonoPInvokeCallback(typeof(PemsaEmulator.ManagedIsButtonPressed))]
		public static bool IsButtonPressed(int i, int p)
		{
			lock (buttonsPressed)
			{
				return buttonsPressed[i, p];
			}
		}

		[MonoPInvokeCallback(typeof(PemsaEmulator.ManagedUpdateInput))]
		public static void UpdateInput()
		{

		}

		[MonoPInvokeCallback(typeof(PemsaEmulator.ManagedGetMouseX))]
		public static int GetMouseX()
		{
			return (int)Mathf.Clamp(mousePosition.x, 0, 127);
		}

		[MonoPInvokeCallback(typeof(PemsaEmulator.ManagedGetMouseY))]
		public static int GetMouseY()
		{
			return (int)Mathf.Clamp(mousePosition.y, 0, 127);
		}

		[MonoPInvokeCallback(typeof(PemsaEmulator.ManagedGetMouseMask))]
		public static int GetMouseMask()
		{
			return mouseButtonsMask;
		}

		[MonoPInvokeCallback(typeof(PemsaEmulator.ManagedReadKey))]
		public static string ReadKey()
		{
			lock (lastKeyDown)
			{
				return lastKeyDown;
			}
		}

		[MonoPInvokeCallback(typeof(PemsaEmulator.ManagedHasKey))]
		public static bool HasKey()
		{
			return isAnyKeyDown;
		}

		[MonoPInvokeCallback(typeof(PemsaEmulator.ManagedResetInput))]
		public static void ResetInput()
		{
			lock (buttonsPressed)
			{
				for (int i = 0; i < ButtonCount; ++i)
				{
					for (int j = 0; j < PlayerCount; ++j)
					{
						buttonsDown[i, j] = false;
					}
				}
			}
		}

		[MonoPInvokeCallback(typeof(PemsaEmulator.ManagedGetClipboardText))]
		public static string GetClipboardText()
		{
			return GUIUtility.systemCopyBuffer;
		}
		#endregion
	}
}
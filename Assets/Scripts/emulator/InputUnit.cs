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

		public static Vector2 mousePosition = Vector2.zero;
		private static int mouseButtonsMask;

		private static bool isAnyKeyDown = false;
		private static string lastKeyDown = "";

		private EmulatorInput input;

		public InputUnit(Emulator emulator) : base(emulator)
		{
			input = new EmulatorInput();

			input.PemsaControls.Left.performed += _ => buttonsDown[0, 0] = true;
			input.PemsaControls.Left.canceled += _ => buttonsDown[0, 0] = false;

			input.PemsaControls.Right.performed += _ => buttonsDown[1, 0] = true;
			input.PemsaControls.Right.canceled += _ => buttonsDown[1, 0] = false;

			input.PemsaControls.Up.performed += _ => buttonsDown[2, 0] = true;
			input.PemsaControls.Up.canceled += _ => buttonsDown[2, 0] = false;

			input.PemsaControls.Down.performed += _ => buttonsDown[3, 0] = true;
			input.PemsaControls.Down.canceled += _ => buttonsDown[3, 0] = false;

			input.PemsaControls.Z.performed += _ => buttonsDown[4, 0] = true;
			input.PemsaControls.Z.canceled += _ => buttonsDown[4, 0] = false;

			input.PemsaControls.X.performed += _ => buttonsDown[5, 0] = true;
			input.PemsaControls.X.canceled += _ => buttonsDown[5, 0] = false;

			input.PemsaControls.Pause.performed += _ => buttonsDown[6, 0] = true;
			input.PemsaControls.Pause.canceled += _ => buttonsDown[6, 0] = false;

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

            //isAnyKeyDown = Input.anyKeyDown;

			if (Mouse.current.leftButton.wasPressedThisFrame)
            {
				mouseButtonsMask |= 0b001;
			}
			if (Mouse.current.leftButton.wasReleasedThisFrame)
			{
				mouseButtonsMask &= ~0b001;
			}

			if (Mouse.current.rightButton.wasPressedThisFrame)
			{
				mouseButtonsMask |= 0b010;
			}
			if (Mouse.current.rightButton.wasReleasedThisFrame)
			{
				mouseButtonsMask &= ~0b010;
			}

			if (Mouse.current.middleButton.wasPressedThisFrame)
			{
				mouseButtonsMask |= 0b100;
			}
			if (Mouse.current.middleButton.wasReleasedThisFrame)
			{
				mouseButtonsMask &= ~0b100;
			}

			var ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());

			RaycastHit hit = new RaycastHit();

			if (Physics.Raycast(ray, out hit, int.MaxValue, LayerMask.GetMask("PemsaScreen")))
			{
				var transform = hit.collider.gameObject.transform;
				var colSize = hit.collider.bounds.size;

				mousePosition = hit.point - transform.position + colSize / 2;
				mousePosition.x = 127 * mousePosition.x / colSize.x;
				mousePosition.y = 127 * mousePosition.y / colSize.y;

				mousePosition.y = -(mousePosition.y - 127);
			}

		}

        #region Api
        [MonoPInvokeCallback(typeof(PemsaEmulator.ManagedIsButtonDown))]
		public static bool IsButtonDown(int i, int p)
		{
			lock (buttonsDown)
			{
				return buttonsDown[i, p];
			}
		}

		[MonoPInvokeCallback(typeof(PemsaEmulator.ManagedIsButtonPressed))]
		public static bool IsButtonPressed(int i, int p)
		{
			return false;
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
			lock (buttonsDown)
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
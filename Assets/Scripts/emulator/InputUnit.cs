using AOT;
using UnityEngine;

namespace emulator {
	public class InputUnit : Unit {
		private const int ButtonCount = 7;
		private const int PlayerCount = 8;

		private bool[,] buttonsDown = new bool[ButtonCount, PlayerCount];
		private bool[,] buttonsPressed = new bool[ButtonCount, PlayerCount];

		private Vector2 mousePosition;
		private int mouseButtonsMask;

		private bool isAnyKeyDown;
		private string lastKeyDown = "";

		public InputUnit(Emulator emulator) : base(emulator) {

		}

		public override void Update() {
			base.Update();

			lock (buttonsDown) {
				buttonsDown[0, 0] = Input.GetKey(KeyCode.LeftArrow);
				buttonsDown[1, 0] = Input.GetKey(KeyCode.RightArrow);
				buttonsDown[2, 0] = Input.GetKey(KeyCode.UpArrow);
				buttonsDown[3, 0] = Input.GetKey(KeyCode.DownArrow);
				buttonsDown[4, 0] = Input.GetKey(KeyCode.Z) || Input.GetKey(KeyCode.C);
				buttonsDown[5, 0] = Input.GetKey(KeyCode.X);
				buttonsDown[6, 0] = Input.GetKey(KeyCode.P) || Input.GetKey(KeyCode.Return);
			}

			lock (buttonsPressed) {
				buttonsPressed[0, 0] = Input.GetKeyDown(KeyCode.LeftArrow);
				buttonsPressed[1, 0] = Input.GetKeyDown(KeyCode.RightArrow);
				buttonsPressed[2, 0] = Input.GetKeyDown(KeyCode.UpArrow);
				buttonsPressed[3, 0] = Input.GetKeyDown(KeyCode.DownArrow);
				buttonsPressed[4, 0] = Input.GetKeyDown(KeyCode.Z);
				buttonsPressed[5, 0] = Input.GetKeyDown(KeyCode.X);
				buttonsPressed[6, 0] = Input.GetKeyDown(KeyCode.P);
			}

			lock (lastKeyDown) {
				lastKeyDown = Input.inputString;
			}

			isAnyKeyDown = Input.anyKeyDown;

			mouseButtonsMask = 0;
			mouseButtonsMask |= Input.GetKey(KeyCode.Mouse0) ? 1 : 0;
			mouseButtonsMask |= Input.GetKey(KeyCode.Mouse1) ? 2 : 0;
			mouseButtonsMask |= Input.GetKey(KeyCode.Mouse2) ? 4 : 0;

			// Needs fixes: no rect transform

			/*RectTransform rectTransform = emulator.GetComponent<RectTransform>();
			RectTransformUtility.ScreenPointToLocalPointInRectangle(rectTransform, Input.mousePosition, Camera.main, out mousePosition);

			mousePosition += new Vector2(rectTransform.rect.width / 2, rectTransform.rect.height / 2);
	        mousePosition = new Vector2((mousePosition.x / rectTransform.rect.width) * 128, (mousePosition.y / rectTransform.rect.height) * 128);*/
		}
		
		#region Api
		[MonoPInvokeCallback(typeof(PemsaEmulator.ManagedIsButtonDown))]
		public bool IsButtonDown(int i, int p) {
			lock (buttonsPressed) {
				return buttonsDown[i, p];
			}
		}

		[MonoPInvokeCallback(typeof(PemsaEmulator.ManagedIsButtonPressed))]
		public bool IsButtonPressed(int i, int p) {
			lock (buttonsPressed) {
				return buttonsPressed[i, p];
			}
		}

		[MonoPInvokeCallback(typeof(PemsaEmulator.ManagedUpdateInput))]
		public void UpdateInput() {

		}

		[MonoPInvokeCallback(typeof(PemsaEmulator.ManagedGetMouseX))]
		public int GetMouseX() {
			return (int) Mathf.Clamp(mousePosition.x, 0, 127);
		}

		[MonoPInvokeCallback(typeof(PemsaEmulator.ManagedGetMouseY))]
		public int GetMouseY() {
			return (int) Mathf.Clamp(mousePosition.y, 0, 127);
		}

		[MonoPInvokeCallback(typeof(PemsaEmulator.ManagedGetMouseMask))]
		public int GetMouseMask() {
			return mouseButtonsMask;
		}

		[MonoPInvokeCallback(typeof(PemsaEmulator.ManagedReadKey))]
		public string ReadKey() {
			lock (lastKeyDown) {
				return lastKeyDown;
			}
		}

		[MonoPInvokeCallback(typeof(PemsaEmulator.ManagedHasKey))]
		public bool HasKey() {
			return isAnyKeyDown;
		}

		[MonoPInvokeCallback(typeof(PemsaEmulator.ManagedResetInput))]
		public void ResetInput() {
			lock (buttonsPressed) {
				for (int i = 0; i < ButtonCount; ++i) {
					for (int j = 0; j < PlayerCount; ++j) {
						buttonsDown[i, j] = false;
					}
				}
			}
		}

		[MonoPInvokeCallback(typeof(PemsaEmulator.ManagedGetClipboardText))]
		public string GetClipboardText() {
			return GUIUtility.systemCopyBuffer;
		}
		#endregion
	}
}
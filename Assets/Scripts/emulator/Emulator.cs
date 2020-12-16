using System;
using UnityEngine;

namespace emulator {
	[RequireComponent(typeof(AudioSource))]
	public class Emulator : MonoBehaviour {
		// Public so we can set this in the editor.
		public string CartName = "celeste";

		private Unit[] units = new Unit[3];

		private GraphicsUnit graphicsUnit;
		private InputUnit inputUnit;
		private AudioUnit audioUnit;

		private IntPtr emulatorPointer = IntPtr.Zero;
		public IntPtr EmulatorPointer => emulatorPointer;

		private object emulatorLock = new object();

		public void Start() {
			Console.SetOut(new DebugLogWriter());

			emulatorPointer = PemsaEmulator.AllocateEmulator(
				graphicsUnit.Flip,
				graphicsUnit.CreateSurface,
				graphicsUnit.GetFps,

				inputUnit.IsButtonDown,
				inputUnit.IsButtonPressed,
				inputUnit.UpdateInput,
				inputUnit.GetMouseX,
				inputUnit.GetMouseY,
				inputUnit.GetMouseMask,
				inputUnit.ReadKey,
				inputUnit.HasKey,
				inputUnit.ResetInput,
				inputUnit.GetClipboardText
			);

			units[0] = graphicsUnit = new GraphicsUnit(this);
			units[1] = inputUnit = new InputUnit(this);
			units[2] = audioUnit = new AudioUnit(this);


			PemsaEmulator.LoadCart(emulatorPointer, $"{Application.streamingAssetsPath}/{CartName}.p8");
		}

		public void Update() {
			PemsaEmulator.UpdateEmulator(emulatorPointer, Time.deltaTime);

			foreach (var unit in units) {
				unit.Update();
			}
		}

		public void OnAudioFilterRead(float[] data, int channels) {
			lock (emulatorLock) {
				if (emulatorPointer == IntPtr.Zero) {
					return;
				}

				audioUnit.OnAudioFilterRead(data, channels);
			}
		}

		private void OnApplicationQuit() {
			lock (emulatorLock) {
				PemsaEmulator.FreeEmulator(emulatorPointer);
				emulatorPointer = IntPtr.Zero;
			}
		}
	}
}
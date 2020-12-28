using System;
using System.Runtime.InteropServices;
using AOT;
using UnityEngine;

namespace emulator {
	public class GraphicsUnit : Unit {
		private static Color[] screenColorData = new Color[128 * 128];
		private Texture2D screenTexture;
		private static int fps;

		public GraphicsUnit(Emulator emulator) : base(emulator) {
			Application.targetFrameRate = 60;

			screenTexture = new Texture2D(128, 128, TextureFormat.RGBA32, false, true);
			screenTexture.filterMode = FilterMode.Point;

			var material = emulator.GetComponent<MeshRenderer>().materials[0];

			material.mainTexture = screenTexture;
			material.SetTextureScale("_MainTex", new Vector2(1, -1));
		}

		public override void Update() {
			PemsaEmulator.Render(emulator.EmulatorPointer);

			screenTexture.SetPixels(screenColorData);
			screenTexture.Apply();

			fps = (int) (1f / Time.deltaTime);
		}

		#region Api

		[MonoPInvokeCallback(typeof(PemsaEmulator.ManagedFlip))]
		public static void Render(IntPtr emulatorPtr)
		{

		}

		[MonoPInvokeCallback(typeof(PemsaEmulator.ManagedFlip))]
		public static void Flip(IntPtr emulatorPtr)
		{
			if (emulatorPtr == IntPtr.Zero)
			{
				return;
			}

			var ram = PemsaEmulator.GetRam(emulatorPtr);
			var screenColor = new int[16];

			for (var i = 0; i < 16; i++)
			{
				screenColor[i] = PemsaEmulator.GetScreenColor(emulatorPtr, i);
			}

			for (var i = 0; i < 0x2000; i++)
			{
				var val = Marshal.ReadByte(ram + i + 0x6000);
				var rv = screenColor[val & 0x0f];
				var lv = screenColor[val >> 4];

				screenColorData[i * 2] = Palette.standard[rv];
				screenColorData[i * 2 + 1] = Palette.standard[lv];
			}
		}

		[MonoPInvokeCallback(typeof(PemsaEmulator.ManagedCreateSurface))]
		public static void CreateSurface(IntPtr emulatorPtr)
		{
		}

		[MonoPInvokeCallback(typeof(PemsaEmulator.ManagedGetFps))]
		public static int GetFps(IntPtr emulatorPtr)
		{
			return fps;
		}
		#endregion
	}
}
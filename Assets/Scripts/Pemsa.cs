﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;
using System;
using System.Threading;
using UnityEngine.UI;
using AOT;

[RequireComponent(typeof(AudioSource))]
public class Pemsa : MonoBehaviour {
	private static Color[] screenColorData = new Color[128 * 128];
	static Texture2D screenTexture;
	private static IntPtr emulator;
	private static object emuLock = new object();

	private static int fps;

	private static int PEMSA_BUTTON_COUNT = 7;
	private static int PEMSA_PLAYER_COUNT = 8;

	private static bool[,] buttonDown = new bool[PEMSA_BUTTON_COUNT, PEMSA_PLAYER_COUNT];
	private static bool[,] buttonPressed = new bool[PEMSA_BUTTON_COUNT, PEMSA_PLAYER_COUNT];
	private static float mouseX, mouseY;
	private static int mouseMask = 0;
	private static bool anyKeyDown = false;
	private static string lastKeyDown = "";

	private Vector2 rectTranslation;

	void Start() {
		Application.targetFrameRate = 60;
		screenTexture = new Texture2D(128, 128, TextureFormat.RGBA32, false, true);
		screenTexture.filterMode = FilterMode.Point;

		GetComponent<MeshRenderer>().materials[0].mainTexture = screenTexture;

		AudioConfiguration audioConfig = AudioSettings.GetConfiguration();
		audioConfig.sampleRate = PEMSA_SAMPLE_RATE / 2;
		audioConfig.dspBufferSize = PEMSA_SAMPLE_SIZE;
		AudioSettings.Reset(audioConfig);

		GetComponent<AudioSource>().Play();

		emulator = PemsaEmulator.AllocateEmulator(
			Flip,
			CreateSurface,
			GetFps,
			IsButtonDown,
			IsButtonPressed,
			UpdateInput,
			GetMouseX,
			GetMouseY,
			GetMouseMask,
			ReadKey,
			HasKey,
			ResetInput,
			GetClipboardText
		);

		PemsaEmulator.LoadCart(emulator, Application.streamingAssetsPath + "/celeste.p8");
	}

	void Update() {
		lock (buttonDown) {
			buttonDown[0, 0] = Input.GetKey(KeyCode.LeftArrow);
			buttonDown[1, 0] = Input.GetKey(KeyCode.RightArrow);
			buttonDown[2, 0] = Input.GetKey(KeyCode.UpArrow);
			buttonDown[3, 0] = Input.GetKey(KeyCode.DownArrow);
			buttonDown[4, 0] = Input.GetKey(KeyCode.Z);
			buttonDown[5, 0] = Input.GetKey(KeyCode.X);
			buttonDown[6, 0] = Input.GetKey(KeyCode.P);
		}

		lock (buttonPressed) {
			buttonPressed[0, 0] = Input.GetKeyDown(KeyCode.LeftArrow);
			buttonPressed[1, 0] = Input.GetKeyDown(KeyCode.RightArrow);
			buttonPressed[2, 0] = Input.GetKeyDown(KeyCode.UpArrow);
			buttonPressed[3, 0] = Input.GetKeyDown(KeyCode.DownArrow);
			buttonPressed[4, 0] = Input.GetKeyDown(KeyCode.Z);
			buttonPressed[5, 0] = Input.GetKeyDown(KeyCode.X);
			buttonPressed[6, 0] = Input.GetKeyDown(KeyCode.P);
		}

		lock (lastKeyDown) {
			lastKeyDown = Input.inputString;
		}

		anyKeyDown = Input.anyKeyDown;

		mouseMask = 0;
		mouseMask |= Input.GetKey(KeyCode.Mouse0) ? 1 : 0;
		mouseMask |= Input.GetKey(KeyCode.Mouse1) ? 2 : 0;
		mouseMask |= Input.GetKey(KeyCode.Mouse2) ? 3 : 0;

		/*Vector2 point;
		RectTransform rectTransform = GetComponent<RectTransform>();
		RectTransformUtility.ScreenPointToLocalPointInRectangle(rectTransform, Input.mousePosition, Camera.main, out point);

		mouseX = point.x;
		mouseY = point.y;

		rectTranslation = new Vector2(rectTransform.rect.width / 2, rectTransform.rect.height / 2);
		mouseX += rectTranslation.x;
		mouseY += rectTranslation.y;

		mouseX = (mouseX / rectTransform.rect.width) * 128;
		mouseY = (mouseY / rectTransform.rect.height) * 128;*/

		PemsaEmulator.UpdateEmulator(emulator, Time.deltaTime);

		screenTexture.SetPixels(screenColorData);
		screenTexture.Apply();

		fps = (int) (1f / Time.deltaTime);
	}

	private void OnApplicationQuit() {
		lock (emuLock) {
			PemsaEmulator.FreeEmulator(emulator);
			emulator = IntPtr.Zero;
		}
	}

	#region GRAPHICS
	[MonoPInvokeCallback(typeof(PemsaEmulator.ManagedFlip))]
	static void Flip() {
		if (emulator == IntPtr.Zero) {
			return;
		}

		var ram = PemsaEmulator.GetRam(emulator);
		var screenColor = new int[16];

		for (var i = 0; i < 16; i++) {
			screenColor[i] = PemsaEmulator.GetScreenColor(emulator, i);
		}

		for (var i = 0; i < 0x2000; i++) {
			var val = Marshal.ReadByte(ram + i + 0x6000);
			var rv = screenColor[val & 0x0f];
			var lv = screenColor[val >> 4];

			screenColorData[i * 2] = Palette.standard[rv];
			screenColorData[i * 2 + 1] = Palette.standard[lv];
		}
	}

	[MonoPInvokeCallback(typeof(PemsaEmulator.ManagedCreateSurface))]
	static void CreateSurface() {

	}

	[MonoPInvokeCallback(typeof(PemsaEmulator.ManagedGetFps))]
	static int GetFps() {
		return fps;
	}
	#endregion

	#region INPUT
	[MonoPInvokeCallback(typeof(PemsaEmulator.ManagedIsButtonDown))]
	static bool IsButtonDown(int i, int p) {
		lock (buttonPressed) {
			return buttonDown[i, p];
		}
	}

	[MonoPInvokeCallback(typeof(PemsaEmulator.ManagedIsButtonPressed))]
	static bool IsButtonPressed(int i, int p) {
		lock (buttonPressed) {
			return buttonPressed[i, p];
		}
	}

	[MonoPInvokeCallback(typeof(PemsaEmulator.ManagedUpdateInput))]
	static void UpdateInput() {
	}

	[MonoPInvokeCallback(typeof(PemsaEmulator.ManagedGetMouseX))]
	static int GetMouseX() {
		return (int) mouseX;
	}

	[MonoPInvokeCallback(typeof(PemsaEmulator.ManagedGetMouseY))]
	static int GetMouseY() {
		return (int) mouseY;
	}

	[MonoPInvokeCallback(typeof(PemsaEmulator.ManagedGetMouseMask))]
	static int GetMouseMask() {
		return mouseMask;
	}

	[MonoPInvokeCallback(typeof(PemsaEmulator.ManagedReadKey))]
	static string ReadKey() {
		lock (lastKeyDown) {
			return lastKeyDown;
		}
	}

	[MonoPInvokeCallback(typeof(PemsaEmulator.ManagedHasKey))]
	static bool HasKey() {
		return anyKeyDown;
	}

	[MonoPInvokeCallback(typeof(PemsaEmulator.ManagedResetInput))]
	static void ResetInput() {
		lock (buttonPressed) {
			for (int i = 0; i < PEMSA_BUTTON_COUNT; ++i) {
				for (int j = 0; j < PEMSA_PLAYER_COUNT; ++j) {
					buttonDown[i, j] = false;
				}
			}
		}
	}

	[MonoPInvokeCallback(typeof(PemsaEmulator.ManagedGetClipboardText))]
	static string GetClipboardText() {
		return GUIUtility.systemCopyBuffer;
	}
	#endregion

	#region AUDIO
	private static int PEMSA_SAMPLE_SIZE = 2048;
	private static int PEMSA_SAMPLE_RATE = 44100;

	void OnAudioFilterRead(float[] data, int channels) {
		lock (emuLock) {
			if (emulator == IntPtr.Zero) {
				return;
			}

			var dataLen = data.Length / channels;

			for (int i = 0; i < dataLen; i += 1) {
				for (int j = 0; j < channels; j += 1) {
					data[i * channels + j] = (float) PemsaEmulator.SampleAudio(emulator);
				}
			}
		}
	}
	#endregion
}
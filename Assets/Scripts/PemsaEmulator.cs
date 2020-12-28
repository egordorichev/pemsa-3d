using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;
using System;
using System.Threading;
using UnityEngine.UI;
using AOT;

public static class PemsaEmulator {
	private const string PemsaLibraryName = "pemsa_pinvoke";

	#region Pemsa pinvoke
	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	public delegate void ManagedFlip(IntPtr emulatorPtr);

	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	public delegate void ManagedRender(IntPtr emulatorPtr);

	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	public delegate void ManagedCreateSurface(IntPtr emulatorPtr);

	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	public delegate int ManagedGetFps(IntPtr emulatorPtr);

	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	public delegate bool ManagedIsButtonDown(IntPtr emulatorPtr, int i, int p);

	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	public delegate bool ManagedIsButtonPressed(IntPtr emulatorPtr, int i, int p);

	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	public delegate void ManagedUpdateInput(IntPtr emulatorPtr);

	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	public delegate int ManagedGetMouseX(IntPtr emulatorPtr);

	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	public delegate int ManagedGetMouseY(IntPtr emulatorPtr);

	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	public delegate int ManagedGetMouseMask(IntPtr emulatorPtr);

	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	public delegate string ManagedReadKey(IntPtr emulatorPtr);

	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	public delegate bool ManagedHasKey(IntPtr emulatorPtr);

	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	public delegate void ManagedResetInput(IntPtr emulatorPtr);

	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	public delegate string ManagedGetClipboardText(IntPtr emulatorPtr);

	[DllImport(PemsaLibraryName, CallingConvention = CallingConvention.Cdecl)]
	public static extern IntPtr AllocateEmulator(
		ManagedFlip flip,
		ManagedCreateSurface createSurface,
		ManagedGetFps getFps,
		ManagedRender render,
		ManagedIsButtonDown isButtonDown,
		ManagedIsButtonPressed isButtonPressed,
		ManagedUpdateInput updateInput,
		ManagedGetMouseX getMouseX,
		ManagedGetMouseY getMouseY,
		ManagedGetMouseMask getMouseMask,
		ManagedReadKey readKey,
		ManagedHasKey hasKey,
		ManagedResetInput resetInput,
		ManagedGetClipboardText getClipboardText,
		bool disableSpash
	);

	[DllImport(PemsaLibraryName, CallingConvention = CallingConvention.Cdecl)]
	public static extern void FreeEmulator(IntPtr emulator);

	[DllImport(PemsaLibraryName, CallingConvention = CallingConvention.Cdecl)]
	public static extern void StopEmulator(IntPtr emulator);

	[DllImport(PemsaLibraryName, CallingConvention = CallingConvention.Cdecl)]
	public static extern void ResetEmulator(IntPtr emulator);

	[DllImport(PemsaLibraryName, CallingConvention = CallingConvention.Cdecl)]
	public static extern IntPtr GetRam(IntPtr emulator);

	[DllImport(PemsaLibraryName, CallingConvention = CallingConvention.Cdecl)]
	public static extern Byte GetScreenColor(IntPtr emulator, int i);

	[DllImport(PemsaLibraryName, CallingConvention = CallingConvention.Cdecl)]
	public static extern void UpdateEmulator(IntPtr emulator, double delta);

	[DllImport(PemsaLibraryName, CallingConvention = CallingConvention.Cdecl)]
	public static extern void LoadCart(IntPtr emulator, string cart);

	[DllImport(PemsaLibraryName, CallingConvention = CallingConvention.Cdecl)]
	public static extern void CleanupAndLoadCart(IntPtr emulator, string cart);

	[DllImport(PemsaLibraryName, CallingConvention = CallingConvention.Cdecl)]
	public static extern double SampleAudio(IntPtr emulator);

	[DllImport(PemsaLibraryName, CallingConvention = CallingConvention.Cdecl)]
	public static extern double[] SampleAudioMultiple(IntPtr emulator, double[] outSamples, int nSamples);

	[DllImport(PemsaLibraryName, CallingConvention = CallingConvention.Cdecl)]
	public static extern void Render(IntPtr emulator);
	#endregion
}
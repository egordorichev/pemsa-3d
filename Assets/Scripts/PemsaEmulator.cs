using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;
using System;
using System.Threading;
using UnityEngine.UI;
using AOT;

public static class PemsaEmulator {
	private const string PEMSA_LIBRARY_NAME = "pemsa_pinvoke";

	#region PEMSA_PINVOKE

	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	public delegate void ManagedFlip();

	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	public delegate void ManagedCreateSurface();

	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	public delegate int ManagedGetFps();

	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	public delegate bool ManagedIsButtonDown(int i, int p);

	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	public delegate bool ManagedIsButtonPressed(int i, int p);

	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	public delegate void ManagedUpdateInput();

	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	public delegate int ManagedGetMouseX();

	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	public delegate int ManagedGetMouseY();

	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	public delegate int ManagedGetMouseMask();

	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	public delegate string ManagedReadKey();

	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	public delegate bool ManagedHasKey();

	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	public delegate void ManagedResetInput();

	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	public delegate string ManagedGetClipboardText();

	[DllImport(PEMSA_LIBRARY_NAME, CallingConvention = CallingConvention.Cdecl)]
	public static extern IntPtr AllocateEmulator(
			ManagedFlip flip,
			ManagedCreateSurface createSurface,
			ManagedGetFps getFps,
			ManagedIsButtonDown isButtonDown,
			ManagedIsButtonPressed isButtonPressed,
			ManagedUpdateInput updateInput,
			ManagedGetMouseX getMouseX,
			ManagedGetMouseY getMouseY,
			ManagedGetMouseMask getMouseMask,
			ManagedReadKey readKey,
			ManagedHasKey hasKey,
			ManagedResetInput resetInput,
			ManagedGetClipboardText getClipboardText);

	[DllImport(PEMSA_LIBRARY_NAME, CallingConvention = CallingConvention.Cdecl)]
	public static extern void FreeEmulator(IntPtr emulator);

	[DllImport(PEMSA_LIBRARY_NAME, CallingConvention = CallingConvention.Cdecl)]
	public static extern void StopEmulator(IntPtr emulator);

	[DllImport(PEMSA_LIBRARY_NAME, CallingConvention = CallingConvention.Cdecl)]
	public static extern void ResetEmulator(IntPtr emulator);

	[DllImport(PEMSA_LIBRARY_NAME, CallingConvention = CallingConvention.Cdecl)]
	public static extern IntPtr GetRam(IntPtr emulator);

	[DllImport(PEMSA_LIBRARY_NAME, CallingConvention = CallingConvention.Cdecl)]
	public static extern Byte GetScreenColor(IntPtr emulator, int i);

	[DllImport(PEMSA_LIBRARY_NAME, CallingConvention = CallingConvention.Cdecl)]
	public static extern void UpdateEmulator(IntPtr emulator, double delta);

	[DllImport(PEMSA_LIBRARY_NAME, CallingConvention = CallingConvention.Cdecl)]
	public static extern void LoadCart(IntPtr emulator, string cart);

	[DllImport(PEMSA_LIBRARY_NAME, CallingConvention = CallingConvention.Cdecl)]
	public static extern double SampleAudio(IntPtr emulator);
	#endregion
}
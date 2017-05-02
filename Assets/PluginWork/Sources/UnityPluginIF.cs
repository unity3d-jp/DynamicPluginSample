namespace UTJ {

using UnityEngine;
using System.Runtime.InteropServices;

public class UnityPluginIF {
	#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX
	public static void Load(string name)
	{
		#if UNITY_EDITOR_WIN
		EditorWindowsIF.Load(name);
		#elif UNITY_EDITOR_OSX
		EditorMacIF.Load(name);
		#else
		Debug.Assert(false);
		#endif
	}
	#else
	public static void Load(string name) {}
	#endif

	#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX
	public static void Unload()
	{
		#if UNITY_EDITOR_WIN
		EditorWindowsIF.Unload();
		#elif UNITY_EDITOR_OSX
		EditorMacIF.Unload();
		#else
		Debug.Assert(false);
		#endif
	}
	#else
	public static void Unload() { return; }
	#endif

	#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX
	delegate float foo_signature(float value);
	public static float foo(float value) {
		#if UNITY_EDITOR_WIN
		var func = EditorWindowsIF.GetDelegate<foo_signature>("foo"); // consumes GC memory
		return (float)func.DynamicInvoke(value);
		#elif UNITY_EDITOR_OSX
		var func = EditorMacIF.GetDelegate<foo_signature>("foo"); // consumes GC memory
		return func(value);
		#else
		Debug.Assert(false);
		return 0f;
		#endif
	}
	#else
	# if UNITY_IPHONE || UNITY_XBOX360
	[DllImport("__Internal")]
	# else
	[DllImport("UnityPlugin")]
	# endif
	public static extern float foo(float value);
	#endif
}

} // namespace UTJ {

/*
 * End of UnityPluginIF.cs
 */

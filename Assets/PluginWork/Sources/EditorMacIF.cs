namespace UTJ {

using System;
using System.Runtime.InteropServices;
using UnityEngine;
 
public static class EditorMacIF
{
#if UNITY_EDITOR_OSX
	private const int RTLD_LAZY     = 0x0001;
	private static IntPtr native_library_ptr_ = IntPtr.Zero;

	[DllImport("__Internal")]
	public static extern IntPtr dlopen(string filename, int flag);
	[DllImport("__Internal")]
	public static extern IntPtr dlsym(IntPtr handle, string symbol);
	[DllImport("__Internal")]
	public static extern int dlclose(IntPtr handle);

	public static void Load(string dllname)
	{
        Debug.Assert(native_library_ptr_ == IntPtr.Zero);
		var path = Application.dataPath+"/PluginWork/Plugins/OSX/UnityPlugin.bundle/Contents/MacOS/UnityPlugin";
		native_library_ptr_ = dlopen(path, RTLD_LAZY);
        if (native_library_ptr_ == IntPtr.Zero) {
            Debug.LogError("Failed to load native library:"+path);
			return;
        }
	}
	
	public static void Unload()
	{
        if (native_library_ptr_ == IntPtr.Zero) {
			return;
		}
		int ret = dlclose(native_library_ptr_);
        Debug.Log(ret == 0 ?
				  "Native library successfully unloaded." :
				  "Native library could not be unloaded.");
		native_library_ptr_ = IntPtr.Zero;
	}

	public static T GetDelegate<T>(string name) where T : class
	{
		return Marshal.GetDelegateForFunctionPointer(dlsym(native_library_ptr_, name), typeof(T)) as T;
	}

#endif // #if UNITY_EDITOR_OSX
}

} // namespace UTJ {

/*
 * End of MacEditorNative.cs
 */

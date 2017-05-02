using System;
using System.Runtime.InteropServices;
using UnityEngine;
 
public static class EditorWindowsIF
{
#if UNITY_EDITOR_WIN
	private static IntPtr native_library_ptr_ = IntPtr.Zero;

    [DllImport("kernel32", SetLastError = true)]
    [return: MarshalAs(UnmanagedType.Bool)]
    private static extern bool FreeLibrary(IntPtr hModule);
    [DllImport("kernel32", SetLastError = true, CharSet = CharSet.Unicode)]
    private static extern IntPtr LoadLibrary(string lpFileName);
    [DllImport("kernel32")]
    public static extern IntPtr GetProcAddress(IntPtr hModule, string procedureName);

	public static void Load(string dllname)
	{
        Debug.Assert(native_library_ptr_ == IntPtr.Zero);
		var path = Application.dataPath+"/PluginWork/Plugins/x86_64/"+dllname+"/"+dllname+".dll";
		native_library_ptr_ = LoadLibrary(path);
        if (native_library_ptr_ == IntPtr.Zero) {
            Debug.LogError("Failed to load native library");
        }
	}
	
	public static void Unload()
	{
        if (native_library_ptr_ == IntPtr.Zero) {
			return;
		}
		bool success = FreeLibrary(native_library_ptr_);
        Debug.Log(success ?
				  "Native library successfully unloaded." :
				  "Native library could not be unloaded.");
		native_library_ptr_ = IntPtr.Zero;
	}

	public static System.Delegate GetDelegate<T>(string funcname)
	{
		IntPtr funcPtr = GetProcAddress(native_library_ptr_, funcname);
		if (funcPtr == IntPtr.Zero) {
            Debug.LogErrorFormat("Could not gain reference to method[{0}] address.", funcname);
			return null;
		}
		var func = Marshal.GetDelegateForFunctionPointer(funcPtr, typeof(T));
		return func;
	}	

#endif // #if UNITY_EDITOR_WIN
}
/*
 * End of WindowsEditorNative.cs
 */

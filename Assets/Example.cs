using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Example : MonoBehaviour {

	void Awake()
	{
		UTJ.UnityPluginIF.Load("UnityPlugin");
	}
	
	void Start()
	{
		float ret = UTJ.UnityPluginIF.foo(100f);
		Debug.Log(ret);
	}

	void OnApplicationQuit()
	{
		UTJ.UnityPluginIF.Unload();
	}
}

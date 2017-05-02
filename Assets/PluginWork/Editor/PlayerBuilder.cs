using UnityEngine;
using System.Collections;
using UnityEditor;

public class PlayerBuilder {

    [MenuItem ("Custom/Build iOS Player")]
	public static void buildiOS()
	{
		var success = PluginBuilder.BuildPluginIOS();
		if (!success) {
			return;
		}
		BuildPipeline.BuildPlayer(EditorBuildSettings.scenes,
								  "build/iOS",
								  BuildTarget.iOS,
								  BuildOptions.AcceptExternalModificationsToPlayer | BuildOptions.AutoRunPlayer);
								  // BuildOptions.None);
	}

    [MenuItem ("Custom/Build Android Player")]
	public static void buildAndroid()
	{
		var success = PluginBuilder.BuildPluginAndroid();
		if (!success) {
			return;
		}
		BuildPipeline.BuildPlayer(EditorBuildSettings.scenes,
								  "build/Android",
								  BuildTarget.Android,
								  BuildOptions.AcceptExternalModificationsToPlayer | BuildOptions.AutoRunPlayer);
								  // BuildOptions.None);
	}
}

/*
 * End of PlayerBuilder.cs
 */

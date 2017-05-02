using UnityEngine;
using System.Collections;
using UnityEditor;

public class ImportProcessor : AssetPostprocessor
{
    static void OnPostprocessAllAssets(string[] importedAssets,
									   string[] deletedAssets,
									   string[] movedAssets,
									   string[] movedFromAssetPaths)
    {
		bool rebuild = false;
        foreach( string path in importedAssets ) {
			if (path.StartsWith("Assets/PluginWork/Sources/") &&
				(path.EndsWith(".cpp") ||
				 path.EndsWith(".hpp"))) {
				rebuild = true;
				break;
			}
        }

		if (rebuild) {
			PluginBuilder.BuildPluginEditor();
		}
    }
}

/*
 * End of ImportProcessor.cs
 */

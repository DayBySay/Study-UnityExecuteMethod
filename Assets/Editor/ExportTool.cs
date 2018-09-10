using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ExportTool : MonoBehaviour {
    public static void ExportXcodeProject()
    {
        EditorUserBuildSettings.SwitchActiveBuildTarget (BuildTarget.iOS);
        List<string> scenes = new List<string>();
        for (int i = 0; i < EditorBuildSettings.scenes.Length; i++) 
        {
            if (EditorBuildSettings.scenes [i].enabled)
            {
                scenes.Add (EditorBuildSettings.scenes [i].path);
            }
        }

        var buildPlayerOptions = new BuildPlayerOptions();
        buildPlayerOptions.scenes = scenes.ToArray();
        buildPlayerOptions.locationPathName = "Xcode"; // 生成される Xcode Project 名
        buildPlayerOptions.target = BuildTarget.iOS;
        buildPlayerOptions.options = BuildOptions.None;
        BuildPipeline.BuildPlayer(buildPlayerOptions);
    }
}

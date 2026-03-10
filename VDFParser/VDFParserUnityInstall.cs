#if UNITY_EDITOR

using UnityEngine;
using UnityEditor;
using UnityEditor.Build;
using System.IO;
using System.Collections.Generic;

// This sets up the VDF_PARSER define. Based on the Steamworks NET wrapper project.
[InitializeOnLoad]
public class VDFParserUnityInstall
{
    static VDFParserUnityInstall()
    {
        // No point in enabling for non-Steam supported platforms.
        if (EditorUserBuildSettings.selectedBuildTargetGroup != BuildTargetGroup.Standalone)
        {
            return;
        }
        // Delay calls to fix compile issues with custom build profiles in Unity 6.00+
        EditorApplication.delayCall += AddDefineSymbols;
    }

    static void AddDefineSymbols()
    {
        string currentDefines;
        HashSet<string> defines;

#if UNITY_2021_1_OR_NEWER
        currentDefines = PlayerSettings.GetScriptingDefineSymbols(NamedBuildTarget.FromBuildTargetGroup(EditorUserBuildSettings.selectedBuildTargetGroup));
#else
		currentDefines = PlayerSettings.GetScriptingDefineSymbolsForGroup(EditorUserBuildSettings.selectedBuildTargetGroup);

#endif
        defines = new HashSet<string>(currentDefines.Split(';'))
        {
            "VDF_PARSER"
        };

        string newDefines = string.Join(";", defines);
        if (newDefines != currentDefines)
        {
#if UNITY_2021_1_OR_NEWER
            PlayerSettings.SetScriptingDefineSymbols(NamedBuildTarget.FromBuildTargetGroup(EditorUserBuildSettings.selectedBuildTargetGroup), newDefines);
#else
			PlayerSettings.SetScriptingDefineSymbolsForGroup(EditorUserBuildSettings.selectedBuildTargetGroup, newDefines);
#endif
        }
    }
}

#endif

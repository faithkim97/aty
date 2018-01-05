using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class DialogueEditor : EditorWindow {

    [MenuItem("Window/Dialogue Editor")]
    public static void ShowWindow() {
        GetWindow<DialogueEditor>();
    }

    private void OnGUI() {
        GUILayout.BeginVertical();
        EditorGUIUtility.hierarchyMode = true;
        indentLevel = 1;
    }

}

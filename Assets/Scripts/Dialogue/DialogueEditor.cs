using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class DialogueEditor : EditorWindow {

    private int indentLevel;
    [SerializeField]
    private DialogueTree savedTree, lastSavedTree;


    [MenuItem("Window/Dialogue Editor")]
    public static void ShowWindow() {
        GetWindow<DialogueEditor>();
    }

    private void OnGUI() {
        GUILayout.BeginVertical();
        EditorGUIUtility.hierarchyMode = true;
        indentLevel = 1;
        GUI.SetNextControlName("Dummy Contorl");
        GUI.Button(new Rect(0, 0, 0, 0), "", GUIStyle.none);



    }

}

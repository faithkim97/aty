using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class DialogueCreator : EditorWindow {
    List<Rect> windows = new List<Rect>();
    List<int> windowsToAttach = new List<int>();
    List<int> attachedWindows = new List<int>();

    List<string> dialogue = new List<string>();
    GameObject attachedObject;
    DialogueList dialogueList; 

    [MenuItem("Window/Dialogue creator")]
    static void ShowEditor() {
        DialogueCreator editor = EditorWindow.GetWindow<DialogueCreator>();
    }

    private void OnGUI() {
        attachedObject = (GameObject)EditorGUILayout.ObjectField("Game Object to Attach Dialogue", attachedObject, typeof(GameObject), true);
        if (attachedObject != null) {
            dialogueList = attachedObject.GetComponent<DialogueList>();
        }
        if (attachedWindows.Count >= 2) {
            for (int i = 0; i < attachedWindows.Count; i += 2) {
                DrawNodeCurve(windows[attachedWindows[i]], windows[attachedWindows[i + 1]]);
            }
        }

        for (int i = 0; i < windows.Count; i++) {
            windows[i] = GUI.Window(i, windows[i], DrawNodeWindow, "Window " + i);
        }

        if (GUILayout.Button("Create Node")) {
            windows.Add(new Rect(10, 10, 200, 200));
            dialogue.Add("insert dialogue here");
        }

        if (GUILayout.Button("Save Dialogue List")) {
            dialogueList.SaveDialogueList(dialogue);
            Debug.Log("saved");
        }

        if (GUILayout.Button("Clear Dialogue List")) {
            dialogueList.ClearDialogue();
        }

    }//end of onGUI


    void DrawNodeWindow(int id) {
        dialogue[id] = GUILayout.TextArea(dialogue[id], 200);
        if (GUILayout.Button("Add dialogue")) {
            dialogueList.setDialogue(dialogue[id]);
        }

        if (GUILayout.Button("Attach")) {
            windowsToAttach.Add(id);
            if (windowsToAttach.Count == 2) {
                attachedWindows.Add(windowsToAttach[0]);
                attachedWindows.Add(windowsToAttach[1]);
                windowsToAttach = new List<int>();
            }//end of count == 2
        }



    }//end of DrawNodeWindow

    void DrawNodeCurve(Rect start, Rect end) {
        Vector3 startPos = new Vector3(start.x + start.width, start.y + start.height / 2, 0);
        Vector3 endPos = new Vector3(end.x, end.y + end.height / 2, 0);
        Vector3 startTan = startPos + Vector3.right * 50;
        Vector3 endTan = endPos + Vector3.left * 50;
        Color shadowCol = new Color(0, 0, 0, 0.06f);

        for (int i = 0; i < 3; i++) {// Draw a shadow
            Handles.DrawBezier(startPos, endPos, startTan, endTan, shadowCol, null, (i + 1) * 5);
        }
        Handles.DrawBezier(startPos, endPos, startTan, endTan, Color.black, null, 1);
    }



}//end of DialogueCreator

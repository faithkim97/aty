using UnityEngine;
using UnityEditor;
using System.Collections.Generic;


public class DialogueCreator : EditorWindow {

    List<Rect> windows = new List<Rect>();
    List<int> windowsToAttach = new List<int>();
    List<int> attachedWindows = new List<int>();
    GameObject currObject;

    List<string> dialogues = new List<string>();
    DialogueList currDialogue;
    [MenuItem("Window/Dialogue Creator")]
    static void ShowEditor() {
        DialogueCreator editor = EditorWindow.GetWindow<DialogueCreator>();
    }


    void OnGUI() {
        currObject = (GameObject)EditorGUILayout.ObjectField("Game Object to Save/Load Tree", currObject, typeof(GameObject), true);
        if (currObject != null) {
            currDialogue = currObject.GetComponent<DialogueList>();
        }
        if (windowsToAttach.Count == 2) {
            attachedWindows.Add(windowsToAttach[0]);
            attachedWindows.Add(windowsToAttach[1]);
            windowsToAttach = new List<int>();
        }

        if (attachedWindows.Count >= 2) {
            for (int i = 0; i < attachedWindows.Count; i += 2) {
                DrawNodeCurve(windows[attachedWindows[i]], windows[attachedWindows[i + 1]]);
            }
        }

        BeginWindows();

        if (GUILayout.Button("Create Node")) {
            windows.Add(new Rect(100, 100, 200, 200));
            dialogues.Add("Insert dialogue here");
        }

        for (int i = 0; i < windows.Count; i++) {
            windows[i] = GUI.Window(i, windows[i], DrawNodeWindow, "Window " + i);
        }

        if (GUILayout.Button("Save Dialogue List")) {
            currDialogue.SaveDialogueList();
            Debug.Log("Saved current dialogue");
        }

        if (GUILayout.Button("Clear Dialogue List")) {
            List<string> currD = currDialogue.ClearDialogue();
            currDialogue.SaveDialogueList();
            Debug.Log("cleared: " + currD);
        }

        if (GUILayout.Button("Load Dialogue")) {

            //DialogueManager diaManager = GameObject.FindObjectOfType<DialogueManager>();
            currDialogue = currObject.GetComponent<DialogueList>();
            Dictionary<int, List<string>> loadedDict = currDialogue.LoadDialogueList();
            List<string> loadedDialogue = loadedDict[currDialogue.getID()];
            if (loadedDialogue == null || loadedDialogue.Count <= 0) { Debug.LogError("Cannot load dialogue. Either null or 0"); }
            //print dialogue
            for (int i = 0; i < loadedDialogue.Count; i++) {
                Debug.Log(loadedDialogue[i]);
            }
			
            
        }

        EndWindows();
    }


    void DrawNodeWindow(int id) {
        dialogues[id] = GUILayout.TextArea(dialogues[id], 200);

        if (GUILayout.Button("Add Dialogue")) {
           
            currDialogue.setDialogue(dialogues[id]);
        }

        if (GUILayout.Button("Attach")) {
            windowsToAttach.Add(id);
        }

        GUI.DragWindow();
    }


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
}

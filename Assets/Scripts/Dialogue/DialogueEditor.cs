using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class DialogueEditor : EditorWindow {
    List<Rect> windows = new List<Rect>();
    List<int> windowsToAttach = new List<int>();
    List<int> attachedWindows = new List<int>();
	DialogueTree dTree = new DialogueTree ();
	//DialogueTree dTree = ScriptableObject.CreateInstance("DialogueTree");
	public string stringToEdit = "Please add dialogue here";


	

    [MenuItem("Window/Dialogue editor")]
    static void ShowEditor() {
        DialogueEditor editor = EditorWindow.GetWindow<DialogueEditor>();
		
    }

    void OnGUI() {
		stringToEdit = GUILayout.TextArea(stringToEdit, 200);

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
            windows.Add(new Rect(10,10, 200, 200));
        }

        for (int i = 0; i < windows.Count; i++) {
            windows[i] = GUI.Window(i, windows[i], DrawNodeWindow, "Window " + i);
			//windows [i] = GUI.Window (i, windows [i], AddText, "Window " + i);
        }

        EndWindows();
    }

	
    void DrawNodeWindow(int id) {
		stringToEdit = GUILayout.TextArea(stringToEdit, 200);
		if (GUILayout.Button ("Add dialogue")) {
			//DialogueTree.Instance.setCurrNode ( new DialogueTree.DialogueNode (stringToEdit));
			dTree.setCurrNode (new DialogueTree.DialogueNode (stringToEdit));
			Debug.Log (dTree.getCurrNode ().getDialogue ());
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

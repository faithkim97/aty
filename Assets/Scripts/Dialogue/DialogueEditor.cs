using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class DialogueEditor : EditorWindow {
    /// <summary>
    /// keep track of what to show in Dialogue Editor
    /// </summary>
    List<Rect> windows = new List<Rect>();
    /// <summary>
    /// keep track of neighborless windows to attach
    /// </summary>
    List<int> windowsToAttach = new List<int>();
    /// <summary>
    /// keep track of windows that have neighbors
    /// </summary>
    List<int> attachedWindows = new List<int>();
    [SerializeField]
    [HideInInspector]
    private DialogueTree tree;
    public string dialogue = "ho there!";

    [MenuItem("Window/Dialogue Editor")]
    static void ShowEditor() {
        DialogueEditor editor = EditorWindow.GetWindow<DialogueEditor>();
    }

    private void OnGUI() {
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
           
            windows.Add(new Rect(10, 10, 100, 100));
        }

        for (int i = 0; i < windows.Count; i++) {
            windows[i] = GUI.Window(i, windows[i], DrawNodeWindow, "Window " + i);
           
        }
        EndWindows();
    }

    void DrawNodeWindow(int id) {
        if (GUILayout.Button("Attach")) {
            windowsToAttach.Add(id);
        }

        if (GUILayout.Button("Add Dialogue")) {
            dialogue = GUI.TextArea(new Rect(10, 10, 100, 100), dialogue, 25);
            tree.getCurrNode().setDialogue(dialogue);
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

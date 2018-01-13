using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class DialogueEditor : EditorWindow {
    List<Rect> windows = new List<Rect>();
    List<int> windowsToAttach = new List<int>();
    List<int> attachedWindows = new List<int>();
	DialogueTree dTree;
	public List<string> dialogues = new List<string> ();
	private List<DialogueTree> tree = new List<DialogueTree> ();
	//keep track of left branch responses
	List<string> lefts = new List<string>();
	//keep track of right branch responses
	List<string> rights = new List<string>();
	GameObject saveTreeToObject;


    [MenuItem("Window/Dialogue editor")]
    static void ShowEditor() {
        DialogueEditor editor = EditorWindow.GetWindow<DialogueEditor>();
		
    }

    void OnGUI() {
		//currNode = dTree;
	        
		//draw the branch
        if (attachedWindows.Count >= 2) {
            for (int i = 0; i < attachedWindows.Count; i += 2) {
                DrawNodeCurve(windows[attachedWindows[i]], windows[attachedWindows[i + 1]]);
            }
        }

        BeginWindows();
		//if saved is clicked
		//if load is clicked 

		if (GUILayout.Button("Create Node")) {
            windows.Add(new Rect(10,10, 200, 200));
			dialogues.Add ("Add new dialogue here");

        }

        for (int i = 0; i < windows.Count; i++) {
			//add nodes to the tree list 
			if (dTree == null) {
				dTree = new DialogueTree (0);
				tree.Add (dTree);
			} else {
				tree.Add (new DialogueTree (i));
			}

			lefts.Add ("left");
			rights.Add ("right");
            windows[i] = GUI.Window(i, windows[i], DrawNodeWindow, "Window " + i);
		
        }
		/*if (dTree != null && dTree.getDialogue() != null) {
			dTree.traverseTree ();
		}*/

		saveTreeToObject = (GameObject)EditorGUILayout.ObjectField("Game Object", saveTreeToObject, typeof(GameObject), true);
		if (GUILayout.Button ("Save Tree")) {
			SerializedTree sTree = saveTreeToObject.GetComponent<SerializedTree> ();
			sTree.SaveDialogueTree (dTree);
			
		}
        EndWindows();
		
    }

	
    void DrawNodeWindow(int id) {
		//create dialogue area 
		dialogues[id] = GUILayout.TextArea(dialogues[id], 200);


		if (GUILayout.Button("Add dialogue")) {
			tree [id].setDialogue (dialogues [id]);
		}

		lefts [id] = GUILayout.TextArea (lefts [id], 100);
		if (GUILayout.Button ("left")) {
			windowsToAttach.Add (id);
			if (windowsToAttach.Count == 2) {
				if (!DialogueTree.getDict().ContainsKey(lefts[id])) {
					DialogueTree.setBranch (lefts [id], false);
				}
				
				tree [id - 1].setLeft (tree[id]);
				attachedWindows.Add(windowsToAttach[0]);
				attachedWindows.Add(windowsToAttach[1]);
				windowsToAttach = new List<int>();
				
			}
		}
		rights [id] = GUILayout.TextArea (rights [id], 100);
		if (GUILayout.Button ("right")) {
			windowsToAttach.Add (id);
			if (windowsToAttach.Count == 2) {
				if (!DialogueTree.getDict ().ContainsKey (rights [id])) {
					DialogueTree.setBranch (rights [id], true);
				}
				tree [id - 1].setRight (tree[id]);
				attachedWindows.Add(windowsToAttach[0]);
				attachedWindows.Add(windowsToAttach[1]);
				windowsToAttach = new List<int>();
		
			}
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

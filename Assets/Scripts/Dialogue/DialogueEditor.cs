﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


public class DialogueEditor : EditorWindow {
    List<Rect> windows = new List<Rect>();

    List<int> windowsToAttach = new List<int>();

    List<int> attachedWindows = new List<int>();
    [SerializeField]
	DialogueTree dTree;
    /// <summary>
    /// list of all dialogues in the current tree
    /// being worked on 
    /// </summary>
	public List<string> dialogues = new List<string> ();
    /// <summary>
    /// dTree in list form 
    /// </summary>
	private List<DialogueTree> tree = new List<DialogueTree> ();
	//keep track of left branch responses
	List<string> lefts = new List<string>();
	//keep track of right branch responses
	List<string> rights = new List<string>();
	GameObject saveTreeToObject;
    
	//List<Rect> loadWindows = new List<Rect>(); 
    static List<DialogueTree> savedTrees = new List<DialogueTree>();

    List<Rect> loadWindows = new List<Rect>();
    /// <summary>
    /// loaded tree in list form 
    /// </summary>
    List<DialogueTree> listTree = new List<DialogueTree>();
    /// <summary>
    /// dialogues loaded from listTree
    /// </summary>
    List<string> loadedDialogues = new List<string>();
    List<string> loadedRights = new List<string>();
    List<string> loadedLefts = new List<string>();



    [MenuItem("Window/Dialogue editor")]
    static void ShowEditor() {
        DialogueEditor editor = EditorWindow.GetWindow<DialogueEditor>();
		 
    }

    void OnGUI() {
		//draw the branch
        if (attachedWindows.Count >= 2) {
            for (int i = 0; i < attachedWindows.Count; i += 2) {
                DrawNodeCurve(windows[attachedWindows[i]], windows[attachedWindows[i + 1]]);
            }
        }

        BeginWindows();

		if (GUILayout.Button("Create Node")) {
            windows.Add(new Rect(10,10, 200, 200));
			dialogues.Add ("Add new dialogue here");
        }

        //when adding windows in tree creation mode 
        AddWindows();
        //when loading windows from an existing tree
        for (int i = 0; i < loadWindows.Count; i++) {
            
            //loadedRights.Add("loaded right");
            //loadedLefts.Add("loaded left");
            loadWindows[i] = GUI.Window(i, loadWindows[i], LoadTreeWindow, "Window " + i);
        }//end of for loop        

        saveTreeToObject = (GameObject)EditorGUILayout.ObjectField("Game Object to Save/Load Tree", saveTreeToObject, typeof(GameObject), true);

        if (GUILayout.Button("Save Tree")) {
            SerializedTree sTree = saveTreeToObject.GetComponent<SerializedTree>();
            sTree.SaveDialogueTree(dTree);
            //dTree.traverseTree();
            Debug.Log("dtree branch: " + DialogueTree.getBranch(dTree, dTree.getLeft()).getData());
            DialogueTree.SaveDialogueBranches();
        }
       

        if (GUILayout.Button("Load Tree")) {
            if (saveTreeToObject != null) {
                loadWindows = new List<Rect>();
                SerializedTree sTree = saveTreeToObject.GetComponent<SerializedTree>();
                savedTrees = sTree.LoadDialogueTree();
                List<DialogueTree.DialogueBranch> branches = DialogueTree.LoadDialogueBranches();
                for (int j = 0; j < branches.Count; j++) {
                    Debug.Log("branch: " + j + ": " + branches[j].getParent().getDialogue() + " " + branches[j].getChild().getDialogue());
                }
                // savedTrees[sTree.getID()].traverseTree();
              
                listTree = sTree.getTreeInList(savedTrees[sTree.getID()]);
                //Debug.Log("loaded branch: " + DialogueTree.getBranch(listTree[0], listTree[0].getLeft()));
                for (int i = 0; i < listTree.Count; i++) {
                    loadWindows.Add(new Rect(10, 10, 200, 200));
                    loadedDialogues.Add(listTree[i].getDialogue());
                    if (DialogueTree.getBranch(listTree[i], listTree[i].getLeft()) != null) {
                      Debug.Log("inside get branch yooooo");
                        
                       loadedLefts.Add(DialogueTree.getBranch(listTree[i], listTree[i].getLeft()).getData());
                    }
                    if (DialogueTree.getBranch(listTree[i], listTree[i].getRight()) != null) {
                        loadedRights.Add(DialogueTree.getBranch(listTree[i], listTree[i].getRight()).getData());
                    }
                }//end of for loop

                //dTree = listTree[0];
            }//end of load tree
        }
        EndWindows();
		
    }//end of OnGUI

    void AddWindows() {
        for (int i = 0; i < windows.Count; i++) {
            //add nodes to the tree list 
            if (dTree == null) {
                dTree = new DialogueTree(0);
                tree.Add(dTree);
            }
            else {
                tree.Add(new DialogueTree(i));
            }

            lefts.Add("left");
            rights.Add("right");
            windows[i] = GUI.Window(i, windows[i], DrawNodeWindow, "Window " + i);
        }

    } //end of AddWindow

    void LoadTreeWindow(int id) {
        //load dialogues
        if (loadedDialogues[id] != null) {
            loadedDialogues[id] = GUILayout.TextArea(loadedDialogues[id], 200);
        }
        if (GUILayout.Button("Add dialogue")) {
            listTree[id].setDialogue(loadedDialogues[id]);
        }

        //load left
        //Debug.Log("laoded lefts: " + loadedLefts.Count);
        if (loadedLefts.Count > 0) {
            loadedLefts[id] = GUILayout.TextArea(DialogueTree.getBranch(listTree[id], listTree[id].getLeft()).getData(), 100);
        }

        //load right
        if (loadedRights.Count > 0) {
            loadedRights[id] = GUILayout.TextArea(DialogueTree.getBranch(listTree[id], listTree[id].getRight()).getData(), 100);
        }
       


        GUI.DragWindow();
    }

    void DrawNodeWindow(int id) {
		//create dialogue area 
		dialogues[id] = GUILayout.TextArea(dialogues[id], 200);
		if (GUILayout.Button("Add dialogue")) {
			tree [id].setDialogue (dialogues [id]);
			Debug.Log ("You have added a dialogue");
		}
        //text area for left branch
        lefts[id] = GUILayout.TextArea(lefts[id], 100);
       
        if (GUILayout.Button("left")) {
            windowsToAttach.Add(id);
            if (windowsToAttach.Count == 2) {
                //setLeft
                tree[(id-1)/2].setLeft(tree[id]);
                DialogueTree.setBranch(tree[(id - 1) / 2], tree[id]);
                DialogueTree.getBranch(tree[(id - 1) / 2], tree[id]).setData(lefts[(id-1)/2]);
                //Debug.Log(DialogueTree.getBranch(tree[(id - 1) / 2], tree[id]).getData());
                attachedWindows.Add(windowsToAttach[0]);
                attachedWindows.Add(windowsToAttach[1]);
                windowsToAttach = new List<int>();
            }
       }//end of if left

        rights[id] = GUILayout.TextArea(rights[id], 100);
        if (GUILayout.Button("right")) {
            windowsToAttach.Add(id);
            if (windowsToAttach.Count == 2) {
                tree[(id - 1) / 2].setRight(tree[id]);
                DialogueTree.setBranch(tree[(id - 1) / 2], tree[id]);
                DialogueTree.getBranch(tree[(id - 1) / 2], tree[id]).setData(rights[(id-1)/2]);
                //Debug.Log(DialogueTree.getBranch(tree[(id - 1) / 2], tree[id]).getData());
                attachedWindows.Add(windowsToAttach[0]);
                attachedWindows.Add(windowsToAttach[1]);
                windowsToAttach = new List<int>();
            }
        }//end of if right
        /*
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
		}*/
        GUI.DragWindow();
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
}

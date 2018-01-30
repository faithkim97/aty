using System.Collections;
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
    List<DialogueTree> listTree = new List<DialogueTree>();
    List<string> loadedDialogues = new List<string>();
    List<string> loadedRights = new List<string>();
    List<string> loadedLefts = new List<string>();
    List<int> loadedWindowstoAttach = new List<int>();
    List<int> loadedWindowsAttached = new List<int>();
    bool loadAddBranch = false;


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
        //draw the branch when loaded
        if (loadedWindowsAttached.Count >= 2) {
            for (int i = 0; i < loadedWindowsAttached.Count; i += 2) {
                DrawNodeCurve(loadWindows[loadedWindowsAttached[i]], loadWindows[loadedWindowsAttached[i + 1]]);
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

            string rightDialogue = ((listTree[i].getRight() != null) && (DialogueTree.getBranch(listTree[i], listTree[i].getRight()) != null)) ? DialogueTree.getBranch(listTree[i], listTree[i].getLeft()).getData() : ("insert right response");
            string leftDialogue = ((listTree[i].getLeft() != null) && (DialogueTree.getBranch(listTree[i], listTree[i].getLeft()) != null)) ? DialogueTree.getBranch(listTree[i], listTree[i].getLeft()).getData() : ("insert left response");
            loadedLefts.Add(leftDialogue);
            loadedRights.Add(rightDialogue);
            loadWindows[i] = GUI.Window(i, loadWindows[i], LoadTreeWindow, "Window " + i);
        }//end of for loop        

        saveTreeToObject = (GameObject)EditorGUILayout.ObjectField("Game Object to Save/Load Tree", saveTreeToObject, typeof(GameObject), true);

        if (GUILayout.Button("Save Tree")) {
            SerializedTree sTree = saveTreeToObject.GetComponent<SerializedTree>();
            sTree.SaveDialogueTree(dTree);
            DialogueTree.SaveDialogueBranches();
            Debug.Log("Your tree has been saved");
        }


        if (GUILayout.Button("Load Tree")) {
            if (saveTreeToObject != null) {
                loadWindows = new List<Rect>();
                SerializedTree sTree = saveTreeToObject.GetComponent<SerializedTree>();
                savedTrees = sTree.LoadDialogueTree();

                //savedTrees[sTree.getID()].traverseTree();
                //you don't need this 
                List<DialogueTree.DialogueBranch> branches = DialogueTree.LoadDialogueBranches();
                if (sTree.getSavedTree() != null) {
                    dTree = sTree.getSavedTree();
                    listTree = sTree.getTreeInList(savedTrees[sTree.getID()]);
                    tree = listTree;
                    Debug.Log("ListTree Count: " + listTree.Count);

                    for (int i = 0; i < listTree.Count; i++) {
                        //create windows
                        loadWindows.Add(new Rect(10, 10, 200, 200));
                        //add loaded dialogues
                        loadedDialogues.Add(listTree[i].getDialogue());
                    }//end of for loop

                    //dTree = listTree[0];
                }
                else {
                    Debug.Log("Your dialogue tree is null");
                }
            } 
        }//end of load button

       

        if (GUILayout.Button("Clear Dialogue Tree")) {
            ClearTreeButton();
            dTree = null;
            saveTreeToObject.GetComponent<SerializedTree>().SaveDialogueTree(dTree);
            Debug.Log("saved tree after clear: " + saveTreeToObject.GetComponent<SerializedTree>().getSavedTree());
            Debug.Log("Your dialogue tree has been cleared");
        }

        
        EndWindows();
		
    }//end of OnGUI

    void ClearTreeButton() {
        if (saveTreeToObject != null) {
            SerializedTree sTree = saveTreeToObject.GetComponent<SerializedTree>();
            sTree.ClearDialogueTree();
        }
    }

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
        loadAddBranch = true;
        //load dialogues
        if (loadedDialogues[id] != null) {
            loadedDialogues[id] = GUILayout.TextArea(loadedDialogues[id], 200);
        }
        if (GUILayout.Button("Add dialogue")) {
            listTree[id].setDialogue(loadedDialogues[id]);
        }

        
        loadedLefts[id] = GUILayout.TextArea(loadedLefts[id], 200);
        
        if ((listTree[id].getLeft() != null) && (DialogueTree.getBranch(listTree[id], listTree[id].getLeft()) != null)) {
                LoadGUIBranches(id, 1);
                if (GUILayout.Button("edit left")) {
                    DialogueTree.getBranch(listTree[id], listTree[id].getLeft()).setData(loadedLefts[id]);
                    Debug.Log(DialogueTree.getBranch(listTree[id], listTree[id].getLeft()).getData());
                }

            }
            else if ( listTree[id].getLeft() == null || (listTree[id].getLeft() != null) && (DialogueTree.getBranch(listTree[id], listTree[id].getLeft()) == null)){
                
                if (GUILayout.Button("left")) {
                   // windowsToAttach.Add(id);
                    //if (windowsToAttach.Count == 2) {
                         listTree[(id - 1) / 2].setLeft(listTree[id]);
                        DialogueTree.setBranch(listTree[(id - 1) / 2], listTree[id]);
                        DialogueTree.getBranch(listTree[(id - 1) / 2], listTree[id]).setData(loadedLefts[id]);
                        //attachedWindows.Add(loadedWindowstoAttach[0]);
                        //attachedWindows.Add(loadedWindowstoAttach[1]);
                        //windowsToAttach = new List<int>();

                    //}
                }
            }

        loadedRights[id] = GUILayout.TextArea(loadedRights[id], 100);
        if ((listTree[id].getRight() != null) && (DialogueTree.getBranch(listTree[id], listTree[id].getRight()) != null)) {
                LoadGUIBranches(id, 2);
            if (GUILayout.Button("edit right")) {
                DialogueTree.getBranch(listTree[id], listTree[id].getRight()).setData(loadedRights[id]);
                Debug.Log(DialogueTree.getBranch(listTree[id], listTree[id].getRight()).getData());
            }
        }
       else {
            //if (GUILayout.Button("right")) {
             // windowsToAttach.Add(id);
              //if (windowsToAttach.Count == 2) {
                    listTree[(id - 1) / 2].setRight(listTree[id]);
                    DialogueTree.setBranch(listTree[(id - 1) / 2], listTree[id]);
                    DialogueTree.getBranch(listTree[(id - 1) / 2], listTree[id]).setData(loadedRights[id]);
                   // attachedWindows.Add(loadedWindowstoAttach[0]);
                    //attachedWindows.Add(loadedWindowstoAttach[1]);
                    //windowsToAttach = new List<int>();

              //}
            //}
        }
        
       
        GUI.DragWindow();
    }
    void LoadGUIBranches(int id, int branchID) {
        loadedWindowstoAttach.Add(id);
        loadedWindowstoAttach.Add((2 * id + branchID));
        loadedWindowsAttached.Add(loadedWindowstoAttach[0]);
        loadedWindowsAttached.Add(loadedWindowstoAttach[1]);
        loadedWindowstoAttach = new List<int>();

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
                    tree[(id - 1) / 2].setLeft(tree[id]);
                    DialogueTree.setBranch(tree[(id - 1) / 2], tree[id]);
                    DialogueTree.getBranch(tree[(id - 1) / 2], tree[id]).setData(lefts[(id - 1) / 2]);
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
                    DialogueTree.getBranch(tree[(id - 1) / 2], tree[id]).setData(rights[(id - 1) / 2]);
                    //Debug.Log(DialogueTree.getBranch(tree[(id - 1) / 2], tree[id]).getData());
                    attachedWindows.Add(windowsToAttach[0]);
                    attachedWindows.Add(windowsToAttach[1]);
                    windowsToAttach = new List<int>();
                }
            }//end of if right
  
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

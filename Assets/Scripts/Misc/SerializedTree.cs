using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
[System.Serializable]
public class SerializedTree : MonoBehaviour {

	[SerializeField]
	private DialogueTree savedTree;
    [SerializeField]
    private int id;
    //list of all saved trees on each NPC; index is according to id number
    //private static List<DialogueTree> savedTrees = new List<DialogueTree>(); 
    private static Dictionary<int, DialogueTree> savedTrees = new Dictionary<int, DialogueTree>();
	//tree but in a list form
    //[SerializeField]
    //current tree but in list form
	private List<DialogueTree> treeInList;
    public int getID() {
        return id;
    }

    public void SaveDialogueTree(DialogueTree dTree) {
        savedTree = dTree;
        if (!savedTrees.ContainsKey(id) && dTree != null) {
            Debug.Log("inside saved tree does not contain key");
            savedTrees.Add(id, savedTree);
        }

        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/savedTrees.gd");
        bf.Serialize(file, savedTrees);
        file.Close();
    }

    public Dictionary<int,DialogueTree> LoadDialogueTree() {
        if (File.Exists(Application.persistentDataPath + "/savedTrees.gd")) {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/savedTrees.gd", FileMode.Open);
            savedTrees = (Dictionary<int,DialogueTree>)bf.Deserialize(file);
            file.Close();
        }

        //DialogueTree.LoadDialogueBranches();
        return savedTrees;
    }

    public DialogueTree ClearDialogueTree() {
        if ((savedTree != null) && savedTrees.ContainsValue(savedTree)) {
            savedTrees.Remove(id);
        }

        return savedTree = null;
    }

	public void printTree() {
		savedTree.traverseTree ();
	}

	public DialogueTree getSavedTree() {
		return savedTree;
	}

    public static DialogueTree getSavedTree(int id) {
        return savedTrees[id];
    }



	public List<DialogueTree> getTreeInList(DialogueTree dTree) {
		treeInList = new List<DialogueTree> ();
		return recurseList (dTree);
	}

	private List<DialogueTree> recurseList(DialogueTree dTree) {
		if (dTree == null) {
			return treeInList;
		}
		treeInList.Add (dTree);
		recurseList (dTree.getLeft());
		recurseList (dTree.getRight());
		return treeInList;
	}

    public static Dictionary<int, DialogueTree> getSavedTrees() {
        return savedTrees;
    }
		
}

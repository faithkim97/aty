using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SerializedTree : MonoBehaviour {

	[SerializeField]
	private DialogueTree savedTree; 
	//tree but in a list form
	private List<DialogueTree> treeInList;

	public void SaveDialogueTree( DialogueTree dTree ) {
		savedTree = dTree;
	}

	public void printTree() {
		savedTree.traverseTree ();
	}

	public DialogueTree getSavedTree() {
		return savedTree;
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
		
}

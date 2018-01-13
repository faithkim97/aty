using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SerializedTree : MonoBehaviour {

	[SerializeField]
	DialogueTree savedTree; 

	void Update() {
		if (savedTree != null) {
			savedTree.traverseTree ();
		}
	}

	public void SaveDialogueTree( DialogueTree dTree ) {
		savedTree = dTree;
	}

	public void printTree() {
		savedTree.traverseTree ();
	}
		
}

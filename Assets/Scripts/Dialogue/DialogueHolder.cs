using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Will be attached to each game object
/// Activates and prints out dialogue from serialized tree
/// </summary>
public class DialogueHolder : MonoBehaviour {
    private DialogueTree savedTree;
	// Use this for initialization
	void Start () {
        SerializedTree sTree = gameObject.GetComponent<SerializedTree>();
        List<DialogueTree> savedTrees =  sTree.LoadDialogueTree();
        savedTree = savedTrees[sTree.getID()];
        savedTree.traverseTree();

	}
	

}//end of DialogueHolder

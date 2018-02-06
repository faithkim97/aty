using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Will be attached to each game object
/// Activates and prints out dialogue from serialized tree
/// </summary>
public class DialogueHolder : MonoBehaviour {
    private DialogueTree savedTree;
    private DialogueManager diaManager;
    int ID;
    private DialogueTree currDialogue;
	// Use this for initialization
	void Start () {
        //load tree
        SerializedTree sTree = gameObject.GetComponent<SerializedTree>();
        List<DialogueTree> savedTrees =  sTree.LoadDialogueTree();
        savedTree = savedTrees[sTree.getID()];
        currDialogue = savedTree;
        DialogueTree.LoadDialogueBranches();
        //savedTree.traverseTree();
        //find dialogue manager
        diaManager = GameObject.FindObjectOfType<DialogueManager>();
        ID = sTree.getID();
	}

    private void OnTriggerStay2D(Collider2D collision) {
        Debug.Log("inside trigger");
        if (Input.GetKeyDown(KeyCode.Space) && collision.gameObject.CompareTag("player")) {
            diaManager.ShowBox();
            diaManager.ShowDialogue(currDialogue.getDialogue());
            diaManager.ShowPlayerChoices(currDialogue);
            
        }
    }//end of Trigger


}//end of DialogueHolder

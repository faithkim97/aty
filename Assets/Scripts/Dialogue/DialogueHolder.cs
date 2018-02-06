using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Will be attached to each game object
/// Activates and prints out dialogue from serialized tree
/// </summary>
[System.Serializable]
public class DialogueHolder : MonoBehaviour {
    private DialogueTree savedTree;
    private DialogueManager diaManager;
    int ID;
    private DialogueTree currDialogue;
	// Use this for initialization
	void Start () {
        //load tree
        SerializedTree sTree = gameObject.GetComponent<SerializedTree>();
        Dictionary<int,DialogueTree> savedTrees =  sTree.LoadDialogueTree();
        savedTree = savedTrees[sTree.getID()];
        currDialogue = savedTree;
        DialogueTree.LoadDialogueBranches();
        //savedTree.traverseTree();
        //find dialogue manager
        diaManager = GameObject.FindObjectOfType<DialogueManager>();
        ID = sTree.getID();
	}


    private void Update() {
        if (diaManager.diaActive) {
            traverseDialogues();
            diaManager.ShowDialogue(currDialogue.getDialogue());
            diaManager.ShowPlayerChoices(currDialogue);
        }
    }

    private void OnTriggerStay2D(Collider2D collision) {
        //Debug.Log("inside trigger");
        if (Input.GetKeyDown(KeyCode.Space) && collision.gameObject.CompareTag("player")) {
            diaManager.ShowBox();
            
            
        }
    }//end of Trigger

    public void traverseDialogues() {
        if (Input.GetKeyDown(KeyCode.K)) {

            if (currDialogue != null) { Debug.Log("inside right");
                currDialogue = currDialogue.getRight(); }
           
        }
        else if (Input.GetKeyDown(KeyCode.L)) {
            if (currDialogue != null) { Debug.Log("inside left");
                currDialogue = currDialogue.getLeft(); }
            
        }
    }

    //public void Save current node 


}//end of DialogueHolder

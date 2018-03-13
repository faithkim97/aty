﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Will be attached to each game object
/// Activates and prints out dialogue from serialized tree
/// </summary>
[System.Serializable]
public class DialogueHolder : MonoBehaviour {
  //  private DialogueList dialogueList;
    private DialogueManager diaManager;
    //list of strings of all dialogues that need to be displayed
     private List<string> currDialogue;
	//using this to index into the dialogue 
	int i;
    bool triggered = false;
 
	// Use this for initialization
	void Start () {
        diaManager = GameObject.FindObjectOfType<DialogueManager>();
        DialogueList dialogueList = gameObject.GetComponent<DialogueList>();
        Dictionary<int,List<string>> savedDialogues = dialogueList.LoadDialogueList();
		if (!savedDialogues.ContainsKey (dialogueList.getID())) {
			Debug.LogError ("The key in dictionary does not exist");
		} else { 
			currDialogue = savedDialogues[dialogueList.getID()];
		} 
	}//end of start

   private void Update() {
		if (triggered) {
            //diaManager.ShowDialogue(traverseList());
			traverseList();
        }
    }
	

    private void OnTriggerStay2D(Collider2D collision) {


		GameObject g = collision.gameObject;
		int ex = GameManager.getDeathCount ();
		if (g.CompareTag ("player") && (ex == 1 || ex == 2 || ex == 3)) {
			triggered = true;
			diaManager.ShowBox ();
		}
		if (Input.GetKeyDown(KeyCode.F) && g.CompareTag("player")) {
			triggered = true;
            diaManager.ShowBox();
            traverseList();
        }
    }//end of Trigger



    public void traverseList() {
      //  if (gameObject.tag == "health") {
            if (i == currDialogue.Count) {
                triggered = false;
				gameObject.SetActive (false);
                diaManager.HideBox();
                return;
            }
            diaManager.ShowDialogue(currDialogue[i]);
            
            if (i < currDialogue.Count && Input.GetKeyUp(KeyCode.K)) {
                i++;
            }
       
        //}
		
    }//end of traverselist

	public void setTriggered(bool t) {
		triggered = t;

	}

	//return whether dialogue is triggered or not
	public bool getTriggered() {
		return triggered;
	}


}//end of DialogueHolder

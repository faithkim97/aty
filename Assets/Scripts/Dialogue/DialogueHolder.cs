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

		int ex = GameManager.getDeathCount ();
		if (Input.GetKeyDown(KeyCode.F) && collision.gameObject.CompareTag("player")) {
			triggered = true;
			diaManager.ShowBox();
			traverseList();
		}

		EmailTriggers (collision, ex);

	

    }//end of Trigger


	private void EmailTriggers(Collider2D collision, int ex) {
		if ( gameObject.CompareTag("health") && collision.gameObject.CompareTag ("player") && (ex == 1)) {
			triggered = true;
			diaManager.ShowBox ();
		}

		if (collision.gameObject.CompareTag ("player")) {
			if (gameObject.CompareTag ("health") && ex == 1) {
				triggered = true;
				diaManager.ShowBox ();
			} else if (gameObject.CompareTag ("dean") && ex == 2) {
				triggered = true;
				diaManager.ShowBox ();
			} else if (gameObject.CompareTag ("mom") && ex == 3) {
				triggered = true;
				diaManager.ShowBox ();
			}

		}//end of if player
	}


    public void traverseList() {
      //  if (gameObject.tag == "health") {
            if (i == currDialogue.Count) {
                triggered = false;
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

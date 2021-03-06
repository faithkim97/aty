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
	bool dialogueDone = false;
    private LevelManager levelManager;
    DialogueScript diaScript;

    // Use this for initialization
    void Start () {
        levelManager = GameObject.FindObjectOfType<LevelManager>();
        diaManager = GameObject.FindObjectOfType<DialogueManager>();
        diaScript = gameObject.GetComponent<DialogueScript>();
        if (diaScript != null) {
            currDialogue = diaScript.getDialogues()[gameObject.tag];
        }
	}//end of start


   private void Update() {
		if (triggered) {
            //diaManager.ShowDialogue(traverseList());
			traverseList();
        }
		DisableEmail ();
    }

  /*  private void OnTriggerEnter2D(Collider2D collision) {
        
        if (Input.GetKeyDown(KeyCode.F) && collision.gameObject.CompareTag("player")) {
            Debug.Log("inside F");
            triggered = true;
            diaManager.ShowBox();
            traverseList();
        }
    }
    */
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
		if (collision.gameObject.CompareTag ("player")) {
			if (gameObject.CompareTag ("health") && ex == 1) {
				triggered = true;
				diaManager.ShowBox ();
			}  if (gameObject.CompareTag ("dean") && ex == 4) {
                triggered = true;
				diaManager.ShowBox ();
			} else if (gameObject.CompareTag ("mom") && ex == 5) {
                triggered = true;
				diaManager.ShowBox ();
			}
		}//end of if player
	}

	private void DisableEmail() {
		if(Input.GetKeyDown(KeyCode.X) && (gameObject.CompareTag("health") || gameObject.CompareTag("dean"))){
			gameObject.SetActive(false);
		}//end of if
	}

    public void traverseList() {
            if (i == currDialogue.Count) {
                triggered = false;
				dialogueDone = true;
                diaManager.HideBox();
                levelManager.ManageLevelEmail(true);
                return;
            }
            diaManager.ShowDialogue(currDialogue[i]);
            
            if (i < currDialogue.Count && Input.GetKeyUp(KeyCode.K)) {
                i++;
            }
    }//end of traverselist

	public void setTriggered(bool t) {
		triggered = t;
	}

	//return whether dialogue is triggered or not
	public bool getTriggered() {
		return triggered;
	}

	public void setDialogueDone(bool d) {
		dialogueDone = d;
	}

	public bool getDialogueDone() {
		return dialogueDone;
	}

  
}//end of DialogueHolder

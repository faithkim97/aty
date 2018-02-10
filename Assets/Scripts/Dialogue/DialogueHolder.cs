using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Will be attached to each game object
/// Activates and prints out dialogue from serialized tree
/// </summary>
[System.Serializable]
public class DialogueHolder : MonoBehaviour {
    private DialogueList dialogueList;
    private DialogueManager diaManager;
    int ID;
    //list of strings of all dialogues that need to be displayed
    private List<string> currDialogue;
 
	// Use this for initialization
	void Start () {
        diaManager = GameObject.FindObjectOfType<DialogueManager>();
        DialogueList dialogueList = gameObject.GetComponent<DialogueList>();
        Dictionary<int, List<string>> savedDialogues = dialogueList.LoadDialogueList();
        currDialogue = savedDialogues[ID];
 
	}


    private void Update() {
        if (diaManager.diaActive) {
            diaManager.ShowDialogue(traverseList());

        }
    }//end of Update()

    private void OnTriggerStay2D(Collider2D collision) {
        //Debug.Log("inside trigger");
        if (Input.GetKeyDown(KeyCode.Space) && collision.gameObject.CompareTag("player")) {
            diaManager.ShowBox();
            diaManager.ShowDialogue("hello");
           // diaManager.ShowDialogue(traverseList());
            
            
        }
    }//end of Trigger



    public string traverseList() {
        int i = 1;
        if (Input.GetKey(KeyCode.K) && i < currDialogue.Count ) {
            return currDialogue[i];
            i++;
        }
        return "";
    }


}//end of DialogueHolder

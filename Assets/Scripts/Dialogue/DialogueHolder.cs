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
	//using this to index into the dialogue 
	int i;
 
	// Use this for initialization
	void Start () {
        diaManager = GameObject.FindObjectOfType<DialogueManager>();
        DialogueList dialogueList = gameObject.GetComponent<DialogueList>();
        Dictionary<int, List<string>> savedDialogues = dialogueList.LoadDialogueList();
		if (!savedDialogues.ContainsKey (ID)) {
			Debug.LogError ("The key in dictionary does not exist");
		} else {
			currDialogue = savedDialogues[ID];

		}
        
	}


    private void Update() {
		if (diaManager.diaActive) {
            //diaManager.ShowDialogue(traverseList());
			traverseList();

        }
    }//end of Update()

    private void OnTriggerStay2D(Collider2D collision) {
        //Debug.Log("inside trigger");
        if (Input.GetKeyDown(KeyCode.Space) && collision.gameObject.CompareTag("player")) {
            diaManager.ShowBox();
           // diaManager.ShowDialogue(traverseList());
            
            
        }
    }//end of Trigger



    public void traverseList() {
		if (i == currDialogue.Count) {
			diaManager.HideBox ();
			return;
		}
		diaManager.ShowDialogue (currDialogue [i]);
		if (i < currDialogue.Count && Input.GetKeyUp(KeyCode.K)  ) {
            i++;
        }
    }//end of traverselist


}//end of DialogueHolder

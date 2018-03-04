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
        SerializedDialogue savedDialogues = dialogueList.LoadDialogueList();
		Debug.Log ("size of dictionary (should be 2): " + savedDialogues.Count);
		if (!savedDialogues.ContainsKey (ID)) {
			Debug.LogError ("The key in dictionary does not exist");
		} else {
			currDialogue = savedDialogues[ID];

		
		}

	
        
	}

	public int getID() {

		return ID;
	}

    private void Update() {

		if (diaManager.diaActive) {
            //diaManager.ShowDialogue(traverseList());
			traverseList();
        }
    }
		

    private void OnTriggerStay2D(Collider2D collision) {
		GameObject g = collision.gameObject;
		bool narrTag = gameObject.CompareTag ("health"); //|| gameObject.CompareTag ("dean") 
		//|| gameObject.CompareTag ("mom");
		//not working because it doesn't do it when death count == 3 
		if (GameManager.getDeathCount() == 1 && narrTag && g.CompareTag ("player")) {
			Debug.Log ("IF");
			diaManager.ShowBox ();
		}
		//NarrativeTrigger (collision);
		if (Input.GetKeyDown(KeyCode.F) && collision.gameObject.CompareTag("player")) {
			Debug.Log ("ELSE IF");
            diaManager.ShowBox();
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

	private void NarrativeTrigger(Collider2D collision) {
		GameObject g = collision.gameObject;
		bool narrTag = gameObject.CompareTag ("health"); //|| gameObject.CompareTag ("dean") 
					//|| gameObject.CompareTag ("mom");
		if (narrTag && g.CompareTag ("player")) {
			diaManager.ShowBox ();
		}

	}//end of Narrative Trigger


}//end of DialogueHolder

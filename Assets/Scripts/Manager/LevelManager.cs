using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Used to hardcode specific events that happen at each day/level
/// </summary>
public class LevelManager : MonoBehaviour {
	private DialogueManager diaManager;
	private DialogueHolder currDia = null;

	void Start() {
		diaManager = GameObject.FindObjectOfType<DialogueManager> ();
		GameObject g = FindObject ();
		if ( g!= null ) {
			currDia = g.GetComponent<DialogueHolder> ();
			currDia.setTriggered (true);
		}
	}//end of start

	private void ManageLevels() {
	
	}

	private GameObject FindObject() {
		GameObject g = null;
		//if death count is certain number
		//then find object of specific tag/name of game object
		//set the currdia to that gameobject's dialogue 
		//set the triggered to true 
		for (int i = 0; i < GameManager.getDeathCount(); i++) {
			if ((i == 1)) {
				g = GameObject.Find ("Health Service email");
			} else if (i == 2) {
				g = GameObject.Find ("Dean email");
			} else if (i == 3) {
				g = GameObject.Find ("Mom's text");
			}
		}//end of for loop

		return g;
	}//end of FindObject

}//end of LevelManagaer

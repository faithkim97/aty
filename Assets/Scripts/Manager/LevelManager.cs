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
			ManageLevels ();
		}

		setDifficulty ();
	}//end of start

	/// <summary>
	/// creates specific triggers in game for health services, dean, etc. 
	/// </summary>
	private void ManageLevels() {
		if (GameManager.getDeathCount () == 1) {
			GameObject.Find ("test").SetActive (true);
		}
	}

	/// <summary>
	/// sets the difficulty level of each day
	/// </summary>
	private void setDifficulty() {
		int playerSpeed = PlayerControl.getPlayerSpeed();
		if (playerSpeed < 10) {
			PlayerControl.setPlayerSpeed(playerSpeed + 2);
		}
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

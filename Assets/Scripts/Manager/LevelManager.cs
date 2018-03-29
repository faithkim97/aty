using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
/// <summary>
/// Used to hardcode specific events that happen at each day/level
/// </summary>
public class LevelManager : MonoBehaviour {
	private DialogueManager diaManager;
	private DialogueHolder currDia = null;
	private GameObject narrObject = null;

	//create fields for the UI images
	public GameObject healthEmail;
	public GameObject deanEmail;
	public GameObject momText;

	void Start() {
		diaManager = GameObject.FindObjectOfType<DialogueManager> ();
	}//end of start

	void Update() {
		 narrObject = FindObject ();
		if ( narrObject!= null ) {
			setDifficulty ();
			currDia = narrObject.GetComponent<DialogueHolder> ();
			ManageLevels ();
		}

	}
		
	/// <summary>
	/// creates specific triggers in game for health services, dean, etc. 
	/// </summary>
	private void ManageLevels() {
		if (currDia.getDialogueDone () && !Input.GetKeyDown(KeyCode.X)) {
			if (GameManager.getDeathCount () == 1 && healthEmail != null) {
				healthEmail.SetActive (true);	
			}

			else if (GameManager.getDeathCount () == 2 && deanEmail != null) {
				deanEmail.SetActive (true);
			}

			else if (GameManager.getDeathCount () == 3 && momText != null) {
				momText.SetActive (true);
			}
		}//end of outer if

	}//end of manage levels

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
		//for (int i = 0; i < GameManager.getDeathCount(); i++) {
		int i = GameManager.getDeathCount();
		if (( i == 1)) {
				g = GameObject.Find ("Health Service email");
			} else if (i == 2) {
				g = GameObject.Find ("Dean email");
			} else if (i == 3) {
				g = GameObject.Find ("Mom's text");
			}
		//}//end of for loop

		return g;
	}//end of FindObject

}//end of LevelManagaer

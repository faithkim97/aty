using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Used to hardcode specific events that happen at each day/level
/// </summary>
public class LevelManager : MonoBehaviour {
    private static bool exhausted = false;
	private DialogueManager diaManager;

	private void Start() {
		diaManager = FindObjectOfType<DialogueManager> ();
	}
    private void FixedUpdate() {
        if (exhausted) {
            setDifficulty();
            //exhausted = false;
        }
    }

    public static bool getExhausted() {
        return exhausted;
    }

    public static void setExhausted(bool setBool) {
        exhausted = setBool;
    }

    private void setDifficulty() {
        int playerSpeed = PlayerControl.getPlayerSpeed();
        if (playerSpeed < 10) {
            PlayerControl.setPlayerSpeed(playerSpeed + 2);
        }
    }//end of setDifficulty

    private void setLevelScenario() {
        int tiredCount = GameManager.getDeathCount();
        //tiredCount == 3
        //show email from health services
        if (tiredCount == 3) {
			//if diaActive
			if (diaManager.diaActive) {
				//Show message from health services 
				Debug.Log("email from health services UI must be added");
			}
            //DialogueList dialogueList = GameObject.Find("Health Service email").GetComponent<DialogueList>();


            
        }

        //tiredCount == 4
            //show email from Dean

        //tiredCount == 5
            //get text from Mom 

		exhausted = false;
    }

}//end of LevelManagaer

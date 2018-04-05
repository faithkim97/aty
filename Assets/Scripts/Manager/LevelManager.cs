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

  //  private PlayerControl pControl;
    private bool manageLvl = true;

	void Start() {
		diaManager = GameObject.FindObjectOfType<DialogueManager> ();
        //GameObject player = GameObject.Find("player");
       // pControl = player.GetComponent<PlayerControl>();
	}//end of start

	void Update() { 
		 narrObject = FindObject ();
        if (narrObject != null) {
            currDia = narrObject.GetComponent<DialogueHolder>();
            ManageLevelEmail();
        }
        if (narrObject !=null && manageLvl ) {
            manageLvl = setDifficulty(manageLvl);
		}
       

	}
		
	/// <summary>
	/// creates specific triggers in game for health services, dean, etc. 
	/// </summary>
	private void ManageLevelEmail() {
            if (currDia.getDialogueDone() ) {
                if (GameManager.getDeathCount() == 1 && healthEmail != null) {
                    healthEmail.SetActive(true);
                }

                else if (GameManager.getDeathCount() == 2 && deanEmail != null) {
                    deanEmail.SetActive(true);
                }

                else if (GameManager.getDeathCount() == 3 && momText != null) {
                    momText.SetActive(true);
                }
            }//end of manageLvl
    }//end of manage levels

	/// <summary>
	/// sets the difficulty level of each day
	/// </summary>
	private bool setDifficulty(bool manageLvl) {
        if (manageLvl) {
            float playerSpeed = PlayerControl.getPlayerSpeed();
            int jumpPower = PlayerControl.getJumpPower();
            if (playerSpeed < 5.0f) {
                PlayerControl.setPlayerSpeed(playerSpeed + 0.2f);
            }

            if (jumpPower < 5000) {
                Debug.Log(jumpPower);
                PlayerControl.setJumpPower(jumpPower + 100);
            }
        }//end of manageLvl
        return false;
	}

	private GameObject FindObject() {
        GameObject g = null;
		int i = GameManager.getDeathCount();
		if (( i == 1)) {
				g = GameObject.Find ("Health Service email");
			} else if (i == 2) {
				g = GameObject.Find ("Dean email");
			} else if (i == 3) {
				g = GameObject.Find ("Mom's text");
			}
		return g;
	}//end of FindObject

}//end of LevelManagaer

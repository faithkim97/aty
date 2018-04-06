using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
/// <summary>
/// Used to hardcode specific events that happen at each day/level
/// </summary>
public class LevelManager : MonoBehaviour {
	private DialogueManager diaManager;
	private DialogueHolder currDia = null;
	private GameObject narrObject = null;

	//create fields for the UI images
	
	public GameObject deanEmail;
	public GameObject momText;
    public GameObject healthEmail;




    private bool manageLvl = true;

	void Start() {
		diaManager = GameObject.FindObjectOfType<DialogueManager> ();
        
        if ( healthEmail != null && deanEmail != null && momText != null) {
            ChangeOpacity(healthEmail, 0.0f);
            deanEmail.GetComponent<Image>().enabled = false;
            momText.GetComponent<Image>().enabled = false;
        }

    }//end of start

	void Update() { 
		 narrObject = FindObject ();
         if (narrObject != null) {
              currDia = narrObject.GetComponent<DialogueHolder>();
            //ManageLevelEmail();
            if (currDia.getDialogueDone() && GameManager.getDeathCount() == 1 && healthEmail != null) {
                Debug.Log("inside dDone healthEmail !=null");
                ChangeOpacity(healthEmail, 1.0f);
            }
        } 

     
        if (narrObject !=null && manageLvl ) {
            manageLvl = setDifficulty(manageLvl);
		}

       
      

    }//end of update
		
	/// <summary>
	/// creates specific triggers in game for health services, dean, etc. 
	/// </summary>
	public void ManageLevelEmail(bool dDone) {
        if (dDone ) {
            if ( GameManager.getDeathCount() == 2 && deanEmail != null) {
                deanEmail.GetComponent<Image>().enabled = true;
            }
                else if (GameManager.getDeathCount() == 3 && momText != null) {
                    momText.GetComponent<Image>().enabled = true;
            }
         }//end of dDone
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

    private void ChangeOpacity(GameObject g, float opacity) {
        Debug.Log("opacity: " + opacity);
        Image i = g.GetComponent<Image>();
        if (i != null) {
            Color tmp = i.color;
            tmp.a = opacity;
            i.color = tmp;
        }
    }//end of ChangeOpacity

}//end of LevelManagaer

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPCPressF : MonoBehaviour {
    public Text pressF;
    private DialogueManager dMan;

    private void Start() {
        dMan = GameObject.FindObjectOfType<DialogueManager>();
    }
    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("player")) {
            pressF.enabled = true;
        }

       
    }

    private void OnTriggerStay2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("player")) {
            if (dMan.diaActive) {
                Debug.Log("diaActive");
                pressF.enabled = false;
            }
        }
    }//end of stay

    private void OnTriggerExit2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("player")) {
            pressF.enabled = false;
        }
    }//end of exit

}//end of NPCPressF

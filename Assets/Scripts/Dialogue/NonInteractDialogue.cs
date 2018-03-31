using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NonInteractDialogue : MonoBehaviour {
    public Text text;
    [SerializeField]
    private string dialogue;

    private void OnTriggerStay2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("player")) {
              ActivateDialogue();
        }
    }

    private void OnTriggerExit2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("player")) {
            DeactivateDialogue();
        }
    }

    private void ActivateDialogue() {
        text.text = dialogue;
    }

    private void DeactivateDialogue() {
        text.text = "";
    }

}//end of NonInteractDialogue

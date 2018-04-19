using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class LibraryTrigger : MonoBehaviour {
    public Text text;

    void OnTriggerStay2D(Collider2D col) {
        if (col.gameObject.CompareTag("player")) {
            text.enabled = true;
        }
    }

    void OnTriggerExit2D(Collider2D col) {
        if (col.gameObject.CompareTag("player")) {
            text.enabled = false;
        }
    }
}//end of library trigger

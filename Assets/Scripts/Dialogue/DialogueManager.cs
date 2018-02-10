using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour {
    public GameObject diaBox;
    public Text diaText;
    public bool diaActive = false;

    private void Start() {
        diaBox.SetActive(false);
    }

    private void Update() {
        //if currently in dialogue mode and player presses space
        //deactivate dialogue mode
        if (diaActive && Input.GetKeyDown(KeyCode.X)) {
            HideBox();
        }
    }

    public void ShowBox() {
        diaActive = true;
        diaBox.SetActive(true);
    }

    public void HideBox() {
        diaActive = false;
        diaBox.SetActive(false);
    }

    public void ShowDialogue(string dialogue) {
        diaText.text = dialogue;
    }

}//end of class

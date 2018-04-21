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

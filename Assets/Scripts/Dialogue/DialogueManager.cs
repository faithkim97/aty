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
        if (diaActive && Input.GetKeyUp(KeyCode.Space)) {
            diaActive = false;
            diaBox.SetActive(false);
        }
    }

    public void ShowBox() {
        diaActive = true;
        diaBox.SetActive(true);
    }


    /*
    //put this in dialogueHolder--attached to the NPC 
    private void OnTriggerStay2D(Collider2D collision) {
        Debug.Log("in trigger of dialogue");
        //if dialogue triggered and player presses space
        //activate dialogue box
        if (collision.gameObject.name == "diaTrigger" && Input.GetKeyUp(KeyCode.Space)) {
            diaActive = true;
            diaBox.SetActive(true);
        }
    } */


}

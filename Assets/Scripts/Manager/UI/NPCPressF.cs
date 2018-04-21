using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPCPressF : MonoBehaviour {
    public AudioClip changeMusic;
    public Text pressF;
    private DialogueManager dMan;
    private SoundManager soundManager;
    private bool triggered = false;
    private void Start() {
        dMan = GameObject.FindObjectOfType<DialogueManager>();
    }
    private void OnTriggerEnter2D(Collider2D collision) {

        if (collision.gameObject.CompareTag("player")) {
            pressF.enabled = true;
            if (gameObject.CompareTag("bri")) {
                soundManager.setSoundClip(changeMusic);
                soundManager.setVolume(1.0f);
                soundManager.getSound().Play();
            }
        }
    }//end of trigger enter

    private void Update() {
        soundManager = GameObject.FindObjectOfType<SoundManager>();
    }

    private void OnTriggerStay2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("player")) {
            if (dMan.diaActive) {
                pressF.enabled = false;
            }
            if (dMan.diaActive && gameObject.CompareTag("hope")) {
                 soundManager.FadeOutAudio();
            }
            else if (!dMan.diaActive) {
                soundManager.FadeInAudio();
            }
        }//end of if player


    }//end of stay

    private void OnTriggerExit2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("player")) {
            pressF.enabled = false;
        }
    }//end of exit

}//end of NPCPressF

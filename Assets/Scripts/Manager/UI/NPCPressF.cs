using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPCPressF : MonoBehaviour {
    public AudioClip changeMusic;
    public Text pressF;
    private DialogueManager dMan;
    private SoundManager soundManager;
    private void Start() {
        dMan = GameObject.FindObjectOfType<DialogueManager>();
        soundManager = GameObject.FindObjectOfType<SoundManager>();
    }
    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("player")) {
            pressF.enabled = true;
        }
    }

    private void OnTriggerStay2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("player")) {
            if (dMan.diaActive) {
                soundManager.FadeOutAudio();
                pressF.enabled = false;
            }

            if (gameObject.CompareTag("bri")) {
                soundManager.setVolume(0.0f);
                soundManager.setSoundClip(changeMusic);
                soundManager.setVolume(1.0f);
                soundManager.getSound().Play();
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

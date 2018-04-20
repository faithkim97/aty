using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanicAttackTrigger : MonoBehaviour {
    ScreenShake ss;
    private bool triggered = false;
    private void Start() {
        ss =  GameObject.FindObjectOfType<ScreenShake>();
        gameObject.SetActive(true);
    }

    private void Update() {
        if (triggered && ss != null && ss.getShakeTimer() <= 0.5f) {
            triggered = false;
            gameObject.SetActive(false);
        }
    }
    private void OnTriggerStay2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("player")) {
            triggered = true;
            if (ss != null) { ss.ShakeScreen(true); }
        }
    }
}//end of PanicAttackTrigger

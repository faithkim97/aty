using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanicAttackTrigger : MonoBehaviour {
    ScreenShake ss;
    private void Start() {
        ss =  GameObject.FindObjectOfType<ScreenShake>();
        gameObject.SetActive(true);
    }

    private void Update() {
        if (ss != null && ss.getShakeTimer() <= 0.5f) {
            Debug.Log("inside get shake timer of panic attack");
            gameObject.SetActive(false);
        }
    }
    private void OnTriggerStay2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("player")) {
            if (ss != null) { ss.ShakeScreen(true); }
        }
    }
}//end of PanicAttackTrigger

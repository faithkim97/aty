using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanicAttackTrigger : MonoBehaviour {
    private void OnTriggerStay2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("player")) {
            ScreenShake.ShakeScreen(true);
        }
    }
}//end of PanicAttackTrigger

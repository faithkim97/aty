using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// keeps track of pill dosages in-game
/// </summary>
public class PillTimer : MonoBehaviour {
    [SerializeField]
    private float pillTimerTwoDosage = 10.0f;
    [SerializeField]
    private float pillTimerThreeDosage = 15.0f;
    void FixedUpdate () {
        //healthy dosage
        if (GameManager.getCoinCount() <=2 && GameManager.getCoinCount() > 0) {
            pillTimerTwoDosage -= Time.deltaTime;
        }
        else if (GameManager.getCoinCount() == 3) {
            pillTimerThreeDosage -= Time.deltaTime;
        }

        if (pillTimerTwoDosage <= 0.0f) {
            pillTimerTwoDosage = 10.0f;
            GameManager.setCoinCount(0);
        }
        if (pillTimerThreeDosage <= 0.0f) {
            pillTimerThreeDosage = 15.0f;
            GameManager.setCoinCount(0);
        }
	}
}

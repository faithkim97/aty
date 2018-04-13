using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class Timer : MonoBehaviour {
    private Text timerText;
    [SerializeField]
    private float timer;
    private float originalTimer;

    private void Start() {
        timerText = gameObject.GetComponent<Text>();
        if (timer != 0.0f) { originalTimer = timer; }
    }
    // Update is called once per frame
    void Update () {
        ShowTimer();
        CountdownTimer();
	}

    private void CountdownTimer() {
        timer -= Time.deltaTime;
        if (timer <= 0.0f) {
            ResetTimer();
        }
    }
    private void ShowTimer() {
        timerText.text = "Time left: " + timer.ToString();
    }

    public void ResetTimer() {
        timer = originalTimer; 
    }
}

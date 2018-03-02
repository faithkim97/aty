﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour {
    private static bool exhausted = false;

    private void FixedUpdate() {
        if (exhausted) {
            setDifficulty();
            exhausted = false;
        }
    }

    public static bool getExhausted() {
        return exhausted;
    }

    public static void setExhausted(bool setBool) {
        exhausted = setBool;
    }

    private void setDifficulty() {
        int playerSpeed = PlayerControl.getPlayerSpeed();
        if (playerSpeed < 10) {
            PlayerControl.setPlayerSpeed(playerSpeed + 2);
        }
    }//end of setDifficulty

    private void setLevelScenario() {
        int tiredCount = GameManager.getDeathCount();
        //tiredCount == 3
        //show email from health services
        if (tiredCount == 3) {
            DialogueList dialogueList = GameObject.Find("Health Service email").GetComponent<DialogueList>();
            
        }

        //tiredCount == 4
            //show email from Dean

        //tiredCount == 5
            //get text from Mom 


    }

}//end of LevelManagaer

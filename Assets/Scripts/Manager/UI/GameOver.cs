using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;


public class GameOver : MonoBehaviour {
    private TypeOutScript typeout;
    List<string> gameOverMessage;
    private void Start() {
        typeout = gameObject.GetComponent<TypeOutScript>();
        gameOverMessage = new List<string>();
        addMessages();
        RandomizeMessage();
    }

    //hardcoded messages
    private void addMessages() {
        gameOverMessage.Add("Make sure you aren't becoming \n dependent on one thing. \n \n Rely on yourself.");
        gameOverMessage.Add("The key is patience. Slow and steady are recipes for success.");
        gameOverMessage.Add("It's okay if you can't get \n through the entire day. \n Your efforts are what counts.");
        gameOverMessage.Add("You overexhausted yourself. Things can be a bit overwhelming right ? Take care of yourself.It's going to be okay.");
        gameOverMessage.Add("Remember taking medications is a treatment, but not a cure. \n Watch out for how much to take.");
    }
    public void RandomizeMessage() {
       System.Random rnd = new System.Random();
        if (gameOverMessage.Count > 0) {
            int index = rnd.Next(gameOverMessage.Count);
            typeout.FinalText = gameOverMessage[index];
        }
    }//end of Randomize


}//end of GameOver

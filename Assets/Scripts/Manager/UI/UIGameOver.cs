using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// UI for game over text 
/// </summary>
public class UIGameOver : UIManager {
	public Text gameOver;	
	// Update is called once per frame
	void Update () {
        SetDeathText(gameOver);
	}
}

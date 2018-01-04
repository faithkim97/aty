using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// Used to manage all UI stuff like coin counter, death counter
/// handles all visual aspect of the game (menus, etc.) 
/// </summary>
public class UIManager : MonoBehaviour {
	/*
	public Text coinText; 
	public Text deathText;

	void Update() {
		SetCoinText ();
		SetDeathText ();
	} */
	public void SetCoinText(Text coinText) {
		coinText.text = "Coins: " + GameManager.getCoinCount ();
	}

	public void SetDeathText(Text deathText) {
		deathText.text = "Deaths: " + GameManager.getDeathCount ();
	}

	public void GameOver(Text text) {
		string time = GameManager.getDeathCount () > 1 ? "times" : "time";
		Debug.Log (time);
		text.text = "Game Over. You died " + GameManager.getDeathCount () + " " + time.ToString(); 
	}
}

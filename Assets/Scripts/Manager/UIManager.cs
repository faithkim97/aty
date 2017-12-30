using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// Used to manage all UI stuff like coin counter, death counter
/// handles all visual aspect of the game (menus, etc.) 
/// </summary>
public class UIManager : MonoBehaviour {
	public Text coinText; 
	public Text deathText;

	void Update() {
		SetCoinText ();
		SetDeathText ();
	}
	void SetCoinText() {
		coinText.text = "Coins: " + GameManager.getCoinCount ();
	}

	void SetDeathText() {
		deathText.text = "Deaths: " + GameManager.getDeathCount ();
	}
}

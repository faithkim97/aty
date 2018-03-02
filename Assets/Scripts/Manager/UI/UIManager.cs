using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// Used to manage all UI stuff like coin counter, death counter
/// handles all visual aspect of the game (menus, etc.) 
/// </summary>
public class UIManager : MonoBehaviour {
	public void SetCoinText(Text coinText) {
		coinText.text = "Coins: " + GameManager.getCoinCount ();
	}

	public void SetDeathText(Text deathText) {
		deathText.text = "Day: " + GameManager.getDeathCount ();
	}

}

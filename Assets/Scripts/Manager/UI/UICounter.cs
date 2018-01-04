using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UICounter : UIManager {
	public Text coinText; 
	public Text deathText;
	// Update is called once per frame
	void Update () {
		SetCoinText (coinText);
		SetDeathText (deathText);
	}
}

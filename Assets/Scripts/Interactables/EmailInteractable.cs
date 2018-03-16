using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Makes UI of emails/texts interactable 
/// </summary>
public class EmailInteractable : MonoBehaviour {	
	// Update is called once per frame
	void Update () {
		Interact();
	}

	void Interact() {
		Image emailImage = gameObject.GetComponent<Image> ();
		if (Input.GetKeyDown(KeyCode.X)) {
			emailImage.enabled = false;
		} 
		if (Input.GetKeyDown (KeyCode.E)) {
			emailImage.enabled = true;
		}
	}
}//end of EmailInteractable

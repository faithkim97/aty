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
            if (gameObject.transform.childCount >= 1) {
                gameObject.transform.GetChild(0).GetComponent<Text>().enabled = false;
            }
		} 
	}//end of Interact

  
}//end of EmailInteractable

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Makes UI of emails/texts interactable 
/// </summary>
public class EmailInteractable : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		//if x, then exit
		if (Input.GetKeyDown(KeyCode.X)) {
			Image emailImage = gameObject.GetComponent<Image> ();
			emailImage.enabled = false;
		} 
	}
}//end of EmailInteractable

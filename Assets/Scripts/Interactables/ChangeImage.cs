using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// transitions the sprite image from one to the other
/// </summary>
public class ChangeImage : MonoBehaviour {
	public Sprite changeTo; 
	private SpriteRenderer sr;
	private GameObject parent;
	void Start() {
		parent = transform.parent.gameObject;
		sr = parent.GetComponent<SpriteRenderer> ();
	}


	void OnTriggerEnter2D(Collider2D col) {
		//if triggered, then change the bombs to other image 
		if (col.gameObject.CompareTag("player")) {
			ChangeSprite();
		}//end of if

	}

	void ChangeSprite() {
		Debug.Log ("inside change sprite");
		sr.sprite = changeTo;
	}
}

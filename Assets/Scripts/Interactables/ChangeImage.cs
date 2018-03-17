using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// transitions the sprite image from one to the other
/// </summary>
public class ChangeImage : MonoBehaviour {
	public Sprite changeTo; 
	private SpriteRenderer sr;
	bool triggered = false;

	void Start() {
		GameObject parent = transform.parent.gameObject;
		sr = parent.GetComponent<SpriteRenderer> ();
	}

//	void Update() {
//		if (triggered) {
//			FadeSprite ();
//		}
//	}

	void OnTriggerEnter2D(Collider2D col) {
		//if triggered, then change the bombs to other image 
		if (col.gameObject.CompareTag("player")) {
			Debug.Log ("triggered");
			//triggered = true;
			StartCoroutine(FadeSprite());
		}//end of if

	}

	private IEnumerator FadeSprite() {
		//sr.sprite = changeTo;
		Color tmp = sr.color; 
		tmp.a = 1.0f;
		//fade out
		for (float i = 1.0f; i >= 0.0f; i -= 0.05f) {
			sr.color = tmp;
			tmp.a -= i;
			yield return null;
		}
		sr.sprite = changeTo;
		tmp.a = 0.0f;
		//fade in 
		for (float i = 0.0f; i <= 1.0f; i += 0.05f) {
			sr.color = tmp;
			tmp.a += i;
			yield return null;
		}
		//triggered = false;
	}//end of FadeSprite
}

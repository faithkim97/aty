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

	void OnTriggerEnter2D(Collider2D col) {
		//if triggered, then change the bombs to other image 
		if (GameManager.getDeathCount() >= 3 && col.gameObject.CompareTag("player")) {
			StartCoroutine(FadeSprite());
		}//end of if

	}

	private IEnumerator FadeSprite() {
		//sr.sprite = changeTo;
		Color tmp = sr.color;
		//fade out
		for (float i = tmp.a; i > 0.0f; i -= 0.05f) {
            sr.color = tmp;
			tmp.a = i;
            yield return null;
		}
		sr.sprite = changeTo;
		tmp.a = 0.0f;
		//fade in 
		for (float i = tmp.a; i <= 1.0f; i += 0.05f) {
			sr.color = tmp;
			tmp.a = i;
			yield return null;
		} 
	}//end of FadeSprite
}

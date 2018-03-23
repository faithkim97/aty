using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObject : MonoBehaviour {
	///number of steps to take to move left and right
	[SerializeField]
	private int numSteps = 5; 

	[SerializeField]
	private float moveSpeed;
	// Update is called once per frame
	void Update () {
		TranslateObject ();
	}

	public void TranslateObject() {
		StartCoroutine(MoveRight ());
		StartCoroutine(MoveLeft ());
	}

	private IEnumerator MoveRight() {
		Debug.Log ("inside move right");
		for (int i = 0; i < numSteps; i++) {
			gameObject.transform.position = new Vector3 (gameObject.transform.position.x + moveSpeed, gameObject.transform.position.y, gameObject.transform.position.z);
			yield return null;
		}//end of for 
	}//end of MoveRight() 

	private IEnumerator MoveLeft() {
		Debug.Log ("inside moveLeft()");
		for (int i = 0; i < numSteps; i++) {
			gameObject.transform.position = new Vector3 (gameObject.transform.position.x - moveSpeed, 
				gameObject.transform.position.y, gameObject.transform.position.z);
			yield return null;
		}//end of for loop
	}//end of MoveLeft()
}

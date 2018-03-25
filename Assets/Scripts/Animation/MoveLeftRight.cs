using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeftRight: MonoBehaviour {
	///number of steps to take to move left and right
	[SerializeField]
	private int numSteps = 5; 

	[SerializeField]
	private float moveSpeed;

    private bool dead = false;
    // Update is called once per frame
    IEnumerator Start () {
        while (true) {
            yield return StartCoroutine(MoveRight());
            yield return StartCoroutine(MoveLeft());
        }
    }

	private IEnumerator MoveRight() {
		//Debug.Log ("inside move right");
		for (float i = 0.0f; i < numSteps; i += Time.deltaTime) {
            Debug.Log("i = " + i);
			gameObject.transform.position = new Vector3 (gameObject.transform.position.x + moveSpeed *Time.deltaTime , gameObject.transform.position.y, gameObject.transform.position.z);
            yield return new WaitForSeconds(0.05f);
		}//end of for        
    }//end of MoveRight() 

	private IEnumerator MoveLeft() {
        for (float i = 0.0f; i < numSteps; i += Time.deltaTime) {
            gameObject.transform.position = new Vector3(gameObject.transform.position.x - moveSpeed * Time.deltaTime,
                gameObject.transform.position.y, gameObject.transform.position.z);
            yield return new WaitForSeconds(0.05f);
        }//end of for loop
    }//end of MoveLeft()
}

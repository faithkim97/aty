using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveXposition: MonoBehaviour {
    ///number of steps to take to move left and right
    [SerializeField]
    private float numRSteps;
    [SerializeField]
    private float numLSteps;

	[SerializeField]
	private float moveSpeed;

    private bool dead = false;

    public bool startLeft;
    public bool startRight;

    // Update is called once per frame
    IEnumerator Start () {
        if (startLeft) {
            yield return StartCoroutine(MoveLeftRight());
        }
        else if (startRight) {
            yield return StartCoroutine(MoveRightLeft());
        }
        
    }

    private IEnumerator MoveLeftRight() {
        yield return StartCoroutine(MoveLeft());
        yield return StartCoroutine(MoveRight());
    }

    private IEnumerator MoveRightLeft() {
        while (true) {
            yield return StartCoroutine(MoveRight());
            yield return StartCoroutine(MoveLeft());
        }
    }
	private IEnumerator MoveRight() {
		//Debug.Log ("inside move right");
		for (float i = 0.0f; i < numRSteps; i += Time.deltaTime) {
			gameObject.transform.position = new Vector3 (gameObject.transform.position.x + moveSpeed *Time.deltaTime , gameObject.transform.position.y, gameObject.transform.position.z);
            yield return new WaitForSeconds(0.05f);
		}//end of for        
    }//end of MoveRight() 

	private IEnumerator MoveLeft() {
        for (float i = 0.0f; i < numLSteps; i += Time.deltaTime) {
            gameObject.transform.position = new Vector3(gameObject.transform.position.x - moveSpeed * Time.deltaTime,
                gameObject.transform.position.y, gameObject.transform.position.z);
            yield return new WaitForSeconds(0.05f);
        }//end of for loop
    }//end of MoveLeft()
}

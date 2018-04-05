using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveYpos : MonoBehaviour {

    private Rigidbody2D rb;

    public  float numSteps = 0.0f;
    public float moveSpeed;



    private IEnumerator Start() {
        while (true) {
            yield return StartCoroutine(MoveUp());
            yield return StartCoroutine(MoveDown());
        }
    }

    public IEnumerator MoveUp() {
        //Debug.Log ("inside move right");
        for (float i = 0.0f; i < numSteps; i += Time.deltaTime) {
            gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + moveSpeed * Time.deltaTime, gameObject.transform.position.z);
            yield return new WaitForSeconds(0.05f);
        }//end of for      
    }

    public IEnumerator MoveDown() {
        for (float i = 0.0f; i < numSteps; i += Time.deltaTime) {
            gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y - moveSpeed * Time.deltaTime, gameObject.transform.position.z);
            yield return new WaitForSeconds(0.05f);
        }//end of for  
    }



}//end of MoveYpos

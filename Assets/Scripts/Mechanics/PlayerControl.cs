using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
/// <summary>
/// prototype 
/// script for player controls 
/// </summary>
public class PlayerControl : MonoBehaviour {
    [SerializeField]
    private int playerSpeed = 10;
    [SerializeField]
    private int jumpPower = 1000;
    private float moveX;
    private bool facingRight = false;

    private void Start() {
        gameObject.GetComponent<Rigidbody2D>().freezeRotation = true;
    }

    private void Update() {
        movePlayer();
    }

    void movePlayer() {
        //controls
        moveX = Input.GetAxis("Horizontal");
        //player direction 
        //player movement 
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(moveX * playerSpeed, gameObject.GetComponent<Rigidbody2D>().velocity.y);
        //jump
        if (Input.GetKeyDown(KeyCode.Space)) {
            jump();
        }//end of if
    }//end of movePlayer

    void jump() {
        gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * jumpPower);
    }//end of jump

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.CompareTag("coin")) {
			GameManager.incCoinCount();
            GameManager.decreaseTunnelHeight(GameObject.Find("Top"));
            GameManager.decreaseTunnelHeight(GameObject.Find("Bottom"));
            GameObject.Destroy(other.gameObject);
        } 
        else if ( other.gameObject.CompareTag("obstacle")) {
			GameObject.Destroy (other.gameObject);
            GameManager.increaseTunnelHeight(GameObject.Find("Top"));
            GameManager.increaseTunnelHeight(GameObject.Find("Bottom"));
            if (GameManager.getCoinCount() == 0) {
                GameManager.incDeathCount();
                //game over scene 
                GameManager.Instance.LoadScene(1);
            }
            GameManager.decCoinCount ();
        }
    }


    //add flip player code

}//end of PlayerControl

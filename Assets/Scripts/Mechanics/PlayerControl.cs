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
    private static float playerSpeed = 1.0f;
    [SerializeField]
    private int jumpPower = 1000;
    private float moveX;
    private bool facingRight = false;
	private bool inAir = false;

    private void Start() {
        gameObject.GetComponent<Rigidbody2D>().freezeRotation = true;
    }

    private void Update() {
        movePlayer();
    }

    void movePlayer() {
        //controls
        //hardcode in arrows so that w a s d DOESN'T WORK 
        moveX = Input.GetAxis("Horizontal");
        //player direction 
        //player movement 
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(moveX * playerSpeed, gameObject.GetComponent<Rigidbody2D>().velocity.y);
        //jump
		if (Input.GetKeyDown(KeyCode.Space) && !inAir) {
			inAir = true;
            jump();
        }//end of if
    }//end of movePlayer

	void jump() {
        gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * jumpPower);
    }//end of jump

    private void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.CompareTag ("coin")) {
			GameManager.incCoinCount ();
            if (GameManager.getCoinCount() >= 3) {
                IncreaseTunnel();
            }
            else { DecreaseTunnel(); }
			GameObject.Destroy (other.gameObject);
		} 
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.CompareTag("obstacle")) {
            GameObject.Destroy(other.gameObject);
            IncreaseTunnel();
            GameManager.decCoinCount();
        }

		if (other.gameObject.CompareTag ("ground")) {
			inAir = false;
		}
    }

  /*  void GameOver() {
        GameManager.incDeathCount();
        //game over scene 
        GameManager.Instance.LoadScene(1);
    } */

    void DecreaseTunnel() {
        GameManager.decreaseTunnelHeight(GameObject.Find("Top"));
        GameManager.decreaseTunnelHeight(GameObject.Find("Bottom"));
    }

    void IncreaseTunnel() {
        GameManager.increaseTunnelHeight(GameObject.Find("Top"));
        GameManager.increaseTunnelHeight(GameObject.Find("Bottom"));
    }

    public static float getPlayerSpeed() {
        return playerSpeed;
    }

    public static void setPlayerSpeed(float newSpeed) {
        playerSpeed = newSpeed;
    }

    public int getJumpPower() {
        return jumpPower;
    }

    public void setJumpPower(int newPower) {
        jumpPower = newPower;
    }


    //add flip player code

}//end of PlayerControl

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
  //  [SerializeField]
    private static int jumpPower = 2000;
    private float moveX;
    private bool facingRight = false;
	private bool inAir = false;
    public AudioClip pillSound;
    public AudioClip bombSound;
   
    private void Start() {
        gameObject.GetComponent<Rigidbody2D>().freezeRotation = true;
    }

    private void Update() {
        movePlayer();
        if (GameManager.getCoinCount() >= 5) {
            ScreenShake ss = GameObject.FindObjectOfType<ScreenShake>();
            ss.ShakeScreen(true);
            //if (ss != null) { ss.ShakeScreen(true); }
        }
    }

    void movePlayer() {
        moveX = Input.GetAxis("Horizontal");
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
            AudioSource sound = gameObject.GetComponent<AudioSource>();
            sound.clip = pillSound;
            sound.volume = 1.0f;
            sound.Play();
            if (GameManager.getCoinCount() >= 3) {
                IncreaseTunnel();
            }//end of >=3
            else { DecreaseTunnel(); }
			GameObject.Destroy (other.gameObject);
		} 
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.CompareTag("obstacle")) {
            AudioSource sound = gameObject.GetComponent<AudioSource>();
            sound.clip = bombSound;
            sound.volume = 0.09f;
           sound.Play();
            GameObject.Destroy(other.gameObject);
            IncreaseTunnel();
        }

		if (other.gameObject.CompareTag ("ground")) {
			inAir = false;
		}
    }

    void DecreaseTunnel() {
        GameManager.decreaseTunnelHeight(GameObject.Find("Top"));
        GameManager.decreaseTunnelHeight(GameObject.Find("Bottom"));
    }

    void IncreaseTunnel() {
        GameManager.increaseTunnelHeight(GameObject.Find("Bottom"));
        GameManager.increaseTunnelHeight(GameObject.Find("Top"));
        
    }

    public static float getPlayerSpeed() {
        return playerSpeed;
    }

    public static void setPlayerSpeed(float newSpeed) {
        playerSpeed = newSpeed;
    }

    public static int getJumpPower() {
        return jumpPower;
    }

    public static void setJumpPower(int newPower) {
        jumpPower = newPower;
    }

}//end of PlayerControl

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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
  
    private void Update() {
        movePlayer();
    }

    void movePlayer() {
        //controls
        moveX = Input.GetAxis("Horizontal");
        //player direction 
        //player movement 
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(moveX * playerSpeed, gameObject.GetComponent<Rigidbody2D>().velocity.y);

    }//end of movePlayer
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// attached to camera gameobject
/// makes screen shake
/// external source: https://www.youtube.com/watch?v=m8svlFB7-uo
/// </summary>
public class ScreenShake : MonoBehaviour {

	public Vector2 velocity;
	public float smoothTimeY;
	public float smoothTimeX;

	public GameObject player;

	private float shakeTimer = 5.0f;
    public float originalTimer;
	[SerializeField] 
	private float shakeAmount;

    private bool shake = false;
    private void Start() {
        //originalTimer = shakeTimer;
    }
    void FixedUpdate(){
        
        if (shake) {
            float posX = Mathf.SmoothDamp(transform.position.x, player.transform.position.x, ref velocity.x, smoothTimeX);
            float posY = Mathf.SmoothDamp(transform.position.y, player.transform.position.y, ref velocity.y, smoothTimeY);

            transform.position = new Vector3(posX, posY, transform.position.z);
        }
	}

	void Update() {
        
		if (shake && shakeTimer > 0 ) {
            PlayerControl();
            ShakeScreen();
		}

        if (shake && shakeTimer <= 0) {
            shake = false;
            StabilizeCameraPosition();
            shakeTimer = originalTimer;
           
        }
	
	}

    private void StabilizeCameraPosition() {
        gameObject.transform.position = gameObject.GetComponent<CameraMovement>().CameraPosition();
    }
	public void ShakeCamera(float shakePower, float shakeDuration) {
        shake = true;
		shakeAmount = shakePower;
		shakeTimer = shakeDuration;
	
	}//end of ShakeCamera

    public  void setShakeTimer(float newTimer) {
        shakeTimer = newTimer;
    }

    public void setShakeAmount(float newshakeAmount) {
        shakeAmount = newshakeAmount;
    }

    public float getShakeTimer() {
        return shakeTimer;
    }

    private void PlayerControl() {
        bool keyPressed = Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.UpArrow)
                               || Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.DownArrow) 
                              || Input.GetKey(KeyCode.LeftArrow);
        if (shake && keyPressed) {
            shakeTimer = originalTimer;
            GameManager.increaseTunnelHeight(GameObject.Find("Top"));
            GameManager.increaseTunnelHeight(GameObject.Find("Bottom"));
        }
    }

    private void ShakeScreen() {
        Vector2 shakePos = Random.insideUnitCircle * shakeAmount;
        transform.position = new Vector3(transform.position.x + shakePos.x, transform.position.y + shakePos.y, transform.position.z);
        shakeTimer -= Time.deltaTime;
    }

    public void ShakeScreen(bool shakeScreen) {
        shake = shakeScreen;
    }

    public bool getShake() {
        return shake;
    }

    public void ResetShake() {
        shakeTimer = originalTimer;
    }



}//end of class

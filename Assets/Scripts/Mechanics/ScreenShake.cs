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

	[SerializeField] 
	private float shakeTimer; 
	[SerializeField] 
	private float shakeAmount;

	void FixedUpdate(){
		float posX = Mathf.SmoothDamp(transform.position.x, player.transform.position.x, ref velocity.x, smoothTimeX);
		float posY = Mathf.SmoothDamp(transform.position.y, player.transform.position.y, ref velocity.y, smoothTimeY);

		transform.position = new Vector3 (posX, posY, transform.position.z);

		if (Input.GetKeyDown(KeyCode.F)) {
			ShakeCamera (0.1f, 1.0f);
		}
	}

	void Update() {
		if (shakeTimer >= 0) {
			Vector2 shakePos = Random.insideUnitCircle * shakeAmount;
			transform.position = new Vector3 ( transform.position.x + shakePos.x, transform.position.y + shakePos.y, transform.position.z);
			shakeTimer -= Time.deltaTime;
		}
	
	}

	public void ShakeCamera(float shakePower, float shakeDuration) {
		shakeAmount = shakePower;
		shakeTimer = shakeDuration;
	
	}//end of ShakeCamera



}//end of class

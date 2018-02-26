using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {
    public GameObject player;
    [SerializeField]
    private float offset;
    [SerializeField]
    private float offsetSmoothing;
    private Vector3 playerPos;

    void Update() {
        //transform.position = new Vector2(player.transform.position.x + offset.x, player.transform.position.y +offset.y);
        playerPos = new Vector3(player.transform.position.x, transform.position.y, transform.position.z);
        if (player.transform.localScale.x > 0.0f) {
            playerPos = new Vector3(playerPos.x + offset, playerPos.y, playerPos.z);
        }
        else {
            playerPos = new Vector3(playerPos.x - offset, playerPos.y, playerPos.z);
        }
        transform.position = Vector3.Lerp(transform.position, playerPos, offsetSmoothing * Time.deltaTime);
    }

    public Vector3 CameraPosition() {
        return gameObject.transform.position; 
    }
}

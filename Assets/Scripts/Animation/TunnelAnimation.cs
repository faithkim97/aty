using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TunnelAnimation : MonoBehaviour {
    [SerializeField]
    [HideInInspector]
    private static float tunnelHeight = 0.0f; 
    private static TunnelAnimation instance; 
    public static TunnelAnimation Instance {
        get {
            if (instance == null) {
                instance = FindObjectOfType<TunnelAnimation>();
            }
            return instance; 
        }

        private set {
            instance = value;
        }
    }

    private void Start() {
        //if player dies at least once, then save the tunnel heights from last gameplay
        if (GameManager.getDeathCount() > 0 && tunnelHeight != 0.0f) {
            GameObject tunnel = GameObject.Find("Top");
            GameObject bottomTunnel = GameObject.Find("Bottom");
            RectTransform topRect = tunnel.GetComponent<RectTransform>();
            RectTransform bottomRect = bottomTunnel.GetComponent<RectTransform>();
            topRect.sizeDelta = new Vector2(topRect.sizeDelta.x, tunnelHeight);
            bottomRect.sizeDelta = new Vector2(bottomRect.sizeDelta.x, tunnelHeight);
        }     
    }


    public void StartIncreaseTunnel( float height, GameObject tunnel ) {
        tunnelHeight = height;
        StartCoroutine(AnimateIncreaseTunnel( tunnel));
    }

    private IEnumerator AnimateIncreaseTunnel( GameObject tunnel) {
        Debug.Log("working");
        RectTransform tunnelRect = tunnel.GetComponent<RectTransform>();
        for (float currHeight = tunnelRect.sizeDelta.y; currHeight <= tunnelHeight; currHeight += .5f) {
            tunnelRect.sizeDelta = new Vector2(tunnelRect.sizeDelta.x, currHeight);
            yield return null;
        }
    }

    //create AnimateDecreaseTunnel function
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TunnelAnimation : MonoBehaviour {
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

    public void StartTunnel( float height, GameObject tunnel ) {
        StartCoroutine(AnimateTunnel(height, tunnel));
    }

    private IEnumerator AnimateTunnel(float height, GameObject tunnel) {
        Debug.Log("working");
        RectTransform tunnelRect = tunnel.GetComponent<RectTransform>();
        for (float currHeight = tunnelRect.sizeDelta.y; currHeight <= height; currHeight += .5f) {
            tunnelRect.sizeDelta = new Vector2(tunnelRect.sizeDelta.x, currHeight);
            yield return null;

        }
       
    }
}

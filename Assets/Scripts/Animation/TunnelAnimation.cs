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

    public void StartTunnel( float height ) {
        StartCoroutine(AnimateTunnel(height));
    }

    private IEnumerator AnimateTunnel(float height) {
        Debug.Log("working");
        yield return null;
    }
}

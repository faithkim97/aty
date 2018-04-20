using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Animates the tunnel's height
/// </summary>
public class TunnelAnimation : MonoBehaviour {
    /// <summary>
    /// keeps track and saves height of the tunnel
    /// </summary>
    [SerializeField]
    [HideInInspector]
    private static float tunnelHeight = 0.0f;
    /// <summary>
    /// Creates an instance of TunnelAnimation
    /// </summary>
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

    /// <summary>
    /// starts coroutine for increase animation
    /// </summary>
    /// <param name="height">height of the tunnel it must be</param>
    /// <param name="tunnel"> gameobject tunnel that is being passed</param>
    public void StartIncreaseTunnel( float height, GameObject tunnel ) {
        
        tunnelHeight = height;
        StartCoroutine(AnimateIncreaseTunnel( tunnel));
    }
    /// <summary>
    /// starts decrease animation coroutine
    /// </summary>
    /// <param name="height">height the tunnel must be at the end of animation</param>
    /// <param name="tunnel">tunnel gameobject being passed in</param>
    public void StartDecreaseTunnel(float height, GameObject tunnel) {
        tunnelHeight = height;
        StartCoroutine(AnimateDecreaseTunnel(tunnel));
    }

    private IEnumerator AnimateDecreaseTunnel(GameObject tunnel) {

       // BoxCollider2D tunnelTrigger = tunnel.GetComponent<BoxCollider2D>();
        //change size of tunnel
        RectTransform tunnelRect = tunnel.GetComponent<RectTransform>();
        for (float currHeight = tunnelRect.sizeDelta.y; currHeight > tunnelHeight; currHeight -= .5f) {
            tunnelRect.sizeDelta = new Vector2(tunnelRect.sizeDelta.x, currHeight);
            //tunnelTrigger.size = new Vector2(tunnelTrigger.size );
            yield return null;
        }
    }

    private IEnumerator AnimateIncreaseTunnel( GameObject tunnel) {

        BoxCollider2D tunnelTrigger = tunnel.GetComponent<BoxCollider2D>();
        //used to change size of the tunnel
        RectTransform tunnelRect = tunnel.GetComponent<RectTransform>();
        float startHeight = tunnelRect.sizeDelta.y;
        for (float currHeight = startHeight; currHeight < tunnelHeight; currHeight += .5f) {
            Debug.Log(tunnel.gameObject.tag + " startHeight: " + startHeight + " tunnelHeight: " + tunnelHeight);
            //Debug.Log(tunnel.gameObject.tag + " height: " + tunnelRect.sizeDelta.y);
            tunnelRect.sizeDelta = new Vector2(tunnelRect.sizeDelta.x, currHeight);
            tunnelTrigger.size = new Vector2(tunnelRect.sizeDelta.x, currHeight);
            yield return null;
        }
    }
    /// <summary>
    /// if tunnels touch, then game over
    /// </summary>
    /// <param name="collision"></param>
    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("bottom") ) {
			GameManager.GameOver ();
        }
        
    }//end of on trigger enter
		


}//end of class



 

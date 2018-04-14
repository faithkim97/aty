using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {
    private AudioSource sound;
    private GameManager gManager;

    private void Awake() {
        DontDestroyOnLoad(gameObject);
        sound = gameObject.GetComponent<AudioSource>();
      
    }//end of Awake

    private void Update() {
        if (FindObjectsOfType(GetType()).Length > 1 && sound.volume <= 0.0f) {
            Destroy(gameObject);
        }
    }
    // Use this for initialization
    void Start () {
        
        gManager = GameObject.FindObjectOfType<GameManager>();
	}

    public void FadeOutAudio() {
        StartCoroutine(FadeOut());
    }

    private IEnumerator FadeOut() {
        while (sound.volume > 0.0f) {
            sound.volume -= 0.1f;
            Debug.Log("sound.volume: " + sound.volume);
            yield return null;
        }
      /*  for (float i = sound.volume;  i >= 0.0f; i -= 0.01f) {
            sound.volume = sound.volume 
            //sound.volume = volume;
            Debug.Log("sound.volume in fadeout: " + sound.volume);
            yield return new WaitForSeconds(0.5f);
        }*/
    }
}//end of AudioManager

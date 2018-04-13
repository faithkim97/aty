using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {
    private AudioSource sound; 
	// Use this for initialization
	void Start () {
        sound = gameObject.GetComponent<AudioSource>();	
	}

    public void FadeOutAudio() {
        StartCoroutine(FadeOut());
    }

    private IEnumerator FadeOut() {
        float volume = sound.volume;
        for (float i = 1.0f;  i >= 0.0f; i -= 0.1f) {
            volume -= i;
            sound.volume = volume;
            yield return null;
        }
    }
}//end of AudioManager

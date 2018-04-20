using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class DormTrigger : MonoBehaviour {
    private SoundManager sm;
    public Image fade;

    private void Awake() {
        Color temp = fade.color;
        temp.a = 0.0f;
        fade.color = temp;
    }
    private void Start() {
        sm = GameObject.FindObjectOfType<SoundManager>();
    }
    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("player") && sm != null) {
            Debug.Log("inside trigger");
            sm.FadeOutAudio();
            FadeOutScene();
        }
    }//end of trigger

    private void Update() {
        sm = GameObject.FindObjectOfType<SoundManager>();
        if (fade.color.a >= 1.0f) {
            SceneManager.LoadScene(3);
        }
    }

    public void FadeOutScene() {
        sm.FadeOutAudio();
        StartCoroutine(StartFade());
    }

    IEnumerator StartFade() {
        Color temp = fade.color;
        for (float i = 0.0f; i <= 1.0f; i += 0.1f) {
            temp.a += i;
            fade.color = temp;
            yield return new WaitForSeconds(0.1f);
        }
    }


}//end of DormTrigger

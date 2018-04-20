using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour {
    public GameObject menu;
	// Update is called once per frame
	void FixedUpdate () {
        if (Input.GetKeyDown(KeyCode.H)) {
            menu.SetActive(true);
        }
	}
}

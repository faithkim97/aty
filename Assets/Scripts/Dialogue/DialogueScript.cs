using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueScript : MonoBehaviour {
    //private List<List<string>> dialogues = new List<List<string>>();
    // Use this for initialization
    Dictionary<string, List<string>> dialogues = new Dictionary<string, List<string>>();
    private void Awake() {
        setHealthEmail();
        setDeanEmail();

    }

    public Dictionary<string, List<string>> getDialogues() {
        return dialogues;
    }

    //index 0
    private void setHealthEmail() {
        List<string> currDia = new List<string>();
        currDia.Add("You received an email");
        currDia.Add("It's from Health Services");
        dialogues.Add("health", currDia);
    }

    //index 1
    private void setDeanEmail() {
        List<string> currDia = new List<string>();
        currDia.Add("You received an email");
        currDia.Add("it's from Dean White");
        dialogues.Add("dean", currDia);
    }
}//end of DialogueScript

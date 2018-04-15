using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Credits : MonoBehaviour {
    //should i make it animate?
    //private TypeOutScript typeout;
    LoadSceneOnClick load;
    private Text creditText;
    private List<string> creditList;
    // Use this for initialization
    void Start() {
        load = gameObject.GetComponent<LoadSceneOnClick>();
        creditList = new List<string>();
        creditText = gameObject.GetComponent<Text>();
        AddCredits();
        StartCredits();

    }//end of start


    //hardcoded
    public void AddCredits() {
        creditList.Add("Always remember that no matter where you are in life, everything will be okay.");
        creditList.Add("And it's okay to admit that you aren't at this moment.");
        creditList.Add("Be honest with yourself.");
        creditList.Add("Take care of yourself.");
        creditList.Add("Thank you for playing");
        creditList.Add("Brought to you by: Paradox Production");
        creditList.Add("Opening and Credit Music: Threnody by Soularfair");
        creditList.Add("Main music: Battle Theme by Komiku");
        creditList.Add("Raven Gomez - Writer");
        creditList.Add("Jasmine Olivarez - Writer & Artist");
        creditList.Add("Arabia Simeon - Lead Technical Artist");
        creditList.Add("Faith Kim - Programmer");
        creditList.Add("Special thanks to: \n Nicole Bearden for organizing the Nolen Exhibition and making this game a possibility");
        creditList.Add("James Portnow for holding game dev workshops and inspiring us to improve our project");
        creditList.Add("Jennifer Malkowski for advising us for this project");
        creditList.Add("Alison Schoen for organizing the Nolen Exhibition");

    }
    public bool StartCredits() {
        StartCoroutine(PlayCredits());
        return true;
    }

    private IEnumerator PlayCredits() {
        // Debug.Log("inside play credits");
        for (int i = 0; i < creditList.Count; i++) {
            creditText.text = creditList[i];
            yield return new WaitForSeconds(4.5f);
            //if (i == creditList.Count - 1) { load.Quit(); }
        }
        load.Quit();
    }//end of PlayCredits
}
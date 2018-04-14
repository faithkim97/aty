using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

///<summary>
///Manages all global variables that must be tracked and computed throughout gameplay
///</summary>
public class GameManager : MonoBehaviour {
    private static GameManager instance;
	
    public static GameManager Instance {
        get {
            if (instance == null) {
                Instance = FindObjectOfType<GameManager>();
            }
            return instance;
        }
        private set {
            instance = value;
        }
    }

	/// <summary>
	/// The death count.
	/// </summary>
    [SerializeField][HideInInspector]
    private static int deathCount = 0; 
	/// <summary>
	/// The coin count.
	/// </summary>
    [SerializeField][HideInInspector]
    private static int coinCount = 0;
	/// <summary>
	/// All the NPCs in the game 
	/// </summary>
    [SerializeField][HideInInspector]
	private static LinkedList<GameObject> NPCs = new LinkedList<GameObject> ();

  

    ///<summary>
    /// Add NPCs to the list to keep track of them
    /// </summary>
    public static void addNPC( GameObject character ) {
		NPCs.AddLast (character);
	}

	///<summary>
	/// remove NPCs from the list 
	/// </summary>
	public static void removeNPC( GameObject c ) {
		//another condition: once you got to the leaf of the dialogue tree, then execute 
		//or like if the data of the node is null or something? 
		if (NPCs.Contains (c)) {
			NPCs.Remove(c);
		}
	}


    ///<summary>
    ///increment deathCount 
    ///</summary>
    //this will be called in ontriggerenter of playercontrol
    public static void incDeathCount() {
        deathCount++;
        ScreenShake ss = GameObject.FindObjectOfType<ScreenShake>();
        if (ss != null) { ss.ShakeScreen(false); }
    }
    
    ///<summary>
    ///set deathCount to specific value
    ///</summary>
    public static void setDeathCount(int i) {
        deathCount = i;
    }
    ///<summary>
    ///accessor for deathCount
    ///</summary>
    public static int getDeathCount() {
        return deathCount;
    }
    
    ///<summary>
    ///accessor for coinCount
    ///</summary>
    public static int getCoinCount() {
        return coinCount;
    }

	///<summary>
	/// increment coinCount 
	/// </summary>
	public static void incCoinCount() {
		coinCount++;
	}

	///<summary>
	/// set coin count to however amount
	/// </summary>
	public static void setCoinCount(int amount) {
		coinCount = amount;
	}

	///<summary>
	/// decrement coinCount
	/// </summary>
	public static void decCoinCount() {
        if (coinCount >= 1) {
            coinCount--;
        }
	}

    /// <summary>
    /// when player hits an obstacle, tunnel height increases 
    /// </summary>
    /// <param name="tunnel"> tunnel game object found in unity scene </param>
    /// <returns></returns>
    public static float increaseTunnelHeight(GameObject tunnel) {
        RectTransform tunnelRect = tunnel.GetComponent<RectTransform>();
        float height = tunnelRect.sizeDelta.y + 30;
        TunnelAnimation.Instance.StartIncreaseTunnel(height, tunnel);
        return height;
    }

   public static float decreaseTunnelHeight(GameObject tunnel) {
        RectTransform tunnelRect = tunnel.GetComponent<RectTransform>();
        float height = tunnelRect.sizeDelta.y;
        if (coinCount > 0) {
            height = (tunnelRect.sizeDelta.y - 30.0f);
        }
        TunnelAnimation.Instance.StartDecreaseTunnel(height, tunnel);
        return 0.0f;
    } 

    public void LoadScene(int i) {
        SceneManager.LoadScene(i);
    }

	private static void ResetDialogue() {
		GameObject NPC = GameObject.Find ("NPCs");
		foreach (Transform child in NPC.transform) {
			DialogueHolder dHolder = child.GetComponent<DialogueHolder> ();
			if (dHolder != null && !dHolder.enabled) {
				Debug.Log ("inside dHolder");
				dHolder.enabled = true;
			}
		}
	}

	public static void GameOver() {
        //DialogueHolder dHolder = FindObjectOfType<DialogueHolder> ();
        //dHolder.setTriggered (false);
       
        incDeathCount();
        coinCount = 0;
        float volume = ResetMusic();
          if (volume <= 0.2) { Instance.LoadScene(1); }
    }//end of GameOver

    private static float ResetMusic() {
        SoundManager sManager = GameObject.FindObjectOfType<SoundManager>();
        if (sManager != null) {
            sManager.FadeOutAudio();
            float volume = sManager.GetComponent<AudioSource>().volume;
            return volume;
        }
        return 0.0f;
    }

 


 
}//end of GameManager
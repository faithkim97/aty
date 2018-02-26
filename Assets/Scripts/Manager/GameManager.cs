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
	private static bool exhausted = false;
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

    private void FixedUpdate() {
        if (exhausted) {
            setDifficulty();
            exhausted = false;
        }
    }

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
    

	public static bool getExhausted() {
		return exhausted;
	}

	public static void setExhausted(bool setBool) {
		exhausted = setBool;
	}

    
    private void setDifficulty() {
       int playerSpeed = PlayerControl.getPlayerSpeed();
        if (playerSpeed < 10) {
            PlayerControl.setPlayerSpeed(playerSpeed + 2);
        }
    }//end of setDifficulty

    ///<summary>
    ///increment deathCount 
    ///</summary>
    //this will be called in ontriggerenter of playercontrol
    public static void incDeathCount() {
        deathCount++;
        exhausted = true;
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
        float height = tunnelRect.sizeDelta.y;
        if (coinCount >= 1) {
            // tunnelRect.sizeDelta = new Vector2(tunnelRect.sizeDelta.x, tunnelRect.sizeDelta.y * (coinCount + 1));
            height = tunnelRect.sizeDelta.y * (coinCount + 1);
        }
        else {
            //tunnelRect.sizeDelta = new Vector2(tunnelRect.sizeDelta.x, tunnelRect.sizeDelta.y * 2);
            height = tunnelRect.sizeDelta.y * 2;
        }

        TunnelAnimation.Instance.StartIncreaseTunnel(height, tunnel);
        return height;
    }

   public static float decreaseTunnelHeight(GameObject tunnel) {
        RectTransform tunnelRect = tunnel.GetComponent<RectTransform>();
        float height = tunnelRect.sizeDelta.y;
        if (coinCount > 0) {
            height = (tunnelRect.sizeDelta.y / (coinCount + 0.5f));
        }
        TunnelAnimation.Instance.StartDecreaseTunnel(height, tunnel);
        return 0.0f;
    } 

    public void LoadScene(int i) {
        SceneManager.LoadScene(i);
    }


 
}//end of GameManager
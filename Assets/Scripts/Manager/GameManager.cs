using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///<summary>
///Manages all global variables that must be tracked and computed throughout gameplay
///</summary>
public class GameManager : MonoBehaviour {
	/// <summary>
	/// The death count.
	/// </summary>
    private static int deathCount = 0; 
	/// <summary>
	/// The coin count.
	/// </summary>
    private static int coinCount = 0;
	/// <summary>
	/// All the NPCs in the game 
	/// </summary>
	private static LinkedList<GameObject> NPCs = new LinkedList<GameObject> ();
    
    
    //compute tunnel width fxn 


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
		coinCount--;
	}

}//end of GameManager
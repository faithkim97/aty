using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
/// <summary>
/// each dialogue list = list of dialogue one game object will have
/// will also keep track of all serialized dialogue lists
/// attached to gameobject 
/// </summary>
[System.Serializable]
public class DialogueList : MonoBehaviour {
    private List<string> dialogue = new List<string>();

    [SerializeField]
    private int id;

    /// <summary>
    /// list of all saved dialogue list 
    /// key = int id; value = dialogue list 
    /// </summary>
    [SerializeField]
    [HideInInspector]
    private static Dictionary<int, List<string>> savedDialogues = new Dictionary<int, List<string>>();

    public void SaveDialogueList() {
        if (!savedDialogues.ContainsKey(id) && dialogue != null) {
            //Debug.Log("inside saved tree does not contain key");
            savedDialogues.Add(id, dialogue);
      }

        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/savedDialogues.gd");
        bf.Serialize(file, savedDialogues);
        file.Close();
    }

    public Dictionary<int, List<string>> LoadDialogueList() {
        if (File.Exists(Application.persistentDataPath + "/savedDialogues.gd")) {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/savedDialogues.gd", FileMode.Open);
            savedDialogues = (Dictionary<int, List<string>>)bf.Deserialize(file);
            file.Close();
        }

        //DialogueTree.LoadDialogueBranches();
        return savedDialogues;
    }//end of load
    
    //clears dialogue list from hashtable 
    public List<string> ClearDialogue() {
        if ((dialogue != null) && savedDialogues.ContainsValue(dialogue)) {
            savedDialogues.Remove(id);
        }

        return dialogue = null;
    }

    public void setDialogue(string dia) {
        if (dialogue == null) {
            dialogue = new List<string>();
        }
        dialogue.Add(dia);
    }

    public string getDialogue(int id) {
        return dialogue[id];
    }

    public void printDialogues() {
		Dictionary<int, List<string>> savedDialogues = LoadDialogueList();
		List<string> d = savedDialogues [getID()];
        for (int i = 0; i < d.Count; i++) {
            Debug.Log(d[i]);
        }
    }

	public int getID() {

		return id;
	}





}//end of class

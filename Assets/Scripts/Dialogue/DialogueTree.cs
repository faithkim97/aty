using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Keeps track of all dialogues in the style of a binary tree
/// </summary>
public class DialogueTree : MonoBehaviour {
    //current node player dialogue is on
    private DialogueNode currNode;
    //left child of tree
    //left == negative options
    private DialogueNode left;
    //right == positive options
    private DialogueNode right;

    //instance of DialogueTree
    private DialogueTree instance;
    public DialogueTree Instance {
        get {
            if (instance == null) {
                Instance = FindObjectofType<DialogueTree>();
            }
            return instance;
        }

        set {
            instance = value;
        }
    }


    //[Serializable]
    public class DialogueNode {
        /// <summary>
        /// holds dialogue string in data
        /// </summary>
        private string diaData;

        public string getDialogue() {
            return diaData;
        }

        public void setDialogue(string data) {
            diaData = data;
        } 
    }//end of DialogueNode
}

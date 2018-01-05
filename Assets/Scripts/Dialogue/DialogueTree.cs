using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//possibly create boolean value of isSaved = true/false in one of the dialogue scripts
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
                Instance = FindObjectOfType<DialogueTree>();
            }
            return instance;
        }

        set {
            instance = value;
        }
    }

    public bool hasLeft() {
        return left != null;
    }

    public bool hasRight() {
        return right != null;
    }

    public bool isLeaf() {
        return ((left == null) && (right == null));
    }

    public DialogueNode getLeft() {
        return left;
    }

    public DialogueNode getRight() {
        return right;
    }

    public DialogueNode getCurrNode() {
        return currNode;
    }

    public void setCurrNode(DialogueNode newNode) {
        currNode = newNode;
    }

    public void setLeft(DialogueNode node) {
        left = node;
    }

    public void setRight(DialogueNode node) {
        right = node;
    }




    //[Serializable]
    /// <summary>
    /// Each node holds dialogue data
    /// </summary>
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

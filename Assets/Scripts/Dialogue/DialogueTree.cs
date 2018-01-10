using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//possibly create boolean value of isSaved = true/false in one of the dialogue scripts
/// <summary>
/// Keeps track of all dialogues in the style of a binary tree
/// </summary>
public class DialogueTree {
   
    //left child of tree
    //left == negative options
    private DialogueTree left;
    //right == positive options
    private DialogueTree right;

	private string diaData;

    //instance of DialogueTree
 /*   private static DialogueTree instance;
    public static DialogueTree Instance {
        get {
            if (instance == null) {
                Instance = GameObject.FindObjectOfType<DialogueTree>();
            }
            return instance;
        }

        set {
            instance = value;
        }
    }*/

	public DialogueTree() {
		diaData = null;
		left = null;
		right = null;
	}
	public DialogueTree(string data) {
		left = null;
		right = null;
		diaData = data;
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

	public DialogueTree getLeft() {
        return left;
    }

	public DialogueTree getRight() {
        return right;
    }

    public void setLeft(DialogueTree node) {
        left = node;
    }

    public void setRight(DialogueTree node) {
        right = node;
    }

	public string getDialogue() {
		return diaData;
	}

	public void setDialogue(string newDia) {
		diaData = newDia;
	}


	/*
    //[Serializable]
    /// <summary>
    /// Each node holds dialogue data
    /// </summary>
    public class DialogueNode {
        /// <summary>
        /// holds dialogue string in data
        /// </summary>
        private string diaData;

		public DialogueNode( string data ) {
			diaData = data;
		}

        public string getDialogue() {
            return diaData;
        }

        public void setDialogue(string data) {
            diaData = data;
        } 
    }//end of DialogueNode
	*/
}

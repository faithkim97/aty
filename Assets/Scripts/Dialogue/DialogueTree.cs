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
	//dialogue of each node
	private string diaData;
	//id of node to keep track of node
	private int id;
	//keeps track of all user response's association to bool value
	//for which branch to go to
	private Dictionary<string, bool> responseBranch = new Dictionary<string, bool>();


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

	public DialogueTree(int id) {
		this.id = id;
		diaData = null;
		left = null;
		right = null;
	}
	public DialogueTree(string data, int id, DialogueTree left, DialogueTree right) {
		diaData = data;
		this.id = id;
		this.left = left;
		this.right = right;
	}
	public DialogueTree(string data) {
		left = null;
		right = null;
		diaData = data;
	}

	public DialogueTree findNode(int id) {
		DialogueTree currNode = this;
		return findNode(id, currNode);
	}

	private DialogueTree findNode(int id, DialogueTree currNode) {
		if (currNode.getLeft () == null && currNode.getRight () == null && currNode.getID () != id ) {
			return null;
		}

		findNode (id, currNode.getLeft ());
		findNode (id, currNode.getRight ());
		return currNode;
	}

	public bool getBranch(string userResponse) {
		return responseBranch [userResponse];
	}

	public void setBranch(string key, bool value) {
		responseBranch.Add (key, value);
	}

	public int getID() {
		return id;
	}

	public void setID(int i) {
		id = i;
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

	public void traverseTree() {
		DialogueTree currNode = this;
		traverseTree (currNode);

	}
	private void traverseTree( DialogueTree currNode ) {
		if (currNode == null) {
			return;
		}
		traverseTree (currNode.getLeft ());
		Debug.Log (currNode.getDialogue ());
		traverseTree( currNode.getRight());
		
	}//end of traverseTree




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

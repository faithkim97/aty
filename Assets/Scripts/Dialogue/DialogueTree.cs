using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//possibly create boolean value of isSaved = true/false in one of the dialogue scripts
/// <summary>
/// Keeps track of all dialogues in the style of a binary tree
/// </summary>
[System.Serializable]
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
	private static Dictionary<string, bool> responseBranch = new Dictionary<string, bool>();
    private DialogueBranch branch;

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
	public static Dictionary<string, bool> getDict() {
		return responseBranch;
	}
	public static bool getBranch(string userResponse) {
		return responseBranch [userResponse];
	}

	public static void setBranch(string key, bool value) {
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
        this.setBranch(new DialogueBranch());
    }

    public void setRight(DialogueTree node) {
        right = node;
        this.setBranch( new DialogueBranch());
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
	//preorder
	private void traverseTree( DialogueTree currNode ) {
		if (currNode == null) {
			return;
		}
		Debug.Log (currNode.getDialogue ());
		traverseTree (currNode.getLeft ());
		traverseTree( currNode.getRight());
		
	}//end of traverseTree

    public void setBranch(DialogueBranch branch) {
        this.branch = branch;
    }

    public DialogueBranch getBranch() {
        return branch;
    }




    [System.Serializable]
    public class DialogueBranch {
        private string data;

        public DialogueBranch() {
            data = null;
        }

        public DialogueBranch(string data) {
            this.data = data;
        }

        public void setData(string data) {
            this.data = data;
        }

        public string getData() {
            return data;
        }

        
    }//end of DialogueBranch class
}

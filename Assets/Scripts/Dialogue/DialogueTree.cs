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

    private static List<DialogueBranch> branches = new List<DialogueBranch>();

	public DialogueTree() {
		diaData = null;
		left = null;
		right = null;
       // branches = new List<DialogueBranch>();
	}

	public DialogueTree(int id) {
		this.id = id;
		diaData = null;
		left = null;
        right = null;
        //branches = new List<DialogueBranch>();
    }
	public DialogueTree(string data, int id, DialogueTree left, DialogueTree right) {
		diaData = data;
		this.id = id;
		this.left = left;
		this.right = right;
        //branches = new List<DialogueBranch>();
    }
	public DialogueTree(string data) {
		left = null;
		right = null;
		diaData = data;
        //branches = new List<DialogueBranch>();
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

    public void setLeft(DialogueTree node) {
        left = node;
        //setBranch(this, left);

    }

    public void setRight(DialogueTree node) {
        right = node;
        //setBranch(this, right);
    }

    public static void setBranch(DialogueTree parent, DialogueTree child) {
        branches.Add(new DialogueBranch(parent, child));
        //Debug.Log("branch just added: " + branches[branches.Count - 1].getParent().getDialogue() + " " + branches[branches.Count-1].getChild().getDialogue());
    }
    /// <summary>
    /// GET BRANCH NOT WORKING---POINTERS AREN'T WORKING MAN
    /// </summary>
    /// <param name="child"></param>
    /// <returns></returns>
    public static DialogueBranch getBranch(DialogueTree parent, DialogueTree child) {
        for (int i = 0; i < branches.Count; i++) {
            if (branches[i].hasBranch(parent, child) || branches[i].hasBranch(child, parent)) {
                return branches[i];
            }
        }
        Debug.Log("inside get branch");
        return null;
    }

    //[System.Serializable]
    public class DialogueBranch {
        private string data;
        DialogueTree parent;
        DialogueTree child;
        public DialogueBranch() {
            data = null;
            parent = null;
            child = null;
        }
        public DialogueBranch(DialogueTree parent, DialogueTree child) {
            data = null;
            this.parent = parent;
            this.child = child;
        }
        public DialogueBranch(string data, DialogueTree parent, DialogueTree child) {
            this.data = data;
            this.parent = parent;
            this.child = child;
        }

        public void setData(string data) {
            this.data = data;
        }

        public string getData() {
            return data;
        }

        public DialogueTree getParent() {
            return parent;
        }

        public DialogueTree getChild() {
            return child;
        }
        public bool hasBranch(DialogueTree parent, DialogueTree child) {
            return (this.parent == parent && this.child == child);
        }

        
    }//end of DialogueBranch class
}

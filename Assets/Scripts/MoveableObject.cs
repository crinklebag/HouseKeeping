using UnityEngine;
using System.Collections;

public class MoveableObject : MonoBehaviour {

    Puzzle puzzle;

    [SerializeField] Material successMat;
    
    bool canMove = true;

	// Use this for initialization
	void Start () {
        puzzle = GameObject.FindGameObjectWithTag("GameController").GetComponent<Puzzle>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void RightSpot() {
        canMove = false;
        MeshRenderer[] children = transform.GetComponentsInChildren<MeshRenderer>();
        foreach (MeshRenderer mesh in children) {
            mesh.material = successMat;
            puzzle.CheckWin();
        }
    }

    public bool GetCanMove() {
        return canMove;
    }
}

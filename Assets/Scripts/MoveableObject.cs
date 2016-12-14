using UnityEngine;
using System.Collections;

public class MoveableObject : MonoBehaviour {

    public enum ObjectType { CUP, FISH_TANK, CURTAIN, DRESSER, PLANT };
    [SerializeField] ObjectType type;

    Puzzle puzzle;

    [Header("Object Refences")]
    [SerializeField] Material successMat;
    [SerializeField] GameObject changeableMesh;
    [SerializeField] GameObject changeableMesh2;
    [SerializeField] GameObject successObject;
    [SerializeField] bool goalCurtainState; // False to close and true to open
    [SerializeField] bool sunned;
    [SerializeField] Vector3 openCurtain;
    [SerializeField] Vector3 closeCurtain;

    bool canMove = true;
    bool closed = true;
    bool tipped = false;
    public bool successful = false;

	// Use this for initialization
	void Start () {
        puzzle = GameObject.FindGameObjectWithTag("GameController").GetComponent<Puzzle>();
        if (goalCurtainState) {
            // closed = false;
            CloseCurtains();
        } else {
            // closed = true;
            OpenCurtains();
        }
	}

    public int GetObjectType() { 
        return (int)type;
    }

    public bool Successful() {
        return successful;
    }
    
    public void Success() {
        switch (type) {
            case ObjectType.DRESSER:
                RightSpot();
                break;
            case ObjectType.PLANT:
                SunPlant();
                break;
        }
    }

    public void TipGlass() {
        successful = true;
        successObject.SetActive(true);
        tipped = true;
        this.gameObject.SetActive(false);
        puzzle.CheckWin();
    }

    public void FixTank() {
        changeableMesh.GetComponent<MeshRenderer>().material = successMat;
        successful = true;
    }

    #region PLANT 

    public void SunPlant() {
        successful = true;
        sunned = true;
        puzzle.CheckWin();
    }

    public void ShadePlant() {
        successful = false;
        sunned = false;
    }

    public void NourishPlant() {
        changeableMesh.GetComponent<MeshRenderer>().material = successMat;
        successObject.SetActive(true);
        changeableMesh2.GetComponent<MoveableObject>().SetCanMove(true);
        MeshRenderer[] children = changeableMesh2.transform.GetComponentsInChildren<MeshRenderer>();
        foreach (MeshRenderer mesh in children) {
            mesh.material = successMat;
        }
        // changeableMesh2.GetComponent<MoveableObject>().RightSpot();
    }

    #endregion

    #region CURTAINS
    void OpenCurtains() {
        if (type == ObjectType.CURTAIN && closed) {
            Debug.Log("Opening Curtains");
            closed = false;
            this.transform.localScale = openCurtain;
        }

        if (goalCurtainState) {
            successful = true;
        }
        else { successful = false; }

        puzzle.CheckWin();
    }

    void CloseCurtains() {
        if (type == ObjectType.CURTAIN && !closed){
            Debug.Log("Closing Curtains");
            closed = true;
            this.transform.localScale = closeCurtain;
        }

        if (!goalCurtainState) {
            successful = true;
        }
        else { successful = false; }

        puzzle.CheckWin();
    }

    public void HandleCurtains() {
        if (closed) {
            OpenCurtains();
        } else {
            CloseCurtains();
        }
    }
    #endregion

    #region DRESSER
    public void MoveDresser(Vector3 forceDirection, float forcePower) {
        // Debug.Log("Adding Force");
        if (this.GetComponent<MoveableObject>().GetCanMove()) {
            this.GetComponent<Rigidbody>().AddForce(forceDirection * forcePower, ForceMode.Impulse);
        }
    }

    void RightSpot() {
        canMove = false;
        successful = true;
        MeshRenderer[] children = transform.GetComponentsInChildren<MeshRenderer>();
        foreach (MeshRenderer mesh in children) {
            mesh.material = successMat;
            puzzle.CheckWin();
        }
    }

    public bool GetCanMove() {
        return canMove;
    }

    public void SetCanMove(bool state) {
            canMove = state;
            successful = state;
    }
    #endregion
}

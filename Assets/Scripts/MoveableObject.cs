using UnityEngine;
using System.Collections;

public class MoveableObject : MonoBehaviour {

    public enum ObjectType { CUP, FISH_TANK, CURTAIN, DRESSER, PLANT };
    [SerializeField] ObjectType type;

    Puzzle puzzle;

    [Header("Object Refences")]
    [SerializeField] Material successMat;
    [SerializeField] GameObject tippedGlass;
    [SerializeField] GameObject plantStem;
    [SerializeField] GameObject plantFlower;
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
        if (!goalCurtainState) {
            CloseCurtains();
        } else {
            OpenCurtains();
        }
	}
	
	// Update is called once per frame
	void Update () {
        HandleCurtains();
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
        tippedGlass.SetActive(true);
        tipped = true;
        this.gameObject.SetActive(false);
        puzzle.CheckWin();
    }

    void FixTankTemp() {

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
        plantStem.GetComponent<MeshRenderer>().material = successMat;
        plantFlower.SetActive(true);
    }

    #endregion

    #region CURTAINS
    public void OpenCurtains() {
        if (type == ObjectType.CURTAIN && closed) {
            Debug.Log("Opening Curtains");
            closed = false;
            this.transform.localScale = openCurtain;
        }
    }

    public void CloseCurtains() {
        if (type == ObjectType.CURTAIN && !closed){
            Debug.Log("Closing Curtains");
            closed = true;
            this.transform.localScale = closeCurtain;
        }
    }

    void HandleCurtains() {

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
    #endregion
}

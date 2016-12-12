using UnityEngine;
using System.Collections;

public class Puzzle : MonoBehaviour {

    [SerializeField] GameObject[] objects;
    [SerializeField] GameObject lockedDoor;
    [SerializeField] GameObject cat;
    [SerializeField] GameObject sleepingCat;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void CheckWin() {
        int counter = 0;
        foreach(GameObject moveableObject in objects){
            if (!moveableObject.GetComponent<MoveableObject>().GetCanMove()) {
                counter++;
            }
        }

        if (counter == objects.Length) {
            lockedDoor.SetActive(false);
            cat.SetActive(false);
            sleepingCat.SetActive(true);
        }
    }
}

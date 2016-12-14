using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Puzzle : MonoBehaviour {

    public enum PuzzleState { PUZZLE1, PUZZLE2, SOLVED };
    PuzzleState currentPuzzle = PuzzleState.PUZZLE1;

    [SerializeField] Light[] puzzleLights;
    [SerializeField] GameObject[] puzzle1Objects;
    [SerializeField] GameObject[] puzzle2Objects;
    [SerializeField] GameObject lockedDoor1;
    [SerializeField] GameObject lockedDoor2;
    [SerializeField] GameObject cat;
    [SerializeField] GameObject sleepingCat;
    [SerializeField] GameObject winText;
    GameObject instructionsText;

    void Start() {
        instructionsText = GameObject.FindGameObjectWithTag("Trigger Text");
    }

    public void CheckWin() {
        switch (currentPuzzle) {
            case PuzzleState.PUZZLE1:
                CheckObjects(puzzle1Objects);
                if (puzzle1Objects[0].GetComponent<MoveableObject>().Successful()) {
                    puzzleLights[0].intensity = 8;
                }
                if (puzzle1Objects[1].GetComponent<MoveableObject>().Successful()) {
                    puzzleLights[1].intensity = 8;
                }
                break;
            case PuzzleState.PUZZLE2:
                // If the plant has been watered and sunned, make it brighter
                if (puzzle2Objects[0].GetComponent<MoveableObject>().Successful() && puzzle2Objects[1].GetComponent<MoveableObject>().Successful()) {
                    // Debug.Log("Nourishing Plant");
                    puzzle2Objects[0].GetComponent<MoveableObject>().NourishPlant();
                    instructionsText.transform.GetChild(0).GetComponent<Text>().text = "Ah Ha!";
                    puzzleLights[2].intensity = 8;
                } if (puzzle2Objects[2].GetComponent<MoveableObject>().Successful() && puzzle2Objects[3].GetComponent<MoveableObject>().Successful()) {
                    puzzle2Objects[4].GetComponent<MoveableObject>().FixTank();
                    puzzleLights[3].intensity = 8;
                    // Win Game this level -- load final puzzle
                }
                CheckObjects(puzzle2Objects);
                break;
        }
    }

    void CheckObjects(GameObject[] objectArray) {
        int counter = 0;
        foreach (GameObject moveableObject in objectArray) {
            if (moveableObject.GetComponent<MoveableObject>().Successful()) {
                counter++;
            }
        }

        if (counter == objectArray.Length) {
            Win();
        }
    }

    void Win() {
        UnlockDoor();
        cat.SetActive(false);
        sleepingCat.SetActive(true);
    }

    void UnlockDoor() {
        switch (currentPuzzle) {
            case PuzzleState.PUZZLE1:
                lockedDoor1.SetActive(false);
                currentPuzzle = PuzzleState.PUZZLE2;
                break;
            case PuzzleState.PUZZLE2:
                // lockedDoor2.SetActive(false);
                winText.SetActive(true);
                break;
        }
    }
}

using UnityEngine;
using System.Collections;

public class MoveCamera : MonoBehaviour {

    [SerializeField] Vector3 destination;
    [SerializeField] float offset;

    bool moveCam = false;

	// Update is called once per frame
	void Update () {
        if (moveCam) { MoveCam(); }
	}

    void MoveCam() {
        if (Camera.main.transform.localPosition.z != destination.z - offset) {
            Camera.main.transform.localPosition = Vector3.Lerp(Camera.main.transform.localPosition, destination, 10 * Time.deltaTime);
        }
        else {
            moveCam = false;
        }
    }

    void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")) {
            moveCam = true;
        }
    }

    void OnTriggerExit(Collider other) {
        if (other.CompareTag("Player")) {
            moveCam = false;
        }
    }
}

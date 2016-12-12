using UnityEngine;
using System.Collections;

public class PlayerInput : MonoBehaviour {

    [SerializeField] float speed;
    GameObject interactableObject;
    bool canInteract = false;

	// Use this for initialization
	void Start () {
	
	}

    // Update is called once per frame
    void Update() {
        if (Input.GetKey(KeyCode.A)) {
            // move left
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D)) {
            // move right
            transform.Translate(Vector3.right * speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.W)) {
            // move forward
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.S)) {
            // move back
            transform.Translate(Vector3.back * speed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.Space) && canInteract) {
            // Debug.Log("Interacting");
            interactableObject.GetComponent<InteractTrigger>().InteractWithObject();
        }
	}

    public void SetCanInteract(bool state, GameObject newInteractableObject) {
        canInteract = state;
        interactableObject = newInteractableObject;
    }
}

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
        HandleInput();
        // Vector3 oldRot = transform.rotation.eulerAngles;
        // transform.rotation = Quaternion.Euler(0, oldRot.y, 0);
    }

    void HandleInput()
    {
        if (Input.GetKey(KeyCode.A))
        {
            // move left
            transform.Translate(Vector3.left * speed * Time.deltaTime);
            // transform.Rotate(this.transform.up, -1);
        }
        if (Input.GetKey(KeyCode.D))
        {
            // move right
            transform.Translate(Vector3.right * speed * Time.deltaTime);
            //transform.Rotate(this.transform.up, 1);
        }
        if (Input.GetKey(KeyCode.W))
        {
            // move forward
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.S))
        {
            // move back
            transform.Translate(Vector3.back * speed * Time.deltaTime);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Debug.Log("Interacting");
            if (canInteract) { interactableObject.GetComponent<InteractTrigger>().InteractWithObject(); }
            else { } // Jump
        }
    }

    public void SetCanInteract(bool state, GameObject newInteractableObject) {
        canInteract = state;
        interactableObject = newInteractableObject;
    }
}

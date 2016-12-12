using UnityEngine;
using System.Collections;

public class PlayerInput : MonoBehaviour {

    [SerializeField] float speed;
    GameObject shoveableObject;
    bool canShove = false;

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

        if (Input.GetKey(KeyCode.Space) && canShove) {
            shoveableObject.GetComponent<ShoveTrigger>().ShoveObject();
        }
	}

    public void SetCanShove(bool state, GameObject newShoveableObject) {
        canShove = state;
        shoveableObject = newShoveableObject;
    }
}

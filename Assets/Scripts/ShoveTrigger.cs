using UnityEngine;
using System.Collections;

public class ShoveTrigger : MonoBehaviour {

    [SerializeField] GameObject dresser;
    [SerializeField] Vector3 forceDirection;
    [SerializeField] float forcePower;
    
    GameObject instructionsText;
    PlayerInput player;

	// Use this for initialization
	void Start () {
        instructionsText = GameObject.FindGameObjectWithTag("Trigger Text");
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInput>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")) {
            instructionsText.transform.GetChild(0).gameObject.SetActive(true);
            player.SetCanShove(true, this.gameObject);
        }
    }

    void OnTriggerExit(Collider other) {
        if (other.CompareTag("Player")) {
            instructionsText.transform.GetChild(0).gameObject.SetActive(false);
            player.SetCanShove(false, null);
        }
    }

    public void ShoveObject() {
        // Debug.Log("Shoving");
        if (dresser.GetComponent<MoveableObject>().GetCanMove()) {
            dresser.GetComponent<Rigidbody>().AddForce(forceDirection * forcePower, ForceMode.Impulse);
        }
    }
}

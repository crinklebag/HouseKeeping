using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Cat : MonoBehaviour {

    GameObject instructionsText;
    [SerializeField] GameObject objectGlow;
    [SerializeField] string instructions;

	// Use this for initialization
	void Start () {
        instructionsText = GameObject.FindGameObjectWithTag("Trigger Text");
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")) {
            objectGlow.SetActive(true);
            instructionsText.transform.GetChild(0).gameObject.SetActive(true);
            instructionsText.transform.GetChild(0).GetComponent<Text>().text = instructions;
        }
    }

    void OnTriggerExit(Collider other) {
        if (other.CompareTag("Player")) {
            objectGlow.SetActive(false);
            instructionsText.transform.GetChild(0).gameObject.SetActive(false);
        }
    }
}

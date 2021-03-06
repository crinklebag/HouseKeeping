﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class InteractTrigger : MonoBehaviour {

    [SerializeField] GameObject interactableObject;
    [SerializeField] GameObject objectOutline;
    [SerializeField] string instructions;
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
        if (other.CompareTag("Player") && interactableObject.activeSelf == true && !interactableObject.GetComponent<MoveableObject>().Successful()) {
            objectOutline.SetActive(true);
            instructionsText.transform.GetChild(0).gameObject.SetActive(true);
            instructionsText.transform.GetChild(0).GetComponent<Text>().text = instructions;
            player.SetCanInteract(true, this.gameObject);
        }
    }

    void OnTriggerExit(Collider other) {
        if (other.CompareTag("Player")) {
            instructionsText.transform.GetChild(0).gameObject.SetActive(false);
            player.SetCanInteract(false, null);
            objectOutline.SetActive(false);
        } if (other.CompareTag("Cactus")) {
            other.GetComponent<MoveableObject>().ShadePlant();
        }
    }

    public void InteractWithObject() {
        Debug.Log("Object Type: " + interactableObject.GetComponent<MoveableObject>().GetObjectType());
        switch (interactableObject.GetComponent<MoveableObject>().GetObjectType()) {
            case 0: // Cup
                interactableObject.GetComponent<MoveableObject>().TipGlass();
                break;
            case 2: // Curtain
                Debug.Log("Interact with Curtain");
                interactableObject.GetComponent<MoveableObject>().HandleCurtains();
                break;
            case 3: // Dresser
                interactableObject.GetComponent<MoveableObject>().MoveDresser(forceDirection, forcePower);
                break;
        }
    }
}

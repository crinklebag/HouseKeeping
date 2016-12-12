using UnityEngine;
using System.Collections;

public class SuccessTrigger : MonoBehaviour {

    [SerializeField] string triggerObject;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider other) {
        if (other.CompareTag(triggerObject)) {
            Debug.Log("Hit Success Trigger");
            other.GetComponent<MoveableObject>().RightSpot();
        }
    }
}

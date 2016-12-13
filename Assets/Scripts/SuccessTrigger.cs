using UnityEngine;
using System.Collections;

public class SuccessTrigger : MonoBehaviour {

    [SerializeField] string triggerObject;

    void OnTriggerEnter(Collider other) {
        if (other.CompareTag(triggerObject)) {
            // Debug.Log("Hit Success Trigger");
            other.GetComponent<MoveableObject>().Success();
        }
    }
}

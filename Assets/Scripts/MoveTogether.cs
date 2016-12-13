using UnityEngine;
using System.Collections;

public class MoveTogether : MonoBehaviour {
    
    [SerializeField] GameObject target;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        this.transform.localPosition = new Vector3(target.transform.localPosition.x, this.transform.localPosition.y, target.transform.localPosition.z);
	}
}

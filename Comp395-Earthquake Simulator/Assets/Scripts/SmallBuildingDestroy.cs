using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallBuildingDestroy : MonoBehaviour {
	public GameObject remains;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.Space)) {
			Instantiate (remains, transform.position, transform.rotation); 
			Destroy (gameObject);
		}
	}
}

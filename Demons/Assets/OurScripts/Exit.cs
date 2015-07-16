using UnityEngine;
using System.Collections;

public class Exit : MonoBehaviour {

	// Use this for initialization
	void Start(){
		print ("there");
	}
	void OnCollisionEnter2D(Collision2D coll) {
		if (coll.gameObject.tag == "Block")
			Destroy (coll.gameObject);
		
	}
}
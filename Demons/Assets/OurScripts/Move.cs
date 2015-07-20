using UnityEngine;
using System.Collections;

public class Move : MonoBehaviour {

	private bool begin;
	// Use this for initialization
	public float movespeed;
	private Transform tr;
	private ParticleSystem jetpack;

	void Start(){
		tr = GetComponent<Transform> ();
		jetpack = GetComponent<ParticleSystem> ();
		jetpack.enableEmission = false;
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKey (KeyCode.UpArrow)) {
			tr.Translate((Vector3.up)/7f);
			jetpack.enableEmission = true;
		}

		if (Input.GetKeyUp (KeyCode.UpArrow)) {
			jetpack.enableEmission = false;
		}
		if (Input.GetKey (KeyCode.LeftArrow)) {
			tr.Translate((Vector3.left)/20f);
		}
		if (Input.GetKey (KeyCode.RightArrow)) {
			tr.Translate((Vector3.right)/20f);
		}
	}

	void OnCollisionEnter2D(Collision2D coll){
		if (coll.gameObject.tag == "Exit") {
			print ("You win");
		}
	}
}

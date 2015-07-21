using UnityEngine;
using System.Collections;

public class Shot : MonoBehaviour {

	ParticleSystem Psystem;
	private bool collided;


	// Use this for initialization
	void Start () {
		Psystem = GetComponent<ParticleSystem> ();
		collided = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (collided) {
			if(Psystem.isStopped){
				Destroy (gameObject);
			}
		}
	}
	void OnCollisionEnter2D(Collision2D coll){
		if (coll.gameObject.tag != "Player" && coll.gameObject.tag != "Weapon" && !collided) {
			print (coll.gameObject.name);
			Psystem.Play ();
			collided = true;
			if (coll.gameObject.tag == "Hopper") {
				Destroy (coll.gameObject);
			}
		}
	}
}

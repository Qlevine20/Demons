using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {
	public GameObject hopper;

	void OnCollisionEnter2D(Collision2D coll){
		if (coll.gameObject.tag != "Hopper") {
			Destroy (this.gameObject);
			//Destroy self after collision
		}
	}

}

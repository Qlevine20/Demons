using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {
	public GameObject Gluttony;

	void OnCollisionEnter2D(Collision2D coll){
		if (coll.gameObject.tag != "Gluttony") {
			Destroy (this.gameObject);
			//Destroy self after collision
		}
	}

}

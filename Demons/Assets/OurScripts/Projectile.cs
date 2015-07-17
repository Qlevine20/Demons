using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {
	public GameObject hopper;

	void Start(){
		if (this.GetComponent <Collider2D> () != null) {
			Physics2D.IgnoreCollision (this.GetComponent<Collider2D> (), hopper.GetComponent<Collider2D> ());
		}
	}

	// Use this for initialization
	void OnCollisionEnter2D(Collision2D coll){
		if (coll.gameObject.tag != "Hopper") {
			Destroy (this.gameObject);
		}
	}

}

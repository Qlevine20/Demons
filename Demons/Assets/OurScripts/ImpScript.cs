using UnityEngine;
using System.Collections;
using System;

public class ImpScript : MonoBehaviour {


	public int health;
	public int movespeed;
	private Transform imptr;
	private bool impfacingright;
	public GameObject ImpSpike;

	// Use this for initialization
	void Awake () {
		imptr = this.transform;
		impfacingright = (Move.facingright) ? true : false;
	}
	
	// Update is called once per frame
	void Update () {
		if (impfacingright) {
			imptr.Translate ((Vector3.right)*movespeed / 30f);
		} else {
			imptr.Translate ((Vector3.left)* movespeed / 30f);
		}
	}

	void OnCollisionEnter2D(Collision2D coll){
		if (coll.transform.position.y >= Math.Round (this.transform.position.y)){
			if(coll.gameObject.tag == "Block"){
				Flip ();
			}
		}


		if (coll.gameObject.tag == "Spike") {
			Instantiate (ImpSpike,new Vector2 (coll.transform.position.x, coll.transform.position.y), Quaternion.identity);
			Destroy (coll.gameObject);
			Destroy (this.gameObject);
		}
	}


	void Flip(){
		Vector3 flipScale;
		
		Rigidbody2D rigidbody = GetComponent<Rigidbody2D> ();
		flipScale = rigidbody.transform.localScale;
		flipScale.x *= -1;
		
		rigidbody.transform.localScale = flipScale ;
		
		impfacingright = !impfacingright;
		
	}
}
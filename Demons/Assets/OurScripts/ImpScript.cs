﻿using UnityEngine;
using System.Collections;
using System;

public class ImpScript : MonoBehaviour {


	public int health;
	public int movespeed;
	private Transform imptr;
	private bool impfacingright;
	public GameObject ImpSpike;
	private float count;
	public int TimeToDie;
	// Use this for initialization
	void Awake () {
		count = 0;
		imptr = this.transform;
		impfacingright = (Move.facingright) ? true : false;
		if (impfacingright) {
			Flip ();
		}
	}
	
	// Update is called once per frame
	void Update () {
		count += Time.deltaTime;

		Physics2D.IgnoreLayerCollision(9,9);

		if (count >= TimeToDie) {
			Destroy (this.gameObject);
		}

		if (impfacingright) {
			imptr.Translate ((Vector3.right)*movespeed / 30f);
		} else {
			imptr.Translate ((Vector3.right)* -movespeed / 30f);
		}
	}

	void OnTriggerEnter2D(Collider2D coll){
		if (coll.gameObject.tag == "BlockSide"){
			Flip ();
			impfacingright = !impfacingright;
		}
	}
	

	void OnCollisionEnter2D(Collision2D coll){
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
		
	}
}
﻿using UnityEngine;
using System.Collections;

public class Move : MonoBehaviour {

	private bool begin;
	// Use this for initialization

	public float movespeed;
	//how fast player moves.

	private Transform tr;
	//The players transform(position/movement).

	private ParticleSystem jetpack;
	//The jetpacks particles.
	private Rigidbody2D rb;
	//The players Rigidbody(adding force/collision,etc).

	public static float maxfuel;
	//must be static so that fuel bar can use this float.
	//The highest possible amount of fuel for the jetpack.

	public static float fuelevel;
	//Current fuel level.
	private bool fuelon;
	//Checks to see if jetpack is currently on.

	public static bool facingright;
	//Checks to see if the player is facing right.

	void Start(){
		//Initialize each variable.
		rb = GetComponent<Rigidbody2D> ();
		tr = GetComponent<Transform> ();
		jetpack = GetComponent<ParticleSystem> ();
		jetpack.enableEmission = false;
		maxfuel = 3;
		//must be set here because it is static.

		fuelevel = maxfuel;
		facingright = true;
	}
	
	// Update is called once per frame
	void Update () {

		//Up
		if(Input.GetKey (KeyCode.UpArrow)) {
			if (fuelevel > 0) {
				//Use jetpack.
				rb.AddForce (new Vector2 (0, movespeed));
				fuelon = true;
				fuelevel -= 1 * Time.deltaTime;
				jetpack.enableEmission = true;
			} 
			else {
				//If there is no fuel jetpack will not work.
				jetpack.enableEmission = false;
			}
		}

		//Up-Press
		if (Input.GetKeyDown (KeyCode.UpArrow)) {
			tr.Translate ((Vector3.up) / 15f);
			//Normal jump.  Without jetpack
		} 

		//Up-Release
		if (Input.GetKeyUp (KeyCode.UpArrow)) {
			//Stop the animation for the jetpack.
			jetpack.enableEmission = false;
			fuelon = false;

		}


		//Left
		if (Input.GetKey (KeyCode.LeftArrow)) {
			tr.Translate((Vector3.left)/20f);
			if (facingright){
				Flip();
			}
		}

		//Right
		if (Input.GetKey (KeyCode.RightArrow)) {
			tr.Translate((Vector3.right)/20f);
			if (!facingright){
				Flip();
			}
		}
	}

	//One touch collision with object.
	void OnCollisionEnter2D(Collision2D coll){
		if (coll.gameObject.tag == "Exit") {
			print ("You win");
		}	
	}


	//Continous collision with object
	void OnCollisionStay2D(Collision2D coll){
		if (coll.gameObject.tag == "Block") {
			if (fuelevel < maxfuel) {
				fuelevel += 1 * Time.deltaTime;
			}
		}
	}


	//Change direction that player is facing.
	void Flip(){
		Vector3 flipScale;

		Rigidbody2D rigidbody = GetComponent<Rigidbody2D> ();
		flipScale = rigidbody.transform.localScale;
		flipScale.x *= -1;

		rigidbody.transform.localScale = flipScale ;

		facingright = !facingright;

	}
}

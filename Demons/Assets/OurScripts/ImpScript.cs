using UnityEngine;
using System.Collections;
using System;

public class ImpScript : MonoBehaviour {


	public int health;
	public int movespeed;
	private Transform Imptr;
	private bool ImpFacingright;
	public GameObject ImpSpike;
	private float count;
	public int TimeToDie;
	// Use this for initialization
	void Awake () {
		count = 0;
		Imptr = this.transform;
		ImpFacingright = (Move.facingright) ? true : false;
		if (ImpFacingright) {
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

		if (ImpFacingright) {
			Imptr.Translate ((Vector3.right)*movespeed / 30f);
		} else {
			Imptr.Translate ((Vector3.right)* -movespeed / 30f);
		}
	}

	void OnTriggerEnter2D(Collider2D coll){
		if (coll.gameObject.tag == "BlockSide"){
			Flip ();
			ImpFacingright = !ImpFacingright;
		}


	}
	

	void OnCollisionEnter2D(Collision2D coll){
		if (coll.gameObject.tag == "Spike") {
			Instantiate (ImpSpike,new Vector2 (coll.transform.position.x, coll.transform.position.y), Quaternion.identity);
			Destroy (coll.gameObject);
			Destroy (this.gameObject);
		}


		if (coll.gameObject.tag == "Button") {
			Destroy(coll.transform.parent.gameObject);
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
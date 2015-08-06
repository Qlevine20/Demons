using UnityEngine;
using System.Collections;
using System;

public class insScript : MonoBehaviour {
	
	
	public int health;
	public int movespeed;
	private Transform instr;
	private bool InsFacingright;
	public GameObject insSpike;
	private float count;
	public int TimeToDie;
	// Use this for initialization
	void Awake () {
		count = 0;
		instr = this.transform;
		InsFacingright = (Move.facingright) ? true : false;
		if (InsFacingright) {
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
		
		if (InsFacingright) {
			instr.Translate ((Vector3.right)*movespeed / 30f);
		} else {
			instr.Translate ((Vector3.right)* -movespeed / 30f);
		}
	}
	
	void OnTriggerEnter2D(Collider2D coll){
		if (coll.gameObject.tag == "BlockSide"){
			Flip ();
			InsFacingright = !InsFacingright;
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
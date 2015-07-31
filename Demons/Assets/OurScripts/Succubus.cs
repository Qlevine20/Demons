using UnityEngine;
using System.Collections;

public class Succubus : MonoBehaviour {


	public int Health;
	public int Movespeed;
	private Transform Succtr;
	private bool SuccFacingright;
	public GameObject ImpSpike;
	private float Count;
	public int TimeToDie;
	public int LureRange;

	// Use this for initialization
	void Awake () {
		Count = 0;
		Succtr = this.transform;
		SuccFacingright = (Move.facingright) ? true : false;
		if (!SuccFacingright) {
			Flip ();
		}
	
	}
	
	// Update is called once per frame
	void Update () {
		Count += Time.deltaTime;
		
		Physics2D.IgnoreLayerCollision(9,9);

		if (Count >= TimeToDie) {
			Destroy (this.gameObject);
		}
		
		if (SuccFacingright) {
			Succtr.Translate ((Vector3.right)*Movespeed / 30f);
		} else {
			Succtr.Translate ((Vector3.right)* -Movespeed / 30f);
		}
	}



	void OnTriggerEnter2D(Collider2D coll){
		if (coll.gameObject.tag == "BlockSide") {
			Flip ();
			SuccFacingright = !SuccFacingright;
		}

		if (coll.gameObject.tag == "SpikeSide") {
			Flip ();
			SuccFacingright = !SuccFacingright;
		
		}
	}
	
	
	void OnCollisionEnter2D(Collision2D coll){
		if (coll.gameObject.tag == "Spike") {
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

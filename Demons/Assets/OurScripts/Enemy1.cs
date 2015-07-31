using UnityEngine;
using System.Collections;

public class Enemy1 : MonoBehaviour {

	public Transform Player;
	private bool Lured;
	public int MoveSpeed;
	private Transform follow;
	private bool EFacingLeft;
	// Use this for initialization
	void Start () {
		EFacingLeft = (Move.facingright) ? false : true;
		Lured = false;
		follow = Player;
	}
	
	// Update is called once per frame
	void Update () {
		if (follow == null) {
			Lured = false;
			follow = Player;
		}
		if (!Lured) {
			if(Mathf.Abs(follow.transform.position.x-transform.position.x)<3){
				if(!EFacingLeft){
					transform.position -= transform.right*MoveSpeed*Time.deltaTime;
				}
				else{
					transform.position += transform.right*MoveSpeed*Time.deltaTime;
				}
			}

		}
		LookDirection();


	}

	void OnTriggerStay2D(Collider2D coll){
		if (coll.gameObject.tag == "SuccRange") {
			Lured = true;
			follow = coll.gameObject.transform;
			if(!EFacingLeft){
			transform.position -= transform.right*MoveSpeed*Time.deltaTime;
			}
			else{
				transform.position += transform.right*MoveSpeed*Time.deltaTime;
			}

		}
	}


	void LookDirection(){
		if (follow.position.x < transform.position.x) {
			if (EFacingLeft) {
				EFacingLeft = false;
				Flip ();
				} 
			}
		else {
			if (!EFacingLeft) {
				EFacingLeft = true;
				Flip ();
			}
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



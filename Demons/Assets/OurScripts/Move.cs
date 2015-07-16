using UnityEngine;
using System.Collections;

public class Move : MonoBehaviour {

	private bool begin;
	// Use this for initialization
	public float movespeed;
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.UpArrow)) {
			transform.position = new Vector2(transform.position.x,transform.position.y+movespeed);
		}
		if (Input.GetKey (KeyCode.LeftArrow)) {
			transform.position = new Vector2(transform.position.x-movespeed,transform.position.y);
		}
		if (Input.GetKey (KeyCode.RightArrow)) {
			transform.position = new Vector2(transform.position.x+movespeed,transform.position.y);
		}
	}

	void OnCollisionEnter2D(Collision2D coll){
		if (coll.gameObject.tag == "Exit") {
			print ("You win");
		}
	}
}

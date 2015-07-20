using UnityEngine;
using System.Collections;

public class Move : MonoBehaviour {

	private bool begin;
	// Use this for initialization
	public float movespeed;
	private Transform tr;
	private ParticleSystem jetpack;
	private Rigidbody2D rb;
	public static float maxfuel;
	public static float fuelevel;
	private bool fuelon;

	void Start(){
		rb = GetComponent<Rigidbody2D> ();
		tr = GetComponent<Transform> ();
		jetpack = GetComponent<ParticleSystem> ();
		jetpack.enableEmission = false;
		maxfuel = 3;
		fuelevel = maxfuel;
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKey (KeyCode.UpArrow)) {
			if (fuelevel > 0) {
				rb.AddForce (new Vector2 (0, movespeed));
				fuelon = true;
				fuelevel -= 1 * Time.deltaTime;
				jetpack.enableEmission = true;
			} 
			else {
				jetpack.enableEmission = false;
			}
		}
		if (Input.GetKeyDown (KeyCode.UpArrow)) {
			tr.Translate ((Vector3.up) / 15f);
		} 
		if (Input.GetKeyUp (KeyCode.UpArrow)) {
			jetpack.enableEmission = false;
			fuelon = false;

		}
		if (Input.GetKey (KeyCode.LeftArrow)) {
			tr.Translate((Vector3.left)/20f);
		}
		if (Input.GetKey (KeyCode.RightArrow)) {
			tr.Translate((Vector3.right)/20f);
		}
	}

	void OnCollisionEnter2D(Collision2D coll){
		if (coll.gameObject.tag == "Exit") {
			print ("You win");
		}	
	}

	void OnCollisionStay2D(Collision2D coll){
		if (coll.gameObject.tag == "Block") {
			if (fuelevel < maxfuel) {
				fuelevel += 1 * Time.deltaTime;
				print (fuelevel/maxfuel);
			}
		}
	}
}

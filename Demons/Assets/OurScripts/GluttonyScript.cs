using UnityEngine;
using System.Collections;
using System;

public class GluttonyScript : MonoBehaviour {
	
	
	public int health;
	public int movespeed;
	private Transform Gluttonytr;
	private bool GluttonyFacingright;
	public GameObject ImpSpike;
	public GameObject SpitProjectile;
	private float count;
	public int TimeToDie;
	private bool EnemyInRange;
	public int ShotSpeed;
	// Use this for initialization
	void Awake () {
		EnemyInRange = false;
		count = 0;
		Gluttonytr = this.transform;
		GluttonyFacingright = (Move.facingright) ? true : false;
		if (GluttonyFacingright) {
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


		if (!EnemyInRange) {
			if (GluttonyFacingright) {
				Gluttonytr.Translate ((Vector3.right) * movespeed / 30f);
			} else {
				Gluttonytr.Translate ((Vector3.right) * -movespeed / 30f);
			}
		}
	}


	void OnTriggerEnter2D(Collider2D coll){
		if (transform.position.x > coll.transform.position.x) {
			if (!GluttonyFacingright) {
				Flip ();
			}
		} else {
			if (GluttonyFacingright) {
				Flip ();
			}
		}
	}
	void OnTriggerStay2D(Collider2D coll){
		if (coll.gameObject.tag == "BlockSide"){
			Flip ();
			GluttonyFacingright = !GluttonyFacingright;
		}

		if (coll.gameObject.tag == "Enemy") {
			EnemyInRange = true;

			}
			if (UnityEngine.Random.Range (0, 100) < 5) {
				GameObject clone = Instantiate(SpitProjectile,transform.position,Quaternion.identity) as GameObject;
			clone.GetComponent<Rigidbody2D>().velocity =  new Vector2(transform.position.x-clone.transform.position.x*ShotSpeed,transform.position.y-clone.transform.position.y*ShotSpeed);
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
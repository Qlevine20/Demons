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
	private Transform Aimer;
	private float PrevCount;
	public int ReloadSpeed;
	// Use this for initialization
	void Awake () {
		PrevCount = 0;
		Transform[] AllTransforms = GetComponentsInChildren<Transform> ();
		foreach (Transform tran in AllTransforms){
			if(tran.gameObject.tag == "Aim"){
				Aimer = tran;
			}
		};
		EnemyInRange = false;
		count = 0;
		Gluttonytr = this.transform;
		GluttonyFacingright = (Move.facingright) ? true : false;
		Debug.Log (Move.facingright);
		if (!GluttonyFacingright) {
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

		if (coll.gameObject.tag == "BlockSide"){
			Flip ();
			GluttonyFacingright = !GluttonyFacingright;
		}

		if (coll.gameObject.tag == "Enemy") {
			if (transform.position.x < coll.transform.position.x) {
				if (!GluttonyFacingright) {
					Flip ();
				}
			} else {
				if (GluttonyFacingright) {
					Flip ();
				}
			}
		}
	}
	void OnTriggerStay2D(Collider2D coll){
		if (coll.gameObject.tag == "Enemy") {
			Vector3 dir = coll.transform.position - transform.position;
			float angle = Mathf.Atan2(dir.y,dir.x) * Mathf.Rad2Deg;
			Aimer.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
			EnemyInRange = true;

			}
			if (UnityEngine.Random.Range (0, 100) < 50 && count-PrevCount>=ReloadSpeed && EnemyInRange) {
				PrevCount = count;
			GameObject clone = Instantiate (SpitProjectile, Aimer.transform.position, Quaternion.identity) as GameObject;
			clone.GetComponent<Rigidbody2D> ().velocity = (Aimer.transform.right)* ShotSpeed;
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
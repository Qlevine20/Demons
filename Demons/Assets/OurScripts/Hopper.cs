using UnityEngine;
using System.Collections;
using System;

public class Hopper : MonoBehaviour {


	public Rigidbody2D projectile;
	public float projectilespeed;
	public int timetochange;
	// Use this for initialization
	private Rigidbody2D rb;
	private float count;
	private bool ready;
	private int currcount;

	void Start(){
		rb = GetComponent<Rigidbody2D> ();
		count = 0;
		rb.gravityScale = 1;
	}
	// Update is called once per frame
	void Update () {
		count +=Time.deltaTime;
		if (UnityEngine.Random.Range (1, 100) < 5) {
			Rigidbody2D clone;
			clone = Instantiate(projectile,this.transform.position,Quaternion.identity) as Rigidbody2D;
			if(UnityEngine.Random.Range (0,2)==1){
				clone.velocity = new Vector2(projectilespeed,0);
			}
			else{
				clone.velocity = new Vector2(-(projectilespeed),0);
			}
		}
		if ((int)(Math.Round (count)) % timetochange == 0 && count>0&&ready) {

			rb.gravityScale=-(rb.gravityScale);
			transform.localScale= new Vector2(transform.localScale.x,-(transform.localScale.y));
			ready=false;
			currcount = (int)Math.Round (count);
		}
		if (!ready&& (int)Math.Round (count)== currcount+3) {
			ready=true;
		}

	}
}
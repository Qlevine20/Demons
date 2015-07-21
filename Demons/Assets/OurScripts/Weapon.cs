using UnityEngine;
using System.Collections;

public class Weapon : MonoBehaviour {

	public Rigidbody2D shot;
	public float shotspeed;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Space)) {
			Rigidbody2D clone;
			clone = Instantiate(shot,this.transform.position,Quaternion.identity) as Rigidbody2D;
			if (Move.facingleft){
			clone.velocity = new Vector2(shotspeed,0);
			}
			else{
				Vector3 flipScale;
				flipScale = clone.transform.localScale;
				flipScale.x*=-1;
				clone.transform.localScale = flipScale;
				clone.velocity = new Vector2(-shotspeed,0);
			}
		}
	
	}
}

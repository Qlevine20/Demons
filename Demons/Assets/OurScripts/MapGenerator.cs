using UnityEngine;
using System.Collections;
using System;

public class MapGenerator : MonoBehaviour {

	public int width;
	public int height;
	public string seedname;
	//name of seed so it can be re-used
	public bool UseRandomSeed;
	//Randomly creates new seed

	[Range(0,100)]
	//Used to set a range
	//Also creates a sliding widget
	//because it is public
	public int RandFillPercent;


	int [,] map;
	// creates the initial blank map
	void Start () {
		MapGenerate ();
		//Given the width and height make the actual map
	}
	void MapGenerate(){
		map = new int[width, height];
		RandomFillMap ();

	}

	void RandomFillMap(){
		if (UseRandomSeed) {
			seedname = Time.time.ToString ();
			//just changing the seedname to something different
			//Should probably change this
			System.Random psuedoRandom = new System.Random(seedname.GetHashCode());
			//Still not entirely sure how a System.Random object works
			//Something to look into


			for (int x = 0; x<width;x++){
				for (int y = 0; y<height;y++){
					map[x,y] = (psuedoRandom.Next(0,100) < RandFillPercent)?1:0; 
					//this line basically says that if the Random Number is less 
					//than the RandFillPercent then put a 1 (block) there.  Otherwise 
					//place a 0 (empty).
				}
			}
		}
	}

	void OnDrawGizmos(){
		if (map != null) {
			for (int x = 0; x<width;x++){
				for (int y = 0; y<height;y++){
					Gizmos.color = (map[x,y] == 1)?Color.black:Color.white;
					Vector3 cen = new Vector3(-width/2 + x + .5f, -height/2 + y + .5f);
					Gizmos.DrawCube (cen,Vector3.one);
				}
			}
		}
	}
}
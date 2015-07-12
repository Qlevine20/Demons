using UnityEngine;
using System.Collections;
using System;

public class MapGenerator : MonoBehaviour {

	public int width;
	public int height;
	public Transform[] blocks;
	public Transform[] backg;
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
		OnDrawBlocks ();

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
					if (x>0 && y>0 && x<width-1 && y<height-1){
						if (map[x+1,y+1]==1 || map[x+1,y] == 1||map[x,y+1] ==1 || map[x-1,y-1] == 1 || map[x-1,y] == 1||map[x,y-1] == 1)
						{
						map[x,y] = (psuedoRandom.Next(0,100) < RandFillPercent/1.5)?1:0; 
						}
						else
						{
							map[x,y] = (psuedoRandom.Next(0,100) < RandFillPercent)?1:0;
							//this line basically says that if the Random Number is less 
							//than the RandFillPercent then put a 1 (block) there.  Otherwise 
							//place a 0 (empty).
						}
					}
					else
					{
						map[x,y] = 1;
					}
				}
			}
		}
	}

	void OnDrawBlocks(){
		if (map != null) {
			for (int x = 0; x<width;x++){
				for (int y = 0; y<height;y++){
					if (map[x,y]== 1){
						Transform thisblock = blocks[UnityEngine.Random.Range (0,blocks.Length)];
						Instantiate (thisblock,new Vector2(x,y),Quaternion.identity);
					}
					else
					{
						Transform thisbackg = backg[UnityEngine.Random.Range (0,backg.Length)];
						Instantiate (thisbackg,new Vector2(x,y),Quaternion.identity);
					}
				}
			}
		}
	}
}
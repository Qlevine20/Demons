using UnityEngine;
using System.Collections;
using System;
using System.Linq;

public class MapGenerator : MonoBehaviour {

	public int width;
	public int height;

	public GameObject player;
	private GameObject playerc;


	public GameObject exit;
	private GameObject exitc;


	public Transform[] blocks;
	//list of block types
	public Transform[] backg;
	//list of bacground block stypes
	public string seedname;
	//name of seed so it can be re-used
	public bool UseRandomSeed;
	//Randomly creates new seed

	private bool xfine;
	private bool yfine;

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
		int playerpx = UnityEngine.Random.Range (2, width-2);
		int playerpy = UnityEngine.Random.Range (2, height-2);
		playerc = Instantiate (player,new Vector2 (playerpx, playerpy), Quaternion.identity) as GameObject;
		RandomFillMap ();
		int exitpx = UnityEngine.Random.Range (2, width-2);
		int exitpy = UnityEngine.Random.Range (2, height-2);
		exitc = Instantiate (exit,new Vector2 (exitpx, exitpy), Quaternion.identity) as GameObject;
		GeneratePath ();
		OnDrawBlocks ();


	}

	void RandomFillMap(){
		if (UseRandomSeed) {
			seedname = (UnityEngine.Random.Range (1,9).ToString () + UnityEngine.Random.Range (1,9).ToString () + UnityEngine.Random.Range (1,9).ToString () + UnityEngine.Random.Range (1,9).ToString ());
			//just changing the seedname to something different.
			//Should probably change this
		}
		System.Random psuedoRandom = new System.Random(seedname.GetHashCode());
		//Still not entirely sure how a System.Random object works
		//Something to look into


		for (int x = 0; x<width;x++){
			for (int y = 0; y<height;y++){
				if (x>0 && y>0 && x<width-1 && y<height-1 ){
					if(!playerc.GetComponent<BoxCollider2D>().OverlapPoint(new Vector2(x,y))){
						if (map[x+1,y+1]==1 || map[x+1,y] == 1||map[x,y+1] ==1 || map[x-1,y-1] == 1 || map[x-1,y] == 1||map[x,y-1] == 1)
						{
						map[x,y] = (psuedoRandom.Next(0,100) < RandFillPercent)?1:0; 
						}
						else
						{
							map[x,y] = (psuedoRandom.Next(0,100) < RandFillPercent)?1:0;
							//this line basically says that if the Random Number is less 
							//than the RandFillPercent then put a 1 (block) there.  Otherwise 
							//place a 0 (empty).
						}
					}
				}
				else
				{
					map[x,y] = 1;
				}
			}
		}

		//We need to randomly generate a path from the players start location to wherever the
		//finish area is and then delete and blocks on that path in order to make sure that
		//the player can not get stuck on one of the randomly generated maps.  There has to 
		//be a way out.

	}

	void OnDrawBlocks(){
		if (map != null) {
			for (int x = 0; x<width;x++){
				for (int y = 0; y<height;y++){
					if (map[x,y]== 1){
						Transform thisblock = blocks[UnityEngine.Random.Range (0,blocks.Length)];
						Transform thisbackg = backg[UnityEngine.Random.Range (0,backg.Length)];
						Instantiate (thisblock,new Vector2(x,y),Quaternion.identity);
						Instantiate (thisbackg,new Vector2(x,y),Quaternion.identity);
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



	void GeneratePath(){
		int playerx = (int)(Math.Round(playerc.transform.position.x));
		int playery = (int)(Math.Round(playerc.transform.position.y));
		int exitx = (int)(Math.Round(exitc.transform.position.x));
		int exity = (int)(Math.Round(exitc.transform.position.y));


		while(true){
			break;
			//Using up too much power to create the path with this while loop so I'm putting in a break for now.  Need to make this more efficient.
			int randx = 0;
			int randy = 0;
			if (exitx>=playerx){
				if (UnityEngine.Random.Range(1,100)<RandFillPercent){
					randx = UnityEngine.Random.Range(0,2);
				}
				else{
					randx = (UnityEngine.Random.Range (-1,1));
				}
			}
			if (randx == 0){
				if (exity>=playery){
				randy = 1;
			}
				else{
					randy=-1;
				}
			}
			else{
				randy = 0;
			}
			

			int xchoice = randx+playerx;

			int ychoice = randy+playery;
			if(xchoice <0){
				xchoice = 0;
			}

			if(ychoice <0){
				ychoice = 0;
			}
			if (xchoice>0 && ychoice>0 && xchoice<width-1 && ychoice<height-1&& xchoice*ychoice!=0){
				map[xchoice,ychoice] = 0;
				playerx = xchoice;
				playery = ychoice;

			}
			if(playerx == exitx && playery == exity){
				break;
			}
			
		}
	}
}
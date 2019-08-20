using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class PointsScript : MonoBehaviour {
	[SerializeField] private int cp = 25; // current points 
	[SerializeField] private Text score;
	[SerializeField] private AudioClip hit; // for hit crystals
	[SerializeField] private AudioClip Penalty; //for hit obstacles
	[SerializeField] private AudioSource source;
	[SerializeField] private Camera MC;
	[SerializeField] private GameObject LB;
	private static int cCheck=0;
	private static int counter=0;
	private static int PTS=0;


	void Start () {
		source = GetComponent<AudioSource>();
	}


	void Update () {
		if (cp <= 0) {
			MC.GetComponent<Ball> ().enabled = false;
			MC.GetComponent<AI> ().enabled = false;
			MC.GetComponent<NavMeshAgent> ().enabled = false;
			gameObject.GetComponent<Image> ().color = Color.gray;
			score.text = "" + 0;
			LB.SetActive(true);
			//Debug.Log("GAME OVER");
		}
		if (cCheck != counter) {
			do {
				cp += PTS;
				score.text = "" + cp;
				PTS=0;
				source.clip = hit;
				source.Play ();
				cCheck = counter;
			} while(cCheck != counter);
		}
	}

	public static void points(int pt){
		 PTS += pt;
		counter++;
	}

	public void BallUse(){
		cp -= 1;
		score.text = "" + cp;
	}

	public void ObstacleHit(){
		cp -= 10;
		score.text = "" + cp;
		source.clip = Penalty;
		source.Play();
		//Debug.Log ("You hit an obstacle");
	}
}

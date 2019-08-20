using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSensor : MonoBehaviour {

	public Camera MC;
	public bool Coluna = false;
	public bool MovingObstacle = false;
	public bool Fan = false;
	public bool TP; //manual assignment of Target position
	public float TPos; //TargetPos value
	float TargetPos;
	 
	//public ScriptableObject Script;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		float playerPosZ = MC.transform.position.z;
		float originPos = gameObject.transform.position.z;
		if(TP==true){ TargetPos = originPos-TPos;}else{  TargetPos = originPos - 6;}

//		Debug.Log ("OriginPos for "+gameObject+originPos);
//		Debug.Log ("TargetPos "+TargetPos);

		//if(playerPosZ> ){}
		if(Coluna==true){
			if((playerPosZ>=TargetPos) && (playerPosZ<=originPos)){
				gameObject.GetComponent<Coluna>().enabled = true;
			}

		
		}else if(MovingObstacle==true){
			if((playerPosZ>=TargetPos) && (playerPosZ<=originPos)){
				gameObject.GetComponent<MovingObstacle>().enabled = true;
			}
		}else if(Fan==true){
			if ((playerPosZ >= TargetPos) && (playerPosZ <= originPos)) {
				gameObject.GetComponent<Animator> ().enabled = true;
				} else {
					gameObject.GetComponent<Animator>().enabled = false;
					}
			}
		
	}
}

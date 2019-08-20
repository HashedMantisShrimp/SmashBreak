using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallForce : MonoBehaviour {

	public Ball ball;

	void Start () {
		
	}
	

	void Update () {
		
	}

	public void ballForce(){
		ball.BF = 25;
		ball.counter_switch = true;

	}

	void OnCollisionEnter(Collision collision)
	{
		ballForce ();
		Destroy(gameObject);


	}
}

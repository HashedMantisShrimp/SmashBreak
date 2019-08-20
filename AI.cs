using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AI : MonoBehaviour {


    public Transform goal;
	public float NavSpeed;

	void Start () {
		gameObject.GetComponent<NavMeshAgent> ().speed = NavSpeed;
			
	}


	void Update () {
		//	Debug.Log ("inital speed "+gameObject.GetComponent<NavMeshAgent> ().speed); //3
		//Debug.Log ("initial acc "+gameObject.GetComponent<NavMeshAgent> ().acceleration); //8
        gameObject.GetComponent<NavMeshAgent>().destination = goal.position;
		if(gameObject.transform.position.z >= 46.14){
			gameObject.GetComponent<NavMeshAgent> ().speed = 5.5f;
			Debug.Log ("speed "+gameObject.GetComponent<NavMeshAgent> ().speed);
			Debug.Log ("GotHere2");

		}

		if (gameObject.transform.position.z >= 6.312417 && gameObject.transform.position.z <= 46.14) {
			gameObject.GetComponent<NavMeshAgent> ().speed = 4.5f;
			gameObject.GetComponent<NavMeshAgent> ().acceleration = 9.5f;
			Debug.Log ("speed "+gameObject.GetComponent<NavMeshAgent> ().speed);
			Debug.Log ("GotHere1");
		
		}
	

	}
}

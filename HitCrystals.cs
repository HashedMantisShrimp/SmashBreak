using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HitCrystals : MonoBehaviour {


	float cl; //clip lenght check
	bool ht;
	public int pts = 3;
	public bool parent=false;
	public GameObject prnt;




	void OnCollisionEnter(Collision collision)
	{
		foreach (ContactPoint contact in collision.contacts)
		{
			PointsScript.points(pts);
			if (parent == true)
				Destroy (prnt);
			Destroy(gameObject);
		}

	}


}

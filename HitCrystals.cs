using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HitCrystals : MonoBehaviour {

	public int pts = 3;
	public bool parent=false;
	public GameObject prnt; //Parent obj is attached here

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

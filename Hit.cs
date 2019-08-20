using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Hit : MonoBehaviour {


	void OnCollisionEnter(Collision collision)
	{
		foreach (ContactPoint contact in collision.contacts)
		{
			//Debug.Log("You colided", gameObject);
			Destroy(gameObject);

		}

	}


}

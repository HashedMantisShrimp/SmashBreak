using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger : MonoBehaviour {

	public GameObject Door; //The door obj is attached
	public bool hit = false;
	private IEnumerator StartDoorColl;

	void OnCollisionEnter(Collision collision)
	{
		foreach (ContactPoint contact in collision.contacts)
		{
			
			transform.Translate(0,0.1f,0);

			for (float f = 10f; f >= 0; f -= 1f)
			{	
				Color c = gameObject.GetComponent<Renderer>().material.color;   
				c.b = f;
				c.g = f;
				gameObject.GetComponent<Renderer>().material.color = c;
			}

			this.GetComponent<MeshCollider>().enabled = false;
			if (Door.GetComponent<Animator> ().enabled == true) {
				Door.GetComponent<Animator> ().Play ("DoorCylAnim2", -1, 0.0f);
				StartDoorColl = DoorCollider(0.5f);
				StartCoroutine (StartDoorColl);
			} 

			else {
				hit = true;
				Door.GetComponent<Animator> ().enabled = true;
			}
		}

	}

	private IEnumerator DoorCollider(float waitTime)
	{
		yield return new WaitForSeconds(waitTime);
		Door.GetComponent<MeshCollider> ().enabled = false;
	}
}

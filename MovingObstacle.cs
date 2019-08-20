using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObstacle : MonoBehaviour
{

	public float hspd = 3.0f;
	public bool mov = true;
	public double USLim = -1.6;
	public double DSLim = -12.43;
	
	void Update()
	{
		float trns = Time.deltaTime;
		
		if (mov == true)
		{

			transform.Translate(1 * Vector3.forward * trns * hspd); 
		}
		else
		{
			transform.Translate(1 * Vector3.back * trns * hspd);
		}

		if (transform.position.y >= USLim)
		{
			mov = false;

		}
		else if (transform.position.y <= DSLim)
		{
			mov = true;
		}
	}
}

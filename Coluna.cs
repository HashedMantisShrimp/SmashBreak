using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coluna : MonoBehaviour
{
    public float hspd = 3.0f;
    public bool mov = true;
	public double LSLim = -1.6;
	public double RSLim = -12.43;
	
    void Update()
    {
        float trns = Time.deltaTime;
	
            if (mov == true)
            {
				
                transform.Translate(1 * Vector3.left * trns * hspd); 
            }
            else
            {
                transform.Translate(1 * Vector3.right * trns * hspd);
            }

            if (transform.position.x <= LSLim)
            {
                mov = false;

            }
		else if (transform.position.x >= RSLim)
            {
                mov = true;
            }
    }
}

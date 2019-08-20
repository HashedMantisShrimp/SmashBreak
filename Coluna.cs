using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coluna : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {



    }
    public float hspd = 3.0f;
   // public float vspd = 15.0f;
    public bool mov = true;
   // public bool hit = false;
  //  public double BkLim = -1.6;
  //  public double FwdLim = -12.43;
	public double LSLim = -1.6;
	public double RSLim = -12.43;
   // public Rigidbody rb;



    // Update is called once per frame
    void Update()
    {
        float trns = Time.deltaTime;
       // rb = GetComponent<Rigidbody>();


            if (mov == true)
            {
				
                transform.Translate(1 * Vector3.left * trns * hspd); //v3.up because when i set it to fwd it was moving upwards for whatever reason
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

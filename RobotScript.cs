using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotScript : MonoBehaviour
{

    public float hspd = 50.0f;
    public float vspd = 15.0f;

    void Update()
    {
        float translation = Time.deltaTime;
        transform.Rotate(Input.GetAxis("Horizontal") * Vector3.up * Time.deltaTime * hspd);
        transform.Translate(Input.GetAxis("Vertical") * Vector3.forward * Time.deltaTime * vspd);
   
        if (Input.GetButtonDown("Cancel"))
        {
            Application.Quit(); 
            //print("cancelled");
            gameObject.SetActive(false);
        }

    }

}


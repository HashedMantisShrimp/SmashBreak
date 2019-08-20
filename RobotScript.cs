using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
//using TMPro;

public class RobotScript : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
       // projectile = GetComponent<Rigidbody>();
		//BallC = GameObject.GetComponent<TextMeshProUGUI>();
    }
    public float hspd = 50.0f;
    public float vspd = 15.0f;


    // Update is called once per frame
    void Update()
    {
        float translation = Time.deltaTime;
        transform.Rotate(Input.GetAxis("Horizontal") * Vector3.up * Time.deltaTime * hspd);
        transform.Translate(Input.GetAxis("Vertical") * Vector3.forward * Time.deltaTime * vspd);
   
        if (Input.GetButtonDown("Cancel"))
        {
            Application.Quit(); 
            print("cancelled");
         //   SceneManager.LoadScene("Unity2ndCls 1", LoadSceneMode.Additive);
            gameObject.SetActive(false);
        }

           

    }


    /*void OnCollisionEnter(Collision collision)
    {
        foreach (ContactPoint contact in collision.contacts)
        {
            // Debug.DrawRay(contact.point, contact.normal, Color.red);
             Debug.Log("You colided");

        }

    }


    void OnTriggerEnter(Collider other)
    {
        Destroy(other.gameObject);
        Debug.Log("You triggered", gameObject);
    }*/
}


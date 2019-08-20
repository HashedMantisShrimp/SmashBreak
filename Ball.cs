using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ball : MonoBehaviour
{
	public GameObject im;
	private Touch touch;
    public GameObject temp;
	public int counter=0;
	public bool counter_switch = false;
	public float BF=12; //ball Force
	public PointsScript sm; // PointsScript is attached
	private int Sp=0; //Starting points when ballforce is turned on
	private int Ap; //Actual points
	public Material material1;
	public Material material2;
	Vector3 pos = Vector3.zero, pos1 = Vector3.zero, ms = Vector3.zero, msL = Vector3.zero; 
	Vector2 ScreenCenter = new Vector2(Screen.width/2, Screen.height/2), posL = Vector2.zero, pos1L = Vector2.zero;

    
    void Start()
    {
		Screen.sleepTimeout = SleepTimeout.NeverSleep;
		temp.GetComponent<MeshRenderer> ().material = material2;
    }
    
    void Update()
    {
		ms = Camera.main.ScreenToWorldPoint (new Vector3 (Input.mousePosition.x, Input.mousePosition.y,2));
		msL = new Vector3 (Input.mousePosition.x, Input.mousePosition.y, 0);
		float translation = Time.deltaTime;

		if (Input.touchCount == 1) 
		{
			pos = Camera.main.ScreenToWorldPoint (new Vector3 (Input.GetTouch (0).position.x, 
				Input.GetTouch (0).position.y, 1));
			posL = new Vector2 (Input.GetTouch(0).position.x, Input.GetTouch(0).position.y);
			//Debug.Log (Input.GetTouch (0).position.x);
		}
		if (Input.touchCount == 2) 
		{
			pos = Camera.main.ScreenToWorldPoint (new Vector3 (Input.GetTouch (0).position.x, 
				Input.GetTouch (0).position.y, 1));
			posL = new Vector2 (Input.GetTouch(0).position.x, Input.GetTouch(0).position.y);
			pos1 = Camera.main.ScreenToWorldPoint (new Vector3 (Input.GetTouch (1).position.x, 
				              Input.GetTouch (1).position.y, 1));
			pos1L = new Vector2 (Input.GetTouch(1).position.x, Input.GetTouch(1).position.y);
		}
		
      if(SystemInfo.operatingSystemFamily == OperatingSystemFamily.MacOSX)
        {

			if (Input.GetButtonDown("Fire1"))
       		 {

            GameObject clone;
				clone = Instantiate(temp, ms, transform.rotation) as GameObject;
				
				clone.GetComponent<Rigidbody>().velocity = transform.TransformDirection(new Vector3((msL.x-ScreenCenter.x)/
					(Screen.width/2)*10,(msL.y-ScreenCenter.y)/(Screen.height/2)*7,BF));	
			
				sm.BallUse();

				if (counter_switch == true)
					counter++;

				clone.GetComponent<Rigidbody>().useGravity = true;
				//Debug.Log (msL.x); Debug.Log (msL.y);

        	}

        }

		if(SystemInfo.operatingSystemFamily == OperatingSystemFamily.Windows)
		{
			if (Input.GetButtonDown("Fire1"))
			{

				GameObject clone;
				clone = Instantiate(temp, ms, transform.rotation) as GameObject;
				clone.GetComponent<Rigidbody>().velocity = transform.TransformDirection(new Vector3((msL.x-ScreenCenter.x)/(Screen.width/2)*10,(msL.y-ScreenCenter.y)/(Screen.height/2)*7,BF));	
				sm.BallUse ();
				clone.GetComponent<Rigidbody>().useGravity = true;
				//Debug.Log (msL.x); Debug.Log (msL.y);

			}

		}

		if (SystemInfo.operatingSystemFamily == OperatingSystemFamily.Other )
        {
			if(Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
            {	
				
                GameObject clone;
				if (pos != Vector3.zero) 
				{
					clone = Instantiate (temp, pos, transform.rotation) as GameObject;
					clone.GetComponent<Rigidbody>().velocity = transform.TransformDirection(new Vector3((posL.x-ScreenCenter.x)/(Screen.width/2)*10,(posL.y-ScreenCenter.y)/(Screen.height/2)*7,BF)); 
					clone.GetComponent<Rigidbody> ().useGravity = true;
					sm.BallUse ();
				}
                

            }

			if(Input.touchCount > 1 && Input.GetTouch(1).phase == TouchPhase.Began)
			{				
				GameObject clone;
				clone = Instantiate(temp, pos1, transform.rotation) as GameObject;
				clone.GetComponent<Rigidbody>().velocity = transform.TransformDirection(new Vector3((pos1L.x-ScreenCenter.x)/(Screen.width/2)*10,(pos1L.y-ScreenCenter.y)/(Screen.height/2)*7,BF)); 
				clone.GetComponent<Rigidbody>().useGravity = true;
				sm.BallUse ();
				//Debug.Log(Input.touchCount);
			}

			if (counter_switch == true)
				counter++;
            

        }

		Ap = counter;
		if(counter_switch == true)
		{
			
			if (Sp == 0) 
			{
				Sp = counter;
				//Debug.Log ("Counter switch ON", gameObject);
				temp.GetComponent<MeshRenderer> ().material = material1;
			}
			Debug.Log ("Ap: "+Ap+" Sp: "+Sp, gameObject);

			if ((Sp != 0) && ((Ap - Sp) > 3))
			{ //allow the player to shoot five times then turn the ballforce off
				Debug.Log ("Ap - Sp"+(Ap-Sp), gameObject);
				BF = 12;
				//Debug.Log("BallForce OFF", gameObject);
				temp.GetComponent<MeshRenderer> ().material = material2;
				Sp = 0;
				counter_switch = false;
			}
		}



    }


	private IEnumerator StartColorChange;

	void OnCollisionEnter(Collision collision)
	{
			sm.ObstacleHit ();
			im.GetComponent<Image> ().color = Color.red;
			StartColorChange = ColorChange (0.5f);
			StartCoroutine (StartColorChange);
	}




	private IEnumerator ColorChange(float waitTime)
	{
		//Debug.Log("Change color");
		yield return new WaitForSeconds(waitTime);
		im.GetComponent<Image> ().color = Color.white;

	}



  
}

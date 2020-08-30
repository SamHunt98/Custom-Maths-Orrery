using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour {


    public GameObject Planet;
    Vector3 worldPos;
    public float angle;
    public float orbitSpeed;
    public float speedScalar;
    public Vector3 RotateLocation;
    public GameObject PlanetSelect;
    bool IsFollowing;
    bool returntobase;
    void Start () {

        IsFollowing = false;
    }
	
    //used to zoom the camera into the sun to show off the AABB on the space ship
    //uses the custom LERP function to bring the camera between the start position and the sun

	void Update () {
        
        GameObject controller = GameObject.Find("SpeedController");
        SpeedControl spController = controller.GetComponent<SpeedControl>();
        speedScalar = spController.Speed;
       if(Input.GetKeyDown(KeyCode.Keypad1))
        {
            PlanetSelect = GameObject.Find("Sun");
      
            IsFollowing = true;
            returntobase = false;
        }
   
        if (Input.GetKeyDown(KeyCode.Keypad0))
        {
            returntobase = true;
         
          
           
            IsFollowing = false;
        }

        if(IsFollowing == true & returntobase == false)
        {
            Vector3 temp = PlanetSelect.transform.position;
            Vector3 newPos = new Vector3(temp.x , temp.y + 30, temp.z -50 );
            transform.position = VectorMaths.LERP(transform.position, newPos, Time.deltaTime);
        }
        if (IsFollowing == false & returntobase == true)
        {
            Vector3 temp1 = new Vector3(0, 200, -400);
            transform.position = VectorMaths.LERP(transform.position, temp1, Time.deltaTime);
        }
      

    }
    
}

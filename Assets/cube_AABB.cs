using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cube_AABB : MonoBehaviour {


    public GameObject UFO;
    bool destroyed;
	// Update is called once per frame
    void Start()
    {

        destroyed = false;
    }
	void Update () {
     
        if(destroyed == false)
        {
            //gets the value of the bounding box on the UFO and compares it to a box created around this object.
            UFOStuff UFOScript = UFO.GetComponent<UFOStuff>();
            myAABB UFObox = UFOScript.UFOBOX;
            Vector3 temp = transform.position;
            Vector3 minextent = new Vector3(temp.x - 15, temp.y - 15, temp.z - 15);
            Vector3 maxextent = new Vector3(temp.x + 15, temp.y + 15, temp.z + 15);
            myAABB box = new myAABB(minextent, maxextent);
            //if the bounding box of the UFO intersects with this bounding box the UFO is destroyed
            if (myAABB.Intersects(box, UFObox))
            {
                Destroy(UFO);
                destroyed = true;
            }
        }
      
  
	}
}

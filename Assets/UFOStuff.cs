using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UFOStuff : MonoBehaviour {
    public myAABB UFOBOX;
    float distance;

	
    //will move slowly towards the sun until it collides
	void Update () {
        distance += Time.deltaTime;
       transform.position = new Vector3(-40 + distance, 0, -10);
        Vector3 temp = transform.position;
        //creating the bounding box for the UFO
        Vector3 minextent = new Vector3(temp.x - 4, temp.y - 4, temp.z - 4);
        Vector3 maxextent = new Vector3(temp.x + 4, temp.y + 4, temp.z + 4);
        UFOBOX = new myAABB(minextent, maxextent);
    }
}

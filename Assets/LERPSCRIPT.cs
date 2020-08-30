using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LERPSCRIPT : MonoBehaviour {

    //UNUSED SCRIPT 
    //
    //
    //

    Vector3 NewPos = new Vector3();
    void Start () {
      
        NewPos = GameObject.Find("ServerPos").transform.position;
        

	}
	

	void Update () {
        transform.position = VectorMaths.LERP(transform.position, NewPos, Time.deltaTime);
	}
}

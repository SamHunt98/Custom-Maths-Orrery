using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedControl : MonoBehaviour {

    //stores the float that is used to determine the speed at which planets orbit.
    public float Speed;
	void Start () {
        Speed = 0.5f;
	}
	
}

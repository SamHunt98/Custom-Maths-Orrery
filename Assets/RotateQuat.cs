using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateQuat : MonoBehaviour {
  
    float t;

	void Start () {
        t = 0;
	}
	
	// Update is called once per frame
	void Update () {

        t += Time.deltaTime * 0.5f;
        //defining two rotations
        Quat q = new Quat(Mathf.PI * 1.0f, new Vector3(0, 1, 0));
        Quat r = new Quat(Mathf.PI * 0.5f, new Vector3(1, 0, 0));
        //slerped value
        Quat slerped = Quat.SLERP(q, r, t);
        //define vector that will be rotated
        Vector3 p = new Vector3(0, 8, 0);
        //store that vector in a quaternion
        Quat K = new Quat(p);
        //newk will have new position inside
        Quat newK = slerped * K * slerped.Inverse();
        //get this position as avector
        Vector3 newP = newK.GetAxis();
        transform.position = newP;

	}
}

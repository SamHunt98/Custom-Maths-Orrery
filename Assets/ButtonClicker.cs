using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonClicker : MonoBehaviour {


    public GameObject controller;
    SpeedControl spController;
    void Start () {
        controller = GameObject.Find("SpeedController");
        spController = controller.GetComponent<SpeedControl>();
	}
	
    //controls the speed settings for the simulation depending on which button is pressed.
    public void ButtonClick1()
    {
       
        spController.Speed = 1.0f;
    }
    public void ButtonClick2()
    {
        spController.Speed = 2.0f;
    }
    public void  ButtonClick3()
    {
        spController.Speed = 0.5f;
    }
}

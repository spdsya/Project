using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Btn : MonoBehaviour
{
    public void EngineUp() {
        GameObject.Find("Car").GetComponent<CarControllerDisplay>().CarOptions.MaxSpeed +=150;   
    }

    public void EngineDown() {
        GameObject.Find("Car").GetComponent<CarControllerDisplay>().CarOptions.MaxSpeed -=150;   
    }

    public void TorqueUp() {
        GameObject.Find("Car").GetComponent<CarControllerDisplay>().CarOptions.motorForce +=150;   
    }

    public void TorqueDown() {
        GameObject.Find("Car").GetComponent<CarControllerDisplay>().CarOptions.motorForce -=150;   
    }

    public void Hard() {
        GameObject.Find("Car").GetComponent<CarControllerDisplay>().susStep +=0.1;   
    }

    public void Soft() {
        GameObject.Find("Car").GetComponent<CarControllerDisplay>().susStep -=0.1;   
    }
}

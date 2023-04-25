using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CarControllerDisplay : MonoBehaviour {

    public CarController CarOptions;
    private WheelJoint2D[] Wheels;
    private WheelJoint2D FrontWheel;
    private WheelJoint2D RearWheel;
    public JointMotor2D motorFront;
    public JointMotor2D motorRear;
    public double susStep;
    public double dR;

    private Text SpeedText;
    private Text GearText;
    private Text EngineText;
    private Text TorqueText;
    private Text TireText;

    private float carSpeed;
    private float carMotorforce;
    private float mySpeed;
    private float myMotorforce;
    private float myMassFrontWheel;
    private float myMassRearWheel;
    private string mySpeedString;
    private string myGearString;
    private string myEngineString;
    private string myTorqueString;
    private string myTireString;

    void Start()
    {
        susStep = 0.2f;
        CarOptions.currentTransmission = 3;
        Wheels = GetComponents<WheelJoint2D>();
        for(int i=0; i < Wheels.Length; i++)
        {
            FrontWheel = Wheels[0];
            RearWheel = Wheels[1];
        }
        GetComponent<Rigidbody2D>().mass = CarOptions.CarMass / 10f;
        FrontWheel.connectedBody.mass = CarOptions.FrontWheelMass;
        RearWheel.connectedBody.mass = CarOptions.RearWheelMass;
        mySpeedString = CarOptions.SpeedTextName;
        myGearString = CarOptions.GearTextName;
        myEngineString = CarOptions.EngineTextName;
        myTorqueString = CarOptions.TorqueTextName;
        myTireString = CarOptions.TireTextName;
        var FrontWheelNew = new WheelJoint2D();
        //FrontWheel.m_Suspension.m_DampingRatio = 0.2f;
        //FrontWheel = FrontWheelNew;
    }

    void FixedUpdate () {
        HUD();
        TransmissionsStart();
        Movement();
    }

    void Update()
    {
        if(CarOptions == null)
        {
            Debug.LogWarning("Assets -> Create -> Car Controller -> Create Car Controller");
        }
        if (CarOptions.currentTransmission >= CarOptions.Transmission.Length)
        {
            CarOptions.currentTransmission = CarOptions.Transmission.Length;
        }
    }

    void HUD()
    {
        float mySpeedCar = gameObject.GetComponent<Rigidbody2D>().velocity.magnitude * 3.6f;
        float SpeedCar = Mathf.Round(mySpeedCar);
        int myGear = CarOptions.currentTransmission;
        float myEngine = CarOptions.MaxSpeed;
        float myTorque = CarOptions.motorForce;
        //int myTire = gameObject.Find(Wheel).GetComponent<Friction>;
        //FrontWheel.suspension = susStep;
        GearText = GameObject.Find(myGearString).GetComponent<Text>();
        if(GearText != null)
        {
            GearText.text = "Gear: " + myGear.ToString();
        }
        SpeedText = GameObject.Find(mySpeedString).GetComponent<Text>();
        if (SpeedText != null)
        {
            SpeedText.text = "Speed: " + SpeedCar.ToString();
        }
        EngineText = GameObject.Find(myEngineString).GetComponent<Text>();
        if (EngineText != null)
        {
            EngineText.text = "Engine: " + myEngine.ToString();
        }
        TorqueText = GameObject.Find(myTorqueString).GetComponent<Text>();
        if (TorqueText != null)
        {
            TorqueText.text = "Torque: " + myTorque.ToString();
        }
        /*TireText = GameObject.Find(myTireString).GetComponent<Text>();
        if (TireText != null)
        {
            TireText.text = "Tire: " + MyTire.ToString();
        }*/
        
    }

    void TransmissionsStart()
    {
        for (int i = CarOptions.currentTransmission; i < CarOptions.Transmission.Length; i++)
        {
            CarOptions.Transmission[i] = false;
        }

        if (CarOptions.currentTransmission <= 0)
        {
            CarOptions.Transmission[0] = false;
            CarOptions.Transmission[1] = false;
            CarOptions.Transmission[2] = false;
            CarOptions.Transmission[3] = false;
            CarOptions.Transmission[4] = false;
            CarOptions.Transmission[5] = false;
            CarOptions.Transmission[6] = false;
            CarOptions.currentTransmission = 0;
            mySpeed = 0;
            myMotorforce = 0;
        }
        if (CarOptions.currentTransmission == 1)
        {
            CarOptions.Transmission[0] = true;
        }
        if (CarOptions.currentTransmission == 2)
        {
            CarOptions.Transmission[1] = true;
        }
        if (CarOptions.currentTransmission == 3)
        {
            CarOptions.Transmission[2] = true;
        }
        if (CarOptions.currentTransmission == 4)
        {
            CarOptions.Transmission[3] = true;
        }
        if (CarOptions.currentTransmission == 5)
        {
            CarOptions.Transmission[4] = true;
        }
        if (CarOptions.currentTransmission == 6)
        {
            CarOptions.Transmission[5] = true;
        }
        if (CarOptions.currentTransmission == 7)
        {
            CarOptions.Transmission[6] = true;
        }
    }

    void Movement()
    {
        if (CarOptions.FWD == false && CarOptions.RWD == false)
        {
            CarOptions.RWD = true;
            CarOptions.FWD = true;
        }

        carSpeed = CarOptions.MaxSpeed * 11.53846153846154f;
        carMotorforce = CarOptions.motorForce;

        
        if (CarOptions.Transmission[0] == true)
        {
            mySpeed = carSpeed / CarOptions.gearRatio[0];
            myMotorforce = carMotorforce * CarOptions.gearRatio[0];
        }

        if (CarOptions.Transmission[1] == true)
        {
            mySpeed = carSpeed / CarOptions.gearRatio[1];
            myMotorforce = carMotorforce * CarOptions.gearRatio[1];
            CarOptions.Transmission[0] = false;
        }

        if (CarOptions.Transmission[2] == true)
        {
            CarOptions.Transmission[0] = false;
            CarOptions.Transmission[1] = false;
            mySpeed = carSpeed / CarOptions.gearRatio[2];
            myMotorforce = carMotorforce * CarOptions.gearRatio[2];
        }
        if (CarOptions.Transmission[3] == true)
        {
            CarOptions.Transmission[0] = false;
            CarOptions.Transmission[1] = false;
            CarOptions.Transmission[2] = false;
            mySpeed = carSpeed / CarOptions.gearRatio[3];
            myMotorforce = carMotorforce * CarOptions.gearRatio[3];
        }
        if (CarOptions.Transmission[4] == true)
        {
            CarOptions.Transmission[0] = false;
            CarOptions.Transmission[1] = false;
            CarOptions.Transmission[2] = false;
            CarOptions.Transmission[3] = false;
            mySpeed = carSpeed / CarOptions.gearRatio[4];
            myMotorforce = carMotorforce * CarOptions.gearRatio[4];
        }
        if (CarOptions.Transmission[5] == true)
        {
            CarOptions.Transmission[0] = false;
            CarOptions.Transmission[1] = false;
            CarOptions.Transmission[2] = false;
            CarOptions.Transmission[3] = false;
            CarOptions.Transmission[4] = false;
            mySpeed = carSpeed / CarOptions.gearRatio[5];
            myMotorforce = carMotorforce * CarOptions.gearRatio[5];
        }
        if (CarOptions.Transmission[6] == true)
        {
            CarOptions.Transmission[0] = false;
            CarOptions.Transmission[1] = false;
            CarOptions.Transmission[2] = false;
            CarOptions.Transmission[3] = false;
            CarOptions.Transmission[4] = false;
            CarOptions.Transmission[5] = false;
            mySpeed = carSpeed / CarOptions.gearRatio[6];
            myMotorforce = carMotorforce * CarOptions.gearRatio[6];
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            CarOptions.currentTransmission++;  
        }
        if (Input.GetKeyDown(KeyCode.Z) && CarOptions.currentTransmission > 0)
        {
           CarOptions.currentTransmission--;
        }

        if (GameObject.Find("Acc").GetComponent<AccV>().accClick)
        {
            motorFront.motorSpeed = -mySpeed;
            if (CarOptions.FWD == true)
            {
                motorFront.maxMotorTorque = myMotorforce;
            }
            FrontWheel.motor = motorFront;

            motorRear.motorSpeed = -mySpeed;
            if (CarOptions.RWD == true)
            {
                motorRear.maxMotorTorque = myMotorforce;
            }
            RearWheel.motor = motorRear;
        }
        else if (GameObject.Find("Brake").GetComponent<BrakeV>().brakeClick)
        {
            motorFront.motorSpeed = +mySpeed;
            if (CarOptions.FWD == true)
            {
                motorFront.maxMotorTorque = myMotorforce;
            }
            FrontWheel.motor = motorFront;

            motorRear.motorSpeed = +mySpeed;
            if (CarOptions.RWD == true)
            {
                motorRear.maxMotorTorque = myMotorforce;
            }
            RearWheel.motor = motorRear;
        }
        else
        {
            motorFront.motorSpeed = 0;
            motorFront.maxMotorTorque = 0;
            FrontWheel.motor = motorFront;

            motorRear.motorSpeed = 0;
            motorRear.maxMotorTorque = 0;
            RearWheel.motor = motorRear;
        }
        
    }
}

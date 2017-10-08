using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;


public class SerialTransform : MonoBehaviour
{

    public float speedYRotation = 10;
    SerialPort sp = new SerialPort("COM1", 9600);
    private string str = "";
    // Use this for initialization
    void Start()
    {
        sp.Open();
       
    }

    // Update is called once per frame
    void Update()
    {


        if (sp.IsOpen)
        {
            str = sp.ReadLine();
            if (sp.ReadLine() == "1")
            {

                transform.Rotate(1 * Vector3.up * speedYRotation * Time.deltaTime);
                Debug.Log("1");
            }
            else if (sp.ReadLine() == "-1")
            {
                transform.Rotate(-1 * Vector3.up * speedYRotation * Time.deltaTime);
                Debug.Log("-1");
            }


        }
        else { sp.Open(); }



    }
}
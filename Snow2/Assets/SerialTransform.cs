using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;
using System.IO;


public class SerialTransform : MonoBehaviour
{

    public float speedYRotation = 10;
    SerialPort sp = new SerialPort("COM5", 9600);
    private string str = "";
    // Use this for initialization
    void Start()
    {
        sp.Open();
    }

    // Update is called once per frame
    void Update()
    {


        if (!sp.IsOpen)
        {
            sp.Open();
        }

        float num = int.Parse(sp.ReadLine());

        str = sp.ReadLine();
        Debug.Log(str);

        if (sp.ReadLine() == "0/0")
        {

            transform.Rotate(1 * Vector3.up * speedYRotation * Time.deltaTime);
            Debug.Log("1");
        }
        else if (sp.ReadLine() == "-1")
        {
            transform.Rotate(-1 * Vector3.up * speedYRotation * Time.deltaTime);
            Debug.Log("-1");
        }



        /*
        if (sp != null)
        {
            using (StreamReader Lol = new StreamReader(sp.BaseStream))
            {
                str = Lol.ReadLine();
            }
        }
        Debug.Log(str);
        */

    }
}
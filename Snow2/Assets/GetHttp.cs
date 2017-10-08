using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;


public class GetHttp : MonoBehaviour {

    public Transform from;
    public Transform to;
    public float speed = 0.9f;
    public float speedXRotation = 50;
    int count = 0;
    public string pos = "180.00/180.00";
    public float speedYRotation = 10;

    private void Start()
    {
        from = this.transform;
    }

    public IEnumerator GET()
    {
            WWW Query = new WWW("http://192.168.4.1/artempidorka");
            yield return Query;
            pos = Query.text;
            Debug.Log("Log" + pos);
            Query.Dispose();
    }

    int[] getCoordinats()
    {
        int[] coords = new int[2];
        StartCoroutine(GET());
        
        string s1="";
        string s2="";

        
        for (int i = 0; i < pos.Length; i++) {
            if (!(pos[i]=='/'))
            {
                s1 += pos[i];
            }
            else for (; i < pos.Length; i++)
            {
                s2 += pos[i];
            }

        }
       // Debug.Log("s1=" + s1);
       // Debug.Log("s2=" + s2);

        coords[0] = Int_parser(s1);
        coords[1] = Int_parser(s2);
        Debug.Log("s1=" + coords[0]);
        Debug.Log("s2=" + coords[1]);

        return coords;

    }


    private int Int_parser(String to_parse)
    {
        int k = 1;
        int ret_int = 0;
        for (int i = to_parse.Length-1; i >= 0; i--)
        {
            switch (to_parse[i])
            {
                case '0': break;
                case '1': ret_int += k; break;
                case '2': ret_int += 2*k; break;
                case '3': ret_int += 3 * k; break;
                case '4': ret_int += 4 * k; break;
                case '5': ret_int += 5 * k; break;
                case '6': ret_int += 6 * k; break;
                case '7': ret_int += 7 * k; break;
                case '8': ret_int += 8 * k; break;
                case '9': ret_int += 9 * k; break;
            }
            k *= 10;
        }
        return ret_int;
    }

    int[] coords;

    void Update()
    {
        if (count == 30)
        {
            StartCoroutine(GET());
            coords = getCoordinats();
            count = 0;
        }
        else count++;

        //Debug.Log("x"+coords[0]);
        //Debug.Log("y"+coords[1]);
        if ((coords[1] < 175) && (coords[1]!=0)) {
           transform.Rotate(-Vector3.forward * speedXRotation * Time.deltaTime);
            //to.rotation = this.transform.rotation;
            //this.transform.rotation = Quaternion.Lerp(from.rotation, to.rotation ,Time.time *speed);
        }
        else if (coords[1] > 195)
        {
            transform.Rotate(Vector3.forward * speedXRotation * Time.deltaTime);
            //to.rotation = this.transform.rotation;
            //this.transform.rotation = Quaternion.Lerp(from.rotation, to.rotation, Time.time * speed);
        }
        

        }



}



    
   


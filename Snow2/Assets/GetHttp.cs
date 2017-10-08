using System.Collections;

using System.Collections.Generic;
using UnityEngine;


public class GetHttp : MonoBehaviour {


   private string Url = @"http://192.168.4.1/";
    public string pos = "";
    public float speedYRotation = 10;

    public IEnumerator GET()
    {
            WWW Query = new WWW("http://192.168.4.1/artempidorka");
            yield return Query;
            pos = Query.text;
            Debug.Log("Log" + Query.text);
            Query.Dispose();
    }

    int[] getCoordinats()
    {
        int[] coords = new int[2];
        StartCoroutine(GET());


        int k = pos.IndexOf(' ');
        


        string s1="";
        string s2="";

        
        for (int i = 0; i <= pos.Length-1; i++) {
            if (i < k)
            {
                s1 += pos[i];

            }
            else
            {
                s2 += pos[i];
            }

        }
        
        
        try
        {
            coords[0] = System.Convert.ToInt32(s1);
            coords[1] = System.Convert.ToInt32(s2);


        }
        catch (System.Exception) { }


        return coords;

    }




    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            StartCoroutine(GET());
            //int[] coords = getCoordinats();}

            //Debug.Log("x"+coords[0]);
            //Debug.Log("y"+coords[1]);
                

        //transform.Rotate(coords[1] * Vector3.up * speedYRotation * Time.deltaTime);



        }


    }



}



    
   


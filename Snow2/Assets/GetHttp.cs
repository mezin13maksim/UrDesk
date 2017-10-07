using System.Collections;

using System.Collections.Generic;
using UnityEngine;


public class GetHttp : MonoBehaviour {


    public string Url = "http://192.168.4.1/artempidorka";
    private string pos = "0 0";

    
    public IEnumerator GET()
    {
        string str = "";
        
            WWW Query = new WWW(Url);
            yield return Query;
            pos = Query.text;
            Query.Dispose();
    }

    int[] getCoordinats()
    {
        int[] coords = new int[2];
        StartCoroutine(GET());

        int k = pos.IndexOf(' ');
        Debug.Log("k");

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
            int[] coords = getCoordinats();

            Debug.Log("x"+coords[0]);
            Debug.Log("y" + coords[1]);

        }


    }



}



    
   


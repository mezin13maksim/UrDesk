using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class upColliderScript : MonoBehaviour
{

    // Use this for initialization

    public bool onTrig = false;

    void OnTriggerEnter()
    {
        onTrig = true;
        
    }
    void OnTriggerExit()
    {
        onTrig = false;
       
    }
}
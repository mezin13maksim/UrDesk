using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bot : MonoBehaviour {
    public GameObject point_0;
    public GameObject point_1;
    public GameObject point_2;

    Transform[] all_Point = new Transform[3];

    private Vector3 target_Pos;

    private int i = 0;
    public float speed_move = 5f;

    // Use this for initialization
    void Start () {

        point_0 = GameObject.FindGameObjectWithTag("Point1");
        point_1 = GameObject.FindGameObjectWithTag("Point2");
        point_2 = GameObject.FindGameObjectWithTag("Point3");

        all_Point[0] = point_0.transform;
        all_Point[1] = point_1.transform;
        all_Point[2] = point_2.transform;

    }

    // Update is called once per frame
    void Update()
    {
       // if (SnowboardScript.script_flag)
        //{
            target_Pos = all_Point[1].transform.position;
            transform.Translate(Vector3.Normalize(target_Pos - transform.position) * Time.deltaTime * speed_move);
            float distance = Vector3.Distance(target_Pos, transform.position);
            if (distance < 0.5f)
            {
                if (i < all_Point.Length - 1)
                {
                    i++;
                }
                else
                {
                    Destroy(gameObject);
                }
            }

        //}
    }
}

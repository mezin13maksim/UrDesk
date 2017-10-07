using UnityEngine;
using System.Collections;

public class SnowboardScript : MonoBehaviour
{


    public float speed = 100;
    public float speedYRotation = 100;
    public float speedXRotation = 200;
    public float jumpForce = 100;
    public float maxSpeed = 20;
    public Vector3 flyRayBeginPosition = new Vector3(0, 0, 0);
    bool isFly=false;
    // Use this for initialization
    void Start()
    {
    }

    void OnTriggerEnter() {
        isFly = false;
        
    }
    void OnTriggerExit()
    {
        isFly = true;
        
    }
    // Update is called once per frame
    void Update()
    {
        if (!isFly)
        {

            if (Input.GetKeyDown(KeyCode.Space)) transform.GetComponent<Rigidbody>().AddForce(transform.up * jumpForce, ForceMode.Force);
            if (Input.GetKey(KeyCode.D)) transform.Rotate(Vector3.up * speedYRotation * Time.deltaTime);
            if (Input.GetKey(KeyCode.A)) transform.Rotate(-Vector3.up * speedYRotation * Time.deltaTime);
            if (transform.GetComponent<Rigidbody>().velocity.magnitude < maxSpeed) transform.GetComponent<Rigidbody>().AddForce(transform.forward * Input.GetAxis("Vertical") * speed * Time.deltaTime);


        }
        else {
            if (Input.GetKey(KeyCode.W)) transform.Rotate(Vector3.right * speedXRotation * Time.deltaTime);
            if (Input.GetKey(KeyCode.S)) transform.Rotate(-Vector3.right * speedXRotation * Time.deltaTime);
            if (Input.GetKey(KeyCode.D)) transform.Rotate(Vector3.up * speedXRotation * Time.deltaTime);
            if (Input.GetKey(KeyCode.A)) transform.Rotate(-Vector3.up * speedXRotation * Time.deltaTime);
        }
            
            
    }
}
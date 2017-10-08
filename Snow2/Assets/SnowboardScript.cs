using UnityEngine;
using System.Collections;

public class SnowboardScript : MonoBehaviour
{
    //public static bool script_flag = false;
    //public GameObject Sphere;
    public float speed = 100;
    public float speedYRotation = 100;
    public float speedXRotation = 200;
    public float jumpForce = 100;
    public float maxSpeed = 20;
    public Vector3 flyRayBeginPosition = new Vector3(0, 0, 0);
    public GameObject upColider;
    public bool flopOrRespawn = true;
    public Vector3 respawnPos = Vector3.zero;
    public Vector3 respawnRot = Vector3.zero;
    bool isFly = false;

    // Use this for initialization

    void flop()

    {
        this.GetComponent<Rigidbody>().angularVelocity = new Vector3(0, 0, 0);
        this.transform.Translate(new Vector3(0, 0, 1f));
        float t = this.transform.rotation.eulerAngles.z;
        this.transform.rotation = new Quaternion(0, 0, 0, 0);
<<<<<<< HEAD
        this.transform.Rotate(0, t, 0);
        this.transform.Translate(new Vector3(0, 1, 0));
=======
        this.transform.Rotate(0,0,t);
        this.transform.Translate(new Vector3(0, 0, 1));
>>>>>>> 4fdfd9597f62fa1a31ae21c08cfc56fe6937abb5
        Debug.Log("Flop");

    }

    void respawn()
    {
        this.GetComponent<Rigidbody>().angularVelocity = new Vector3(0, 0, 0);
        this.transform.rotation = new Quaternion(0, 0, 0, 0);
        this.transform.Rotate(respawnRot);
        this.transform.position = respawnPos;
    }

    void Start()
    {
    }

    void OnTriggerEnter()
    {

        isFly = false;
    }
    void OnTriggerExit()
    {
        isFly = true;

    }
    // Update is called once per frame
    void Update()
    {



        if (upColider.GetComponent<upColliderScript>().onTrig)
        {
            if (flopOrRespawn)
                flop();
            else
                respawn();
        }



        if (!isFly)
        {

<<<<<<< HEAD
            transform.Rotate(Input.GetAxis("Horizontal") * Vector3.up * speedYRotation * Time.deltaTime);
            transform.GetComponent<Rigidbody>().AddForce(transform.forward * Input.GetAxis("Vertical") * speed * Time.deltaTime);

            if (Input.GetKeyDown(KeyCode.Space)) transform.GetComponent<Rigidbody>().AddForce(transform.up * jumpForce, ForceMode.Force);

            /* if (Input.GetKey(KeyCode.D)) transform.Rotate(Vector3.up * speedYRotation * Time.deltaTime);
             if (Input.GetKey(KeyCode.A)) transform.Rotate(-Vector3.up * speedYRotation * Time.deltaTime);
             if (transform.GetComponent<Rigidbody>().velocity.magnitude < maxSpeed) transform.GetComponent<Rigidbody>().AddForce(transform.forward * Input.GetAxis("Vertical") * speed * Time.deltaTime);
             */

        }
        else
        {
            if (Input.GetKey(KeyCode.W)) transform.Rotate(Vector3.right * speedXRotation * Time.deltaTime);
            if (Input.GetKey(KeyCode.S)) transform.Rotate(-Vector3.right * speedXRotation * Time.deltaTime);
=======
            transform.Rotate(Input.GetAxis("Horizontal") *Vector3.forward * speedYRotation * Time.deltaTime);
            transform.GetComponent<Rigidbody>().AddForce(transform.up * Input.GetAxis("Vertical") * speed * Time.deltaTime);

            if (Input.GetKeyDown(KeyCode.Space)) transform.GetComponent<Rigidbody>().AddForce(transform.forward * jumpForce, ForceMode.Force);
            
           /* if (Input.GetKey(KeyCode.D)) transform.Rotate(Vector3.up * speedYRotation * Time.deltaTime);
            if (Input.GetKey(KeyCode.A)) transform.Rotate(-Vector3.up * speedYRotation * Time.deltaTime);
            if (transform.GetComponent<Rigidbody>().velocity.magnitude < maxSpeed) transform.GetComponent<Rigidbody>().AddForce(transform.forward * Input.GetAxis("Vertical") * speed * Time.deltaTime);
            */

        }
        else {

            transform.Rotate(Input.GetAxis("Horizontal") * Vector3.forward * speedXRotation * Time.deltaTime);
            transform.Rotate(Input.GetAxis("Vertical") * Vector3.left * speedYRotation * Time.deltaTime);
            /*
            if (Input.GetKey(KeyCode.W)) transform.Rotate(-Vector3.right * speedXRotation * Time.deltaTime);
            if (Input.GetKey(KeyCode.S)) transform.Rotate(Vector3.right * speedXRotation * Time.deltaTime);

>>>>>>> 4fdfd9597f62fa1a31ae21c08cfc56fe6937abb5
            if (Input.GetKey(KeyCode.D)) transform.Rotate(Vector3.up * speedXRotation * Time.deltaTime);
            if (Input.GetKey(KeyCode.A)) transform.Rotate(-Vector3.up * speedXRotation * Time.deltaTime);*/
        }

        //     }
    }

   // void OnTriggerEnter(Collider other)
    //{
      //  if (other.gameObject.CompareTag("Trigger"))
       // {
       //     script_flag = true;
       // }
    //}
}
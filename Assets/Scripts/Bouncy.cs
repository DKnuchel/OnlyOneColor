using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bouncy : MonoBehaviour
{
    bool shouldJump = false;

    [SerializeField] GameObject masterController = null;

    MasterScript masterScript;
    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        masterScript = masterController.GetComponent<MasterScript>();
    }


    private void FixedUpdate()
    {
        if(shouldJump && masterScript.isBouncing())
        {
            Debug.Log("Bounce");
            rb.AddForce(0, 10, 0, ForceMode.VelocityChange);
        }
        
        shouldJump = false;
    }

    void OnCollisionEnter(Collision collision)
    {
        shouldJump = true;
        rb.velocity = Vector3.zero;
    }

    void OnCollisionStay(Collision collision)
    {
        shouldJump = true;
        rb.velocity = Vector3.zero;
    }
}

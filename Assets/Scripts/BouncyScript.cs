using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BehaviourScript))]
[RequireComponent(typeof(Rigidbody))]
public class BouncyScript : MonoBehaviour
{
    BehaviourScript behaviourScript = null;
    bool shouldJump = false;
    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        behaviourScript = GetComponent<BehaviourScript>();
    }


    private void FixedUpdate()
    {
        if(shouldJump && behaviourScript.isBouncing())
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

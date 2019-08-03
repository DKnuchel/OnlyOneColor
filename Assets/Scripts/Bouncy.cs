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
        var relativePosition = Quaternion.Inverse(transform.rotation) * collision.GetContact(0).normal;
        if (Mathf.Abs(relativePosition.x) < Mathf.Abs(relativePosition.y) && relativePosition.y > 0)
        {
            Debug.Log("Should jump");
            shouldJump = true;
        }
    }

    void OnCollisionStay(Collision collision)
    {
        var relativePosition = Quaternion.Inverse(transform.rotation) * collision.GetContact(0).normal;
        if (Mathf.Abs(relativePosition.x) < Mathf.Abs(relativePosition.y) && relativePosition.y > 0)
        {
            Debug.Log("Should jump");
            shouldJump = true;
        }
        else
        {
            shouldJump = false;
        }
    }
}

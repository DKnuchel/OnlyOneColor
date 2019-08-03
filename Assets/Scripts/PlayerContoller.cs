using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerContoller : MonoBehaviour
{
    [SerializeField] GameObject masterController;

    MasterScript masterScript;

    bool isCollided = false;
    Rigidbody rb;
    int speedMultiplier = 3;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        masterScript = masterController.GetComponent<MasterScript>();
    }
    void FixedUpdate()
    {
        if(isCollided)
        {
            float multiplier = 1f / (1f + rb.velocity.magnitude * 2);
            bool isSpeedBoosted = masterScript.isSpeedBoosted();
            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            {
                if (isSpeedBoosted)
                { 
                    rb.AddForce(new Vector3(-10 * speedMultiplier, 0, 0) * multiplier, ForceMode.VelocityChange);
                } else
                {
                    rb.AddForce(new Vector3(-10, 0, 0) * multiplier, ForceMode.VelocityChange);
                }
            }
            else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            {
                if (isSpeedBoosted)
                {
                    rb.AddForce(new Vector3(10 * speedMultiplier, 0, 0) * multiplier, ForceMode.VelocityChange);
                } else
                {
                    rb.AddForce(new Vector3(10, 0, 0) * multiplier, ForceMode.VelocityChange);
                }
            }
        } else
        {
            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            {
                rb.AddForce(new Vector3(-0.2f, 0, 0), ForceMode.VelocityChange);
            }
            else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            {
                rb.AddForce(new Vector3(0.2f, 0, 0), ForceMode.VelocityChange);
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        isCollided = true;
    }

    void OnCollisionStay(Collision collision)
    {
        isCollided = true;
        rb.velocity *= 0.8f;
    }

    private void OnCollisionExit(Collision collision)
    {
        isCollided = false;
    }
}

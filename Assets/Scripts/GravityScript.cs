using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BehaviourScript))]
[RequireComponent(typeof(Rigidbody))]
public class GravityScript : MonoBehaviour
{
    BehaviourScript behaviourScript = null;

    MasterScript masterScript;
    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        behaviourScript = GetComponent<BehaviourScript>();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if (behaviourScript.IsGravitationalReversed())
        {
            rb.AddForce(Physics.gravity * -2);
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BlockBehaviourScript))]
[RequireComponent(typeof(Rigidbody))]
public class GravityScript : MonoBehaviour
{
    BlockBehaviourScript behaviourScript = null;

    MasterScript masterScript;
    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        behaviourScript = GetComponent<BlockBehaviourScript>();
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
﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BehaviourScript))]
[RequireComponent(typeof(Rigidbody))]
public class GhostScript : MonoBehaviour
{
    BehaviourScript behaviourScript = null;

    Collider collider = null;

    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        behaviourScript = GetComponent<BehaviourScript>();
        collider = GetComponent<Collider>();

        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if (behaviourScript.isGhostActivated())
        {
            collider.enabled = false;
            rb.constraints = RigidbodyConstraints.FreezePosition;
        }
        else
        {
            collider.enabled = true;
            rb.constraints = RigidbodyConstraints.None;
            rb.constraints = RigidbodyConstraints.FreezeRotation | RigidbodyConstraints.FreezePositionZ;
        }
    }
}
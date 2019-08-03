using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : MonoBehaviour
{
    Collider collider = null;
    [SerializeField] GameObject masterController = null;

    MasterScript masterScript;
    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        masterScript = masterController.GetComponent<MasterScript>();
        collider = GetComponent<Collider>();

        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if (masterScript.isGhostActivated())
        {
            collider.enabled = false;
            rb.constraints = RigidbodyConstraints.FreezePosition;
        } else
        {
            collider.enabled = true;
            rb.constraints = RigidbodyConstraints.None;
            rb.constraints = RigidbodyConstraints.FreezeRotation | RigidbodyConstraints.FreezePositionZ;
        }
    }
}

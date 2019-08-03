using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravitation : MonoBehaviour
{
    [SerializeField] GameObject masterController = null;

    MasterScript masterScript;
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        masterScript = masterController.GetComponent<MasterScript>();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if (masterScript.isGravitationalReversed())
        {
            rb.AddForce(Physics.gravity * -2);

        }
    }
}
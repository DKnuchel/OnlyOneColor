using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sticky : MonoBehaviour
{
    [SerializeField] GameObject masterController = null;

    MasterScript masterScript;
    Rigidbody rb;
    float size = 0.01f;
    float angle;
    int contactSide = 4; // 0 = T, 1 = R, 2 = B, 3 = L, 4 = no collision
    float transformValue;
    GameObject collisionObject;



    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        masterScript = masterController.GetComponent<MasterScript>();
        transformValue = transform.localScale.x / 4;


    }

    // Update is called once per frame
    void Update()
    {
        if (masterScript.isSticky())
        {
            while(contactSide == 1 || contactSide == 3)
            {
                rb.velocity = new Vector3(collisionObject.GetComponent<Rigidbody>().velocity.x,collisionObject.GetComponent<Rigidbody>().velocity.y,0);

            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        var relativePosition = Quaternion.Inverse(transform.rotation) * collision.GetContact(0).normal;





        if (Mathf.Abs(relativePosition.x) < Mathf.Abs(relativePosition.y))
        {
            if (relativePosition.y < 0)
            {
                contactSide = 0;
            }
            else
            {
                contactSide = 2;
            }
        }
        else
        {
            if (relativePosition.x < 0)
            {
                contactSide = 1;
                collisionObject = collision.gameObject;
            }
            else
            {
                contactSide = 3;
            }
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        contactSide = 4;
    }
}

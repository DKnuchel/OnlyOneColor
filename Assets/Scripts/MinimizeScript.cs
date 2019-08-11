using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BlockBehaviourScript))]
[RequireComponent(typeof(Rigidbody))]
public class MinimizeScript : MonoBehaviour
{
    BlockBehaviourScript behaviourScript = null;
    Rigidbody rb;
    int contactSide = 4; // 0 = T, 1 = R, 2 = B, 3 = L, 4 = no collision
    float transformValue;
   
   
   
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        behaviourScript = GetComponent<BlockBehaviourScript>();
        transformValue = transform.localScale.x / 4;
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if (behaviourScript.IsMinimized()) {
            if(transform.localScale.x > 0.5) { 
            switch (contactSide)
            {
                case 2:
                    transform.localPosition -= new Vector3(0, transformValue, 0);
                    break;
            }
            }
            transform.localScale = Vector3.one * 0.5f;

        }
        else
        {
            transform.localScale = Vector3.one;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        var relativePosition = Quaternion.Inverse(transform.rotation) * collision.GetContact(0).normal;

        



        if(Mathf.Abs(relativePosition.x) < Mathf.Abs(relativePosition.y))
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

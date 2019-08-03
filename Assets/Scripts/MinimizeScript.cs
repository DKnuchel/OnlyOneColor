using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BehaviourScript))]
[RequireComponent(typeof(Rigidbody))]
public class MinimizeScript : MonoBehaviour
{
    BehaviourScript behaviourScript = null;
    Rigidbody rb;
    float size = 0.01f;
    float angle;
    int contactSide = 4; // 0 = T, 1 = R, 2 = B, 3 = L, 4 = no collision
    float transformValue;
   
   
   
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        behaviourScript = GetComponent<BehaviourScript>();
        transformValue = transform.localScale.x / 4;
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if (behaviourScript.isMinimized()) {
            if(transform.localScale.x > 0.5) { 
            switch (contactSide)
            {
                case 2:
                    transform.localPosition -= new Vector3(0, transformValue, 0);
                    break;
            }
            }
            while (transform.localScale.x > 0.5)
            {
                transform.localScale -= new Vector3(size, size, size);

            }


        }
        else
        {
            while (transform.localScale.x != 1)
            {
                transform.localScale += new Vector3(size, size, size);
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        var relativePosition = Quaternion.Inverse(transform.rotation) * collision.GetContact(0).normal;

        



        if(Mathf.Abs(relativePosition.x) < Mathf.Abs(relativePosition.y))
        {
            if (relativePosition.y < 0)
            {
                print("above");
                contactSide = 0;
            }
            else
            {
                print("below");
                contactSide = 2;
            }
        }
        else
        {
            if (relativePosition.x < 0)
            {
                print("right");
                contactSide = 1;
            }
            else
            {
                print("left");
                contactSide = 3;
            }
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        contactSide = 4;
    }
}

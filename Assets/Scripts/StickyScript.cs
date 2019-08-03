using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BlockBehaviourScript))]
public class StickyScript : MonoBehaviour
{
    BlockBehaviourScript behaviourScript;

    Rigidbody rb;
    float size = 0.01f;
    float angle;
    int contactSide = 4; // 0 = T, 1 = R, 2 = B, 3 = L, 4 = no collision
    float transformValue;
    GameObject collisionObject;


    Vector3 offset;

    Collider[] colliderBuffer = new Collider[32];

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        behaviourScript = GetComponent<BlockBehaviourScript>();
        transformValue = transform.localScale.x / 4;
    }


    private void FixedUpdate()
    {
        ConstrainPosition();
    }

    private void LateUpdate()
    {
        ConstrainPosition();
    }

    private void ConstrainPosition()
    {
        rb.useGravity = true;

        if (behaviourScript.IsSticky() && collisionObject != null)
        {
            bool isStillInReach = false;

            const float touchReach = 0.1f;

            int colliders = Physics.OverlapBoxNonAlloc(
                transform.position,
                transform.localScale + new Vector3(touchReach / transform.localScale.x, touchReach / transform.localScale.y, touchReach / transform.localScale.z),
                colliderBuffer, transform.rotation
                );
            for (int i = 0; i < colliders; i++)
            {
                Collider collider = colliderBuffer[i];
                if (collider.gameObject == collisionObject)
                {
                    isStillInReach = true;
                    break;
                }
            }

            if (!isStillInReach)
            {
                contactSide = 4;
                collisionObject = null;
            }

            if (contactSide == 1 || contactSide == 3)
            {
                rb.MoveRotation(collisionObject.transform.rotation);
                rb.MovePosition(collisionObject.transform.position + Matrix4x4.TRS(Vector3.zero, collisionObject.transform.rotation, collisionObject.transform.lossyScale).MultiplyVector(offset));

                Rigidbody collidedRb = collisionObject.GetComponent<Rigidbody>();
                if (collidedRb != null)
                {
                    rb.velocity = new Vector3(collidedRb.velocity.x, collidedRb.velocity.y, 0);
                }
                rb.useGravity = false;

                Debug.Log("Sticking");
            }
        }
        else
        {
            contactSide = 4;
            collisionObject = null;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        offset = transform.position - collision.transform.position;

        var relativePosition = Quaternion.Inverse(transform.rotation) * collision.GetContact(0).normal;

        collisionObject = collision.gameObject;

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
            }
            else
            {
                contactSide = 3;
            }
        }
    }
}

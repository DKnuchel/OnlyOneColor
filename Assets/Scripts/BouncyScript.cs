using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BlockBehaviourScript))]
[RequireComponent(typeof(Rigidbody))]
public class BouncyScript : MonoBehaviour
{
    BlockBehaviourScript behaviourScript = null;
    bool shouldJump = false;
    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        behaviourScript = GetComponent<BlockBehaviourScript>();
    }

    private bool IsGravityDown()
    {
        return !behaviourScript.IsGravitationalReversed();
    }

    private void FixedUpdate()
    {
        if (shouldJump && behaviourScript.IsBouncing())
        {
            Debug.Log("Bounce");
            rb.AddForce(0, 5 * (IsGravityDown() ? 1 : -1), 0, ForceMode.VelocityChange);
        }

        shouldJump = false;
    }

    private bool IsContactBelow(Collision collision, out bool below)
    {
        var relativePosition = Quaternion.Inverse(transform.rotation) * collision.GetContact(0).normal;

        if (Mathf.Abs(relativePosition.x) < Mathf.Abs(relativePosition.y))
        {
            below = relativePosition.y > 0;
            return true;
        }

        below = false;
        return false;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (IsContactBelow(collision, out bool below) && below == IsGravityDown())
        {
            shouldJump = true;
        }
    }

    void OnCollisionStay(Collision collision)
    {
        if (IsContactBelow(collision, out bool below) && below == IsGravityDown())
        {
            shouldJump = true;
        }
    }
}

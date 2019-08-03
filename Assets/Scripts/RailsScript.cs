using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(BlockBehaviourScript))]
public class RailsScript : MonoBehaviour
{
    [SerializeField] Vector3 offset;
    [SerializeField] [Range(0.01f, 30.0f)] float speed = 1.0f;
    [SerializeField] [Range(0.01f, 10.0f)] float speedBoostMultiplier = 2.0f;


    private BlockBehaviourScript behaviourScript;
    private Rigidbody rb;

    private Vector3 startPos;
    private Vector3 gizmoPos;

    private float progress;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        behaviourScript = GetComponent<BlockBehaviourScript>();

        startPos = transform.position;
        gizmoPos = transform.position;
    }


    private void FixedUpdate()
    {
        Vector3 pos = rb.position;
        Vector3 diff = startPos + transform.rotation * offset * CalculatePercent() - pos;
        rb.MovePosition(pos + diff);
        rb.velocity = diff;

        float timeSpeed;
        if (behaviourScript.IsSpeedBoosted())
        {
            Debug.Log("Rails speed boost");
            timeSpeed = speed * speedBoostMultiplier;
        }
        else
        {
            timeSpeed = speed;
        }
        progress += timeSpeed * Time.fixedDeltaTime;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.matrix = Matrix4x4.TRS(Application.isPlaying ? gizmoPos : transform.position, transform.rotation, transform.lossyScale);
        Gizmos.DrawLine(Vector3.zero, offset);
    }

    private float CalculatePercent()
    {
        float timer = progress % 1.0f;
        const float halfTime = 0.5f;
        if(timer < halfTime)
        {
            return timer / halfTime;
        }
        else
        {
            return 1 - (timer - halfTime) / halfTime;
        }
    }
}

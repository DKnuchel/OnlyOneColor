using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class RailsScript : MonoBehaviour
{
    [SerializeField] Vector3 offset;
    [SerializeField] [Range(0.01f, 30.0f)] float time = 1.0f;

    private Rigidbody rb;

    private Vector3 startPos;
    private Vector3 gizmoPos;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();

        startPos = transform.localPosition;
        gizmoPos = transform.position;
    }


    private void FixedUpdate()
    {
        Vector3 pos = rb.position;
        Vector3 diff = startPos + Matrix4x4.TRS(transform.position, transform.rotation, transform.localScale).MultiplyVector(offset) * CalculatePercent() - pos;
        rb.MovePosition(pos + diff);
        rb.velocity = diff;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.matrix = Matrix4x4.TRS(Application.isPlaying ? gizmoPos : transform.position, transform.rotation, transform.lossyScale);
        Gizmos.DrawLine(Vector3.zero, offset);
    }

    private float CalculatePercent()
    {
        float timer = Mathf.Max(0, Time.fixedUnscaledTime - 5) % time;
        float halfTime = time / 2.0f;
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

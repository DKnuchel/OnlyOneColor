using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
[RequireComponent(typeof(Rigidbody))]
public class BlockBehaviourScript : MonoBehaviour
{
    [SerializeField] [Range(0, 7)] int color = 0;
    [SerializeField] bool isolated = false;
    [SerializeField] bool fixHorizontal = false;
    [SerializeField] bool fixVertical = false;

    [SerializeField] Material whiteMaterial;
    [SerializeField] Material redMaterial;
    [SerializeField] Material blueMaterial;
    [SerializeField] Material yellowMaterial;
    [SerializeField] Material greenMaterial;
    [SerializeField] Material orangeMaterial;
    [SerializeField] Material purpleMaterial;
    [SerializeField] Material blackMaterial;

    [SerializeField] GameObject masterScriptObject;


    Rigidbody rb;
    MasterScript masterScript;

    Vector3 fixedPosition;

    MeshRenderer renderer;

    private void Start()
    {
        renderer = GetComponent<MeshRenderer>();
        rb = GetComponent<Rigidbody>();
        masterScript = masterScriptObject.GetComponent<MasterScript>();
        fixedPosition = rb.position;
    }

    private void Update()
    {
        if (renderer != null)
        {
            //oof
            switch (color)
            {
                default:
                case 0:
                    renderer.material = whiteMaterial;
                    break;
                case 1:
                    renderer.material = redMaterial;
                    break;
                case 2:
                    renderer.material = blueMaterial;
                    break;
                case 3:
                    renderer.material = yellowMaterial;
                    break;
                case 4:
                    renderer.material = greenMaterial;
                    break;
                case 5:
                    renderer.material = orangeMaterial;
                    break;
                case 6:
                    renderer.material = purpleMaterial;
                    break;
                case 7:
                    renderer.material = blackMaterial;
                    break;
            }
        }
    }

    private void FixedUpdate()
    {
        if (Application.isPlaying)
        {
            RestrictAxis();
        }
    }

    private void LateUpdate()
    {
        if (Application.isPlaying)
        {
            RestrictAxis();
        }
    }

    private void RestrictAxis()
    {
        if (fixVertical)
        {
            transform.position = rb.position = new Vector3(rb.position.x, fixedPosition.y, rb.position.z);
            rb.velocity = new Vector3(rb.velocity.x, 0, rb.velocity.z);
        }
        if (fixHorizontal)
        {
            transform.position = rb.position = new Vector3(fixedPosition.x, rb.position.y, rb.position.z);
            rb.velocity = new Vector3(0, rb.velocity.y, rb.velocity.z);
        }
    }

    public bool IsBouncing()
    {
        return (!isolated || color != 1) && (isolated || color == 0 || color == 1 || color == 6 || color == 5) && (masterScript.color == 1 || masterScript.color == 6 || masterScript.color == 5);
    }

    public bool IsMinimized()
    {
        return (!isolated || color != 2) && (isolated || color == 0 || color == 2 || color == 6 || color == 4) && (masterScript.color == 2 || masterScript.color == 6 || masterScript.color == 4);
    }

    public bool IsSticky()
    {
        return (!isolated || color != 3) && (isolated || color == 0 || color == 3 || color == 5 || color == 4) && (masterScript.color == 3 || masterScript.color == 5 || masterScript.color == 4);
    }

    public bool IsSpeedBoosted()
    {
        return (!isolated || color != 6) && (isolated || color == 0 || color == 6) && masterScript.color == 6;
    }

    public bool IsGhostActivated()
    {
        return (!isolated || color != 4) && (isolated || color == 0 || color == 4) && masterScript.color == 4;
    }

    public bool IsGravitationalReversed()
    {
        return (!isolated || color != 5) && (isolated || color == 0 || color == 5) && masterScript.color == 5;
    }
}

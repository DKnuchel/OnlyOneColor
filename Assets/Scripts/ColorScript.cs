using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class ColorScript : MonoBehaviour
{
    [SerializeField] GameObject masterScriptObject;

    MasterScript masterScript;

    [SerializeField] Material whiteMaterial;
    [SerializeField] Material redMaterial;
    [SerializeField] Material blueMaterial;
    [SerializeField] Material yellowMaterial;
    [SerializeField] Material greenMaterial;
    [SerializeField] Material orangeMaterial;
    [SerializeField] Material purpleMaterial;
    [SerializeField] Material blackMaterial;

    Vector4 defaultColor;
    Shader defaultShader;
    [SerializeField] Shader ghostShader;

    MeshRenderer meshRenderer;
    BlockBehaviourScript behaviourScript;

    private void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        masterScript = masterScriptObject.GetComponent<MasterScript>();

        behaviourScript = GetComponent<BlockBehaviourScript>();

        if (meshRenderer != null)
        {
            defaultShader = meshRenderer.sharedMaterial.shader;
            defaultColor = meshRenderer.sharedMaterial.GetColor("_BaseColor");
        }
    }

    private void Update()
    {
        if (meshRenderer != null)
        {
            int color;
            if (behaviourScript != null)
            {
                color = behaviourScript.Color;
            }
            else
            {
                color = masterScript.color;
            }

            //oof
            switch (color)
            {
                default:
                case 0:
                    meshRenderer.sharedMaterial = whiteMaterial;
                    break;
                case 1:
                    meshRenderer.sharedMaterial = redMaterial;
                    break;
                case 2:
                    meshRenderer.sharedMaterial = blueMaterial;
                    break;
                case 3:
                    meshRenderer.sharedMaterial = yellowMaterial;
                    break;
                case 4:
                    meshRenderer.sharedMaterial = greenMaterial;
                    break;
                case 5:
                    meshRenderer.sharedMaterial = orangeMaterial;
                    break;
                case 6:
                    meshRenderer.sharedMaterial = purpleMaterial;
                    break;
                case 7:
                    meshRenderer.sharedMaterial = blackMaterial;
                    break;
            }

            if (Application.isPlaying)
            {
                bool isGhostActivated;
                if (behaviourScript != null)
                {
                    isGhostActivated = behaviourScript.IsGhostActivated();
                }
                else
                {
                    isGhostActivated = masterScript.color == 4;
                }

                if (isGhostActivated && GetComponent<GhostScript>() != null)
                {
                    if (meshRenderer.material.shader != ghostShader)
                    {
                        meshRenderer.material.shader = ghostShader;
                    }
                    meshRenderer.material.SetFloat("Vector1_56E2CC01", 0.02f + (Mathf.Sin(Time.unscaledTime * 3.0f) + 1.0f) * 0.5f * 0.1f);
                    meshRenderer.material.SetColor("Color_E51BFDC2", defaultColor);
                }
                else
                {
                    if (meshRenderer.material.shader != defaultShader)
                    {
                        meshRenderer.material.shader = defaultShader;
                    }
                }
            }
        }
    }
}

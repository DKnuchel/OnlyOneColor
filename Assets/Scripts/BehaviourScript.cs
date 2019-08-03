using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BehaviourScript : MonoBehaviour
{
    [SerializeField] [Range(0, 7)] int color = 0;
    [SerializeField] bool isolated = false;

    [SerializeField] GameObject masterScriptObject;

    MasterScript masterScript;

    private void Start()
    {
        masterScript = masterScriptObject.GetComponent<MasterScript>();
    }

    public bool isBouncing()
    {
        return (color == 0  || color == 1 || color == 6 || color == 5) && (masterScript.color == 1 || masterScript.color == 6 || masterScript.color == 5);
    }

    public bool isMinimized()
    {
        return (color == 0 || color == 2 || color == 6 || color == 4) && (masterScript.color == 2 || masterScript.color == 6 || masterScript.color == 4);
    }

    public bool isSticky()
    {
        return (color == 0 || color == 3 || color == 5 || color == 4) && (masterScript.color == 3 || masterScript.color == 5 || masterScript.color == 4);
    }

    public bool isSpeedBoosted()
    {
        return (color == 0 || color == 6) && masterScript.color == 6;
    }

    public bool isGhostActivated()
    {
        return (color == 0 || color == 4) && masterScript.color == 4;
    }

    public bool isGravitationalReversed()
    {
        return (color == 0 || color == 5) && masterScript.color == 5;
    }
}

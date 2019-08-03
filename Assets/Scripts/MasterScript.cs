using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MasterScript : MonoBehaviour
{
    [SerializeField] bool bouncing = false;
    [SerializeField] bool minimized = false;
    [SerializeField] bool sticky = false;
    [SerializeField] bool speedBoost = false;
    [SerializeField] bool ghostsActivated = false;
    [SerializeField] bool gravitationReversed = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool isBouncing()
    {
        return bouncing;
    }

    public bool isMinimized()
    {
        return minimized;
    }

    public bool isSticky()
    {
        return sticky;
    }

    public bool isSpeedBoosted()
    {
        return speedBoost;
    }

    public bool isGhostActivated()
    {
        return ghostsActivated;
    }

    public bool isGravitationalReversed()
    {
        return gravitationReversed;
    }
}

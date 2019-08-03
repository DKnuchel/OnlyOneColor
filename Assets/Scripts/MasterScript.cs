using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MasterScript : MonoBehaviour
{
    int currentColor = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        currentColor = 0;
        bool key1, key2, key3;
        key1 = Input.GetKey(KeyCode.Alpha1);
        key2 = Input.GetKey(KeyCode.Alpha2);
        key3 = Input.GetKey(KeyCode.Alpha3);

        if (key1 && key2 && key3)
        {
            currentColor = 0;
        }
        else if (key2 && key3)
        {
            currentColor = 4;
        }
        else if (key1 && key3)
        {
            currentColor = 5;
        }
        else if (key1 && key2)
        {
            currentColor = 6;
        }
        else if (key1)
        {
            currentColor = 1;
        }
        else if (key2)
        {
            currentColor = 2;
        }
        else if (key3)
        {
            currentColor = 3;
        }
    }

    /*
     * 0 white  nothing
     * 1 red    bouncy
     * 2 blue   minimize
     * 3 yellow sticky
     * 4 green  ghost
     * 5 orange gravity
     * 6 purple faster player
    */
    int getCurrentColor()
    {
        return currentColor;
    }
   
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MasterScript : MonoBehaviour
{
    public int color = 0;

    // Update is called once per frame
    void Update()
    {
        color = 0;
        bool key1, key2, key3;
        key1 = Input.GetKey(KeyCode.Alpha1);
        key2 = Input.GetKey(KeyCode.Alpha2);
        key3 = Input.GetKey(KeyCode.Alpha3);

        if (key1 && key2 && key3)
        {
            color = 0;
        }
        else if (key2 && key3)
        {
            color = 4;
        }
        else if (key1 && key3)
        {
            color = 5;
        }
        else if (key1 && key2)
        {
            color = 6;
        }
        else if (key1)
        {
            color = 1;
        }
        else if (key2)
        {
            color = 2;
        }
        else if (key3)
        {
            color = 3;
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
        return color;
    }
   
}

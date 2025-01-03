using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

public class DisplayActivator : MonoBehaviour
{

    void Start()
    {
        ActivateDisplays();
    }
    /// <summary>
    /// https://docs.unity3d.com/2019.3/Documentation/Manual/MultiDisplay.html
    /// </summary>
    void ActivateDisplays()
    {
        Debug.Log ("displays connected: " + Display.displays.Length);
        // Display.displays[0] is the primary, default display and is always ON, so start at index 1.
        // Check if additional displays are available and activate each.
    
        for (int i = 1; i < Display.displays.Length; i++)
        {
            Display.displays[i].Activate();
        }
    }
}

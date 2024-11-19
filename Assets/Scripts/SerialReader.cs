using System;
using System.IO.Ports; 
using UnityEngine;
using UnityEngine.Events;

public class SerialReader : MonoBehaviour 
{ 
    SerialPort sp = new SerialPort("COM9", 9600); 
    public float speed = 5.0f; 
    
    public PanelManager[] panelManagers;

    void Start() 
    { 
        sp.Open();
        sp.ReadTimeout = 1; 
    } 
    void Update() 
    { 
        if (sp.IsOpen) 
        { 
            try 
            { 
                string data = sp.ReadLine();
                Debug.Log(data);
                PassDataToPanels(data);
            } 
            catch (System.Exception) { } 
        } 
    }

    void PassDataToPanels(string data)
    {
        foreach (PanelManager panel in panelManagers)
        {
            panel.CheckTaskCompletion(data);
            Debug.Log("Passed" + data + " to " + panel.gameObject.name);
        }
    }
}
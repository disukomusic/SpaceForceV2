using System;
using System.IO.Ports;
using UnityEngine;

public class SerialManager : MonoBehaviour
{
    public static SerialManager Instance; // Singleton instance
    private SerialPort sp;
    public string portName = "COM3";
    public int baudRate = 9600;

    public event Action<string> OnDataReceived;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Persist across scenes
            InitializeSerialPort();
        }
        else
        {
            Destroy(gameObject); // Ensure only one instance exists
        }
    }

    private void InitializeSerialPort()
    {
        sp = new SerialPort(portName, baudRate);
        try
        {
            sp.Open();
            sp.ReadTimeout = 1;
            Debug.Log("Serial Port Opened: " + portName);
        }
        catch (Exception e)
        {
            Debug.LogError("Failed to open serial port: " + e.Message);
        }
    }

    void Update()
    {
        if (sp != null && sp.IsOpen)
        {
            try
            {
                string data = sp.ReadLine();
                OnDataReceived?.Invoke(data); // Notify listeners
            }
            catch (TimeoutException) { }
        }
    }

    void OnDestroy()
    {
        if (sp != null && sp.IsOpen)
        {
            sp.Close();
        }
    }
}
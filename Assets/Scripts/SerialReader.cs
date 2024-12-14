using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SerialReader : MonoBehaviour
{
    public bool endScreen;
    public Panel[] panelManagers;

    void Start()
    {
        if (SerialManager.Instance != null)
        {
            SerialManager.Instance.OnDataReceived += HandleData;
        }
    }

    void OnDestroy()
    {
        if (SerialManager.Instance != null)
        {
            SerialManager.Instance.OnDataReceived -= HandleData;
        }
    }

    void HandleData(string data)
    {
        Debug.Log("Received: " + data);

        if (!endScreen)
        {
            PassDataToPanels(data);
        }
        else if (data == "greenButton")
        {
            Debug.Log("Green button pressed, waiting for transition.");
            StartCoroutine(WaitAndLoadScene());
        }
    }
    
    IEnumerator WaitAndLoadScene()
    {
        yield return new WaitForSeconds(1f); // Wait for 1 second before loading the scene
        SceneManager.LoadScene("Play Single Monitor");
    }

    void PassDataToPanels(string data)
    {
        foreach (Panel panel in panelManagers)
        {
            panel.CheckTaskCompletion(data);
            Debug.Log("Passed " + data + " to " + panel.gameObject.name);
        }
    }
}
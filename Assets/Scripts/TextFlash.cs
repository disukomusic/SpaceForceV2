using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextFlash : MonoBehaviour
{
    public TextMeshProUGUI textToFlash;         
    public float flashSpeed = 1f;   

    private bool isVisible = true;

    void Start()
    {
        StartCoroutine(Flash());
    }

    System.Collections.IEnumerator Flash()
    {
        while (true)
        {
            isVisible = !isVisible;
            textToFlash.enabled = isVisible;
            yield return new WaitForSeconds(1f / flashSpeed);
        }
    }
}



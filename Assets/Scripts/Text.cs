using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Text : MonoBehaviour
{
	public Text textToDisplay;  // Reference to your UI Text
	public float delayTime = 10f;  // Time in seconds before the text appears

	void Start()
	{
		// Start the coroutine to handle the delay
		StartCoroutine(ShowTextWithDelay());
	}

	IEnumerator ShowTextWithDelay()
	{
		// Wait for the specified delay time
		yield return new WaitForSeconds(delayTime);

		// Make the text visible after the delay
		textToDisplay.enabled = true;  // Assuming text is initially disabled
	}
}
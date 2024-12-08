using UnityEngine;
using UnityEngine.UI;  // Required to interact with UI components
using System.Collections;
public class DisplayMessage : MonoBehaviour
{
    public Text messageText;  // Reference to the Text component
    public string message = "Use WASD to move and your mouse to aim, click to shoot, Survive."; // Default message
    public float displayDuration = 15f; // Duration for the message to appear (in seconds)

    private void Start()
    {
        // Start the coroutine to display the message
        StartCoroutine(ShowMessage());
    }

    private IEnumerator ShowMessage()
    {
        // Display the message
        messageText.text = message;
        
        // Wait for the specified time
        yield return new WaitForSeconds(displayDuration);
        
        // Hide the message after the wait time
        messageText.text = "";
    }
}

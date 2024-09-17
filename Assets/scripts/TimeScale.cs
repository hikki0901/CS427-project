using UnityEngine;
using UnityEngine.UI; // For UI components like Text
using TMPro; // If using TextMeshPro

public class TimeScaleController : MonoBehaviour
{
    // Button to scale time
    [SerializeField] private Button scaleTimeButton;
    // Text to display current time scale
    [SerializeField] private Text timeScaleText;

    // Time scale values
    private float[] timeScales = { 0.5f, 1.0f, 2.0f };

    // Write function that present the current time scale and change it when the button is clicked
    private void Start()
    {
        // Set the initial time scale
        Time.timeScale = timeScales[1];
        // Set the initial text
        timeScaleText.text = "x" + Time.timeScale;

        // Add a listener to the button
        scaleTimeButton.onClick.AddListener(() =>
        {
            // Find the current time scale
            for (int i = 0; i < timeScales.Length; i++)
            {
                if (Time.timeScale == timeScales[i])
                {
                    // Set the next time scale
                    Time.timeScale = timeScales[(i + 1) % timeScales.Length];
                    // Update the text
                    timeScaleText.text = "x" + Time.timeScale;
                    break;
                }
            }
        });
    }

    // OnClick function for the button
    public void ChangeTimeScale()
    {
        // Console log
        Debug.Log("Button clicked");
        // Find the current time scale
        for (int i = 0; i < timeScales.Length; i++)
        {
            if (Time.timeScale == timeScales[i])
            {
                // Set the next time scale
                Time.timeScale = timeScales[(i + 1) % timeScales.Length];
                // Update the text
                timeScaleText.text = "x" + Time.timeScale;
                break;
            }
        }
    }

    
    

}

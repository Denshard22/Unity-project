using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStat : MonoBehaviour
{
    [SerializeField] private Image statBar; // Reference to the health bar image
    [SerializeField] private TextMeshProUGUI kills; // Reference to the kills text display

    private DataStorage playstats; // Reference to the DataStorage component for player statistics
    private float maxValue; // Maximum value for the health bar

    void Start()
    {
        playstats = GetComponent<DataStorage>(); // Get the DataStorage component attached to the same GameObject
        maxValue = playstats.health; // Set the maximum value for the health bar
    }

    void Update()
    {
        if (statBar != null)
        {
            // Update the scale of the health bar image based on the current player health
            statBar.transform.localScale = new Vector3(playstats.health / maxValue, 1, 1);
        }

        if (kills != null)
        {
            // Update the kills text display with the number of enemies shot by the player
            kills.text = playstats.enemiesShot.ToString();
        }
    }
}

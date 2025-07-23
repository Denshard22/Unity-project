using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Create a custom asset menu for creating NPC files
[CreateAssetMenu(fileName = "NPC file", menuName = "NPC Files Archive")]
public class NPC : ScriptableObject
{
    public string name; // The name of the NPC

    [TextArea(3, 15)]
    public string[] dialogue; // An array of strings representing the NPC's dialogue

    [TextArea(3, 15)]
    public string[] playerDialogue; // An array of strings representing the player's dialogue
}

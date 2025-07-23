using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DialogueManagerSolider : MonoBehaviour
{
    public NPC npc; // Reference to the NPC script

    bool isTalking = false; // Flag indicating if the player is currently in dialogue with the NPC

    float distance; // Distance between the player and the NPC
    float curResponceTracker; // Current response tracker

    public Animator animator; // Reference to the Animator component

    public GameObject player; // Reference to the player game object
    public GameObject dialogueUI; // Reference to the dialogue UI game object

    public TextMeshProUGUI npcName; // Reference to the NPC name text component
    public TextMeshProUGUI npcDialogueBox; // Reference to the NPC dialogue text component
    public TextMeshProUGUI playerResponse; // Reference to the player response text component

    public string audio; // Name of the audio event to play

    void Start()
    {
        dialogueUI.SetActive(false); // Deactivate the dialogue UI
        animator.enabled = false; // Disable the animator component
    }

    // Coroutine to load the "EndScene" after a delay
    private IEnumerator LoadEndSceneAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene("EndScene");
    }

    public void OnDialogue()
    {
        distance = Vector3.Distance(player.transform.position, this.transform.position); // Calculate the distance between the player and the NPC

        if (distance <= 5f)
        {
            if (isTalking == false)
            {
                StartConversation(); // Start the conversation with the NPC
                animator.enabled = true; // Enable the animator component
                AkSoundEngine.PostEvent($"{audio}", gameObject); // Play the specified audio event using AkSoundEngine
            }
            else if (isTalking == true)
            {
                EndDialogue(); // End the dialogue with the NPC

                if (audio == "Play_Solider")
                {
                    StartCoroutine(LoadEndSceneAfterDelay(2.5f)); // Load the "EndScene" after a delay if the audio event is "Play_Solider"
                }
            }

            if (curResponceTracker == 0 && npc.playerDialogue.Length >= 0)
            {
                playerResponse.text = npc.playerDialogue[0]; // Display the first player response

                if (Input.GetKeyDown(KeyCode.Return))
                {
                    npcDialogueBox.text = npc.dialogue[0]; // Display the corresponding NPC dialogue
                }
            }
            else if (curResponceTracker == 2 && npc.playerDialogue.Length >= 2)
            {
                playerResponse.text = npc.playerDialogue[2]; // Display the third player response

                if (Input.GetKeyDown(KeyCode.Return))
                {
                    npcDialogueBox.text = npc.dialogue[3]; // Display the corresponding NPC dialogue
                }
            }
        }
    }

    void StartConversation()
    {
        isTalking = true; // Set isTalking flag to true
        curResponceTracker = 0; // Reset the response tracker
        dialogueUI.SetActive(true); // Activate the dialogue UI
        npcName.text = npc.name; // Set the NPC name in the UI
        npcDialogueBox.text = npc.dialogue[0]; // Display the first NPC dialogue
    }

    void EndDialogue()
    {
        isTalking = false; // Set isTalking flag to false
        dialogueUI.SetActive(false); // Deactivate the dialogue UI
    }
}

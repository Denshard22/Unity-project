using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainScreenActions : MonoBehaviour
{

    public void StartGame()
    {
        AkSoundEngine.PostEvent("Play_Click", gameObject); // Trigger the "Play_Click" sound event
        DataStorage.instance.ResetGame(); // Reset the game data using the DataStorage singleton instance
        SceneManager.LoadSceneAsync("Level1"); // Load the "Level1" scene asynchronously
     //   AkSoundEngine.PostEvent("Stop_Pause", gameObject);
    }
    public void BackToMain()
    {
        SceneManager.LoadSceneAsync("StartScreen");
    }
    public void StopMusic()
    {

    }
    // Start is called before the first frame update
    void Start()
    {

    }



    void OnStartGame()
    {
        AkSoundEngine.PostEvent("Play_Click", gameObject); // Trigger the "Play_Click" sound event
        DataStorage.instance.ResetGame(); // Reset the game data using the DataStorage singleton instance
        SceneManager.LoadSceneAsync("Level1"); // Load the "Level1" scene asynchronously
    }

    // Update is called once per frame
    void Update()
    {

    }
}

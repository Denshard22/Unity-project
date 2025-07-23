using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainScreenActionsStart : MonoBehaviour
{

    public void StartGame()
    {
        AkSoundEngine.PostEvent("Play_Click", gameObject); // Trigger the "Play_Click" sound event
        SceneManager.LoadSceneAsync("CastleScene"); // Load the "Level1" scene asynchronously
    }

    public void StopMusic()
    {
    //    AkSoundEngine.PostEvent("Stop_BG", gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
    //    AkSoundEngine.PostEvent("Play_BG", gameObject);
    }



    void OnStartGame()
    {
        AkSoundEngine.PostEvent("Play_Click", gameObject); // Trigger the "Play_Click" sound event
        SceneManager.LoadSceneAsync("CastleScene"); // Load the "Level1" scene asynchronously
    }
    public void QuitGame()
    {
        Application.Quit();
    }




    // Update is called once per frame
    void Update()
    {

    }
}

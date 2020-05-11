using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelComplete : MonoBehaviour
{
    public void LoadNextLevel()
    {
        //This Loads the next Scene
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

        //This Loads the Menu scene
        SceneManager.LoadScene(0);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    bool gameEnded = false;

    public float restartDelay = 1f;

    public void EndGame()
    {
        if (gameEnded == false)
        {
            gameEnded = true;
            Debug.Log("GAME OVER");
            //Restarts game
            Invoke("Restart", restartDelay);
        }

    }
    void Restart()
    {
        //Loads Current scene 
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}

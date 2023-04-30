using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] float levelLoadDelay = 1f;
    private void OnCollisionEnter(Collision collision)
    {        
        switch (collision.gameObject.tag)
        {            
            case "Obstacle":
                Debug.Log("Collision Detected");
                startCrashSequence();
                //Invoke("startCrashSequence", 1);
                break;
            case "Ground":
                Debug.Log("Ground");
                //Invoke("startCrashSequence", 1);
                startCrashSequence();
                break;
            case "Landing Pad":
                Debug.Log("Landing success");
                Invoke("loadNextLevel", levelLoadDelay);
                break;
            case "Launch Pad":
                break;
            default:
                Debug.Log("Other Collision");
                break;
        }
    }

    void startCrashSequence()
    {
        Debug.Log(this.GetType().ToString());
        GetComponent<Movement>().enabled = false;        
        Invoke("reloadLevel", levelLoadDelay);
    }
    
    void reloadLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }

    void startSuccessSequence()
    {
        GetComponent<Movement>().enabled = false;
        Invoke("LoadNextLevel", levelLoadDelay);
    }

    private static void LoadNextLevel()
    {
        int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
        if (nextSceneIndex == SceneManager.sceneCountInBuildSettings)
        {
            Debug.Log("You win the game!");
            // Restart the game 
            nextSceneIndex = 0;
        }
        SceneManager.LoadScene(nextSceneIndex);
    }
}

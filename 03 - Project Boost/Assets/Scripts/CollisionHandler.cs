using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {        
        switch (collision.gameObject.tag)
        {            
            case "Obstacle":
                Debug.Log("Collision Detected");
                onDeath();
                break;
            case "Ground":
                Debug.Log("Ground");
                onDeath();
                break;
            case "Landing Pad":
                Debug.Log("Landing success");
                loadNextLevel();
                break;
            case "Launch Pad":
                break;
            default:
                Debug.Log("Other Collision");
                break;
        }
    }

    void onDeath()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }

    void loadNextLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
        SceneManager.LoadScene(currentSceneIndex);
    }
}

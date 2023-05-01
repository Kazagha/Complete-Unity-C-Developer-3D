using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    // Params
    [SerializeField] float levelLoadDelay = 1f;
    [SerializeField] AudioClip successClip;
    [SerializeField] AudioClip deathClip;

    [SerializeField] ParticleSystem successParticles;
    [SerializeField] ParticleSystem deathParticles;
    // Cache 
    AudioSource audioSource;

    //State
    bool isTransitioning = false;   

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    private void OnCollisionEnter(Collision collision)
    {     
        if(isTransitioning) { return; }
        
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
                startSuccessSequence();
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
        GetComponent<Movement>().enabled = false;
        PlayDeathAudio();
        deathParticles.Play();
        isTransitioning = true;
        Invoke("reloadLevel", levelLoadDelay);
    }
    
    void reloadLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }

    public void startSuccessSequence()
    {
        GetComponent<Movement>().enabled = false;
        PlaySuccessAudio();
        successParticles.Play();
        isTransitioning = true;
        Invoke("LoadNextLevel", levelLoadDelay);
    }

    void LoadNextLevel()
    {
        Debug.Log("Load Next Level");        

        int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
        if (nextSceneIndex == SceneManager.sceneCountInBuildSettings)
        {
            Debug.Log("You win the game!");
            // Restart the game 
            nextSceneIndex = 0;
        }
        SceneManager.LoadScene(nextSceneIndex);
    }

    void PlaySuccessAudio()
    {
        audioSource.Stop();
        if (!audioSource.isPlaying)
        {
            audioSource.PlayOneShot(successClip);
        }
    }

    void PlayDeathAudio()
    {
        audioSource.Stop();
        if (!audioSource.isPlaying)
        {
            audioSource.PlayOneShot(deathClip);
        }
    }
}

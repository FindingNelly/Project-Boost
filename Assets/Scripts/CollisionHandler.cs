using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{

    
    const string Finish = "Finish";
    const string Friendly = "Friendly";

    private void Update()
    {
        
    }


    private void OnCollisionEnter(Collision collision)
    {
        switch (collision.gameObject.tag)
        {
            
            case Friendly:
                Debug.Log("friend");
                break;
            case Finish:
                LoadNextLevel();
                break;
            default:
                ReloadLevel();
                break;

        }
        void ReloadLevel()
        {
            int activeScene = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(activeScene);
        }
        void LoadNextLevel()
        {
            int activeScene = SceneManager.GetActiveScene().buildIndex;
            int nextScene = activeScene + 1;
            if (nextScene == SceneManager.sceneCountInBuildSettings)
            {
                nextScene = 0;
            }
            SceneManager.LoadScene(nextScene);   
        }
     


    }

}

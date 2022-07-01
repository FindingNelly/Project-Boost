using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{

    
    const string Finish = "Finish";
    const string Friendly = "Friendly";


    private void OnCollisionEnter(Collision collision)
    {
        switch (collision.gameObject.tag)
        {
            case Finish:
                Debug.Log("fin");
                break;
            case Friendly:
                Debug.Log("friend");
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
        
     


    }

}

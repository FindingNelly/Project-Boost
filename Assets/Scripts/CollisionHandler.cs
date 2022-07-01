using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{

    Movment myMover;
    const string Finish = "Finish";
    const string Friendly = "Friendly";
    [SerializeField]float timeLoadNext = 2f;
    private void Awake()
    {
        myMover = GetComponent<Movment>();
    }



    private void OnCollisionEnter(Collision collision)
    {
        switch (collision.gameObject.tag)
        {

            case Friendly:
                Debug.Log("friend");
                break;
            case Finish:
                LoadLevel("NextLevel");
                break;
            default:
                LoadLevel("ReloadLevel");
                break;

        }
    }
    void LoadLevel(string level)
    {
       myMover.enabled = false;
        Invoke(level, timeLoadNext);

    }

    void ReloadLevel()
    {
        int activeScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(activeScene);
    }
    void NextLevel()
    {
        int activeScene = SceneManager.GetActiveScene().buildIndex;
        int nextScene = activeScene+1;
        if (nextScene == SceneManager.sceneCountInBuildSettings)
        {
            nextScene = 0;
        }
        SceneManager.LoadScene(nextScene);
    }





}

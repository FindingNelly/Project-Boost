using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{

    Movment myMover;
    AudioSource myAudioSource;
    const string Finish = "Finish";
    const string Friendly = "Friendly";
    
    
    [SerializeField]float timeLoadNext = 2f;
    [SerializeField] AudioClip finishSound;
    [SerializeField] AudioClip crashSound;
      public bool transiting = false;
  

    private void Awake()
    {
        myMover = GetComponent<Movment>();
        myAudioSource = GetComponent<AudioSource>();
        Debug.Log(transiting);
        
    }

    private void Update()
    {
      
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (transiting) { return;}
        switch (collision.gameObject.tag)
        {

            case Friendly:
                Debug.Log("friendy");
                break;
            case Finish:
                LoadLevel("NextLevel",finishSound);
                break;
            default:
                            
                LoadLevel("ReloadLevel", crashSound);
                break;

        }
    }

    
    void LoadLevel(string level, AudioClip soundeffect)
    {
        transiting=true;
        myAudioSource.Stop();
        myAudioSource.PlayOneShot(soundeffect);
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

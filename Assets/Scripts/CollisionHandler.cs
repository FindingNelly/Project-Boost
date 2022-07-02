using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{

    Movment myMover;
    AudioSource myAudioSource;
    const string Finish = "Finish";
    const string Friendly = "Friendly";


    [SerializeField] float timeLoadNext = 2f;
    [SerializeField] AudioClip finishSound;
    [SerializeField] AudioClip crashSound;
    [SerializeField] ParticleSystem finishParticals;
    [SerializeField] ParticleSystem crashParticals;


    public bool transiting = false;


    private void Awake()
    {
        myMover = GetComponent<Movment>();
        myAudioSource = GetComponent<AudioSource>();


    }


    private void OnCollisionEnter(Collision collision)
    {
        if (transiting) { return; }
        switch (collision.gameObject.tag)
        {

            case Friendly:
                Debug.Log("friendy");
                break;

            case Finish:
                CollisionTrigger("NextLevelLoad", finishSound, finishParticals);
                break;

            default:
                CollisionTrigger("ReloadLevel", crashSound, crashParticals);
                break;

        }
    }


    void CollisionTrigger(string level, AudioClip soundeffect, ParticleSystem particals)
    {
        particals.Play();
        transiting = true;
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
    void NextLevelLoad()
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

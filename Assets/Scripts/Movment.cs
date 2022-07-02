using UnityEngine;

public class Movment : MonoBehaviour
{

    
    Rigidbody myRigibody;
    AudioSource myAudioSource;

    [SerializeField] float mainTrust = 1f;
    [SerializeField] float rotationTrust = 1f;
    [SerializeField] AudioClip trustSound;
    

    // Start is called before the first frame update
    void Start()
    {
        myRigibody = GetComponent<Rigidbody>();
        myAudioSource = GetComponent<AudioSource>();
        
    }

    // Update is called once per frame
    void Update()
    {

        MovmentInput();

    }

    void MovmentInput()
    {
        //trust
        if (Input.GetKey(KeyCode.W))
        {
            
            
            ApplyTtrust(mainTrust);
            if (!myAudioSource.isPlaying)
            {
                myAudioSource.PlayOneShot(trustSound);
            }

        }

        else
        {
            myAudioSource.Stop();
        }
        //left
        if (Input.GetKey(KeyCode.A))
        {
            ApplyRotation(rotationTrust);
        }

        //right
        else if (Input.GetKey(KeyCode.D))
            ApplyRotation(-rotationTrust);
    }

    private void ApplyTtrust(float trust)
    {

        myRigibody.AddRelativeForce(Vector3.up * trust * Time.deltaTime);

    }

    private void ApplyRotation(float rotation)
    {
        myRigibody.freezeRotation = true;
        transform.Rotate(Vector3.forward * rotation * Time.deltaTime);
        myRigibody.freezeRotation = false;
    }
}

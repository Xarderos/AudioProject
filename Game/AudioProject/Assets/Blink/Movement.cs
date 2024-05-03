using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float rotationSpeed = 100f;
    public float moveSpeed = 5f;
    private Rigidbody rb;
    public Animator animator;
    public AudioSource audioSource;
    public AudioClip[] audioClips;
    bool isWood;
    bool isGround = true;
    bool soundPlayed = false;
    bool soundPlaying = false;
    void Start()
    {
        isGround = true;
        rb = GetComponent<Rigidbody>();
        // Assuming the camera is a child of the player object
    }

    void Update()
    {
        // Rotation
        float rotationInput = Input.GetAxis("Horizontal");
        transform.Rotate(Vector3.up, rotationInput * rotationSpeed * Time.deltaTime);
        
        // Movement
        float verticalInput = Input.GetAxis("Vertical");
        if(verticalInput != 0 && audioSource.isPlaying == false)
        {
            audioSource.Play();
            if (isWood)
            {
                audioSource.clip = audioClips[1];
                isWood = false;
            }
            else {
                audioSource.clip = audioClips[0];
            }
        }
        if (verticalInput > 0)
        {
            animator.SetBool("IsIdle", false);
            animator.SetBool("IsRunning", true);
        }
        else if (verticalInput < 0)
        {
            animator.SetBool("IsIdle", false);
            animator.SetBool("IsBackward", true);
        }
        else
        {
            animator.SetBool("IsIdle", true);
            animator.SetBool("IsRunning", false);
            animator.SetBool("IsBackward", false);

        }
        Vector3 movement = rb.transform.forward * verticalInput * moveSpeed * Time.deltaTime;
        
        transform.position += movement;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Wood")
        {
            isWood = true;
            isGround = false;

        }
        if (collision.collider.tag == "Ground")
        {
            isGround = true;
        }

    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Bush")
        {
            audioSource.clip = audioClips[2];
            audioSource.Play();

        }
        if (other.tag == "Boss" && !soundPlayed) 
        {
            audioSource.clip = audioClips[3];
            audioSource.Play();
            soundPlayed = true; 
        }
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private Rigidbody playerRb;
    private Animator playerAnim;
    public ParticleSystem explosionParticles;
    public ParticleSystem dirtParticle;
    public float jumpForce = 10;
    public float garvityModifier;
    private bool isOnGround = true;
    public bool gameOver = false;

    public AudioSource crashSound;
    public AudioSource music;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        playerAnim = GetComponent<Animator>();

        Physics.gravity *= garvityModifier;

    }

    // Update is called once per frame
    void Update()
    {
       
        
    }

    void OnJump()
    {
        if (isOnGround && !gameOver)
        {
            Debug.Log("jump");
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;

            playerAnim.SetTrigger("Jump_trig");
            dirtParticle.Stop();
        }
        
    }

    void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
            dirtParticle.Play();
        }
        
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            crashSound.Play();

            gameOver = true;
            Debug.Log("Game Over !");

           playerAnim.SetBool("Death_b", true);
           playerAnim.SetInteger("DeathType_int", 1);

            explosionParticles.Play();
            dirtParticle.Stop();
        }
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private Rigidbody playerRb;

    public float jumpForce = 10;
    public float garvityModifier;
    private bool isOnGround = true;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        Physics.gravity *= garvityModifier;


    }

    // Update is called once per frame
    void Update()
    {
       
        
    }

    void OnJump()
    {
        if (isOnGround)
        {
            Debug.Log("jump");
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;
        }
        
    }

    void OnCollisionEnter(Collision collision)
    {
        isOnGround = true;
    }

}

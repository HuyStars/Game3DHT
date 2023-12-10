using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRunning : MonoBehaviour
{
    private Vector3 moveVector;
    private bool isDead = false;
    private float gravity = 9.8f;
    private CharacterController player;
    [SerializeField] protected float speed = 5f;
    private float verticalVelocity = 0f;
    private float animTime = 2f;
    // public Transform mapGenerator; 
    // public GameObject mapPrefab; // Prefab của map
    private bool isLeft, isRight, isTop;
    private void Awake()
    {
        player = GetComponent<CharacterController>();

    }
    public void PoiterDownLeft()
    {
        isLeft = true;
    }
    
    public void PoiterUpLeft()
    {
        isLeft = false;
    }
    
    public void PoiterDownRight()
    {
        isRight = true;
    }
    
    public void PoiterUpRight()
    {
        isRight = false;
    }

    public void AnNhay()
    {
        isTop = true;
    }

    public void ThaNhay()
    {
        isTop = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time < animTime)
        {
            player.Move(Vector3.forward * speed * Time.deltaTime); // Move along the Z-axis
        }
        else
        {
            if (!isDead)
            {
                if (player.isGrounded)
                {
                    verticalVelocity = -0.5f;
                }
                else
                {
                    verticalVelocity -= gravity * Time.deltaTime;
                }

                // Use Input.GetAxis("Horizontal") for horizontal movement
               // moveVector.x = Input.GetAxis("Horizontal") * speed;

                // Use Input.GetKey(KeyCode.Space) to check if the Space key is pressed
                if (Input.GetKey(KeyCode.Space))
                {
                    moveVector.y = -verticalVelocity; // Move downward
                }
                else
                {
                    moveVector.y = verticalVelocity; // Move upward
                }
                Nhay();

                // Continue moving forward
                moveVector.z = speed;

                player.Move(moveVector * Time.deltaTime); // Move the character controller
            }
            else
            {
                // Handle code for when the player is dead
            }
        }
        MovePlayer();
        
    }
    
    private void MovePlayer()
    {
        if (isLeft)
        {
            moveVector.x = -speed;
        }
        else if (isRight)
        {
            moveVector.x = speed;
        }
        else
        {
            moveVector.x = 0;
        }
    }

    private void Nhay()
    {
        if (isTop)
        {
            moveVector.y = -verticalVelocity;
        }
        else
        {
            moveVector.y = verticalVelocity;
        }
    }
    
    
    public void setSpeed (float v)
    {
        speed += v;
    }

    internal void Dead ()
    {
        isDead = true;
    }
}

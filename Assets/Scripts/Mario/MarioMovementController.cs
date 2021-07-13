using System;
using UnityEngine;

public class MarioMovementController : MonoBehaviour
{
    private const float MARIO_ZERO_SPEED = 0.0f;
    private const float MARIO_PARTIAL_SPEED = 5.0f;
    private const float MARIO_FULL_SPEED = 10.0f;
    
    //Timer constants
    private const float PARTIAL_TO_FULL_SPEED_TIME = 0.2f;
    private const float FULL_TO_ZERO_SPEED_TIME = 0.05f;
    
    //Timer variables
    private float partialToFullSpeedTimer;
    private float fullToZeroSpeedTimer;

    private float marioSpeed;
    private Transform marioTransform;
    private Vector2 hMoveDir;

    private void Awake()
    {
        marioSpeed = 0.0f;
        marioTransform = GetComponent<Transform>();

        hMoveDir = Vector2.zero;

        partialToFullSpeedTimer = 0.0f;
        fullToZeroSpeedTimer = 0.0f;
    }

    private void Update()
    {
        if (Input.GetButton("Right"))
        {
            marioSpeed = MARIO_PARTIAL_SPEED;
            hMoveDir = Vector2.right;

            StartPartialToFullSpeedTimer();

            fullToZeroSpeedTimer = 0.0f;
        }
        else if (Input.GetButton("Left"))
        {
            marioSpeed = MARIO_PARTIAL_SPEED;
            hMoveDir = Vector2.left;

            StartPartialToFullSpeedTimer();
            
            fullToZeroSpeedTimer = 0.0f;
        }
        else
        {
            partialToFullSpeedTimer = 0.0f; //reset timer
            //marioSpeed = MARIO_ZERO_SPEED;
            StartFullToZeroSpeedTimer();
        }

        Vector2 move = marioSpeed * Time.deltaTime * hMoveDir;
        
        Debug.Log(marioSpeed);
        
        Move(move, false);
    }

    private void Move(Vector2 move, bool yMovement)
    {
        marioTransform.Translate(move);
    }

    private void StartPartialToFullSpeedTimer()
    {
        if (partialToFullSpeedTimer <= PARTIAL_TO_FULL_SPEED_TIME)
        {
            partialToFullSpeedTimer += Time.deltaTime;
        }
        else
        {
            //partialToFullSpeedTimer = 0.0f; //reset timer
            marioSpeed = MARIO_FULL_SPEED;
        }
    }
    
    private void StartFullToZeroSpeedTimer()
    {
        if (fullToZeroSpeedTimer <= FULL_TO_ZERO_SPEED_TIME)
        {
            //Debug.Log("here");
            fullToZeroSpeedTimer += Time.deltaTime;
        }
        else
        {
            //partialToFullSpeedTimer = 0.0f; //reset timer
            marioSpeed = MARIO_ZERO_SPEED;
        }
    }
}

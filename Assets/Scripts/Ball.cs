using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    // настройка параметров
    [SerializeField] Paddle paddle1;

    [SerializeField] float xPush = 2f;
    [SerializeField] float yPush = 15f;

    [SerializeField] float randomFactor = 0.2f;

    [SerializeField] AudioClip[] BallSounds;

    // утверждаем переменные 
    Vector2 paddleToBallVector;
    bool HasStarted = false;


    // cached component references
    AudioSource myAudioSource;
    Rigidbody2D myRigidBody2D;

    void Start()
    {
        paddleToBallVector = transform.position - paddle1.transform.position;
        myAudioSource = GetComponent<AudioSource>();
        myRigidBody2D = GetComponent<Rigidbody2D>();
    }

    
    void Update()
    {
    if (!HasStarted)
        { 
            LockBallToPaddle();
            LaunchOnMouseClick();
        }         
    }

    private void LaunchOnMouseClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            HasStarted = true;
            myRigidBody2D.velocity = new Vector2(xPush, yPush);
            
        }
    } 

    private void LockBallToPaddle()
    {       
        Vector2 paddlePos = new Vector2(paddle1.transform.position.x, paddle1.transform.position.y);
        transform.position = paddlePos + paddleToBallVector;
        
    }

    private void OnCollisionEnter2D()
    {

        Vector2 velocityTweak = new Vector2 (UnityEngine.Random.Range(0f, randomFactor), UnityEngine.Random.Range(0f, randomFactor));
        
       
        if (HasStarted)
        {
            AudioClip clip = BallSounds[UnityEngine.Random.Range(0, BallSounds.Length)];
            myAudioSource.PlayOneShot(clip);
            myRigidBody2D.velocity += velocityTweak;
        }
        
    }   

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class Enemy : MonoBehaviour
{
    private float moveSpeed = 8f;
    public float alertDistance = 20f; 
    private Transform player;
    private NavMeshAgent chaseAgent;
    private Vector3 moveDirection;
    private float roamTimer;
    private bool isChasing = false;
    private Vector3 startPosition;


    void Awake()
    {
        //find player tag and stores its position
        player = GameObject.FindWithTag("Player").transform;

        chaseAgent = GetComponent<NavMeshAgent>();

        startPosition = transform.position;

        //set speed of agent and stop agent from turning in y axis
        chaseAgent.speed = moveSpeed;
        chaseAgent.updateRotation = false;
        chaseAgent.updateUpAxis = false;

        RandomDirection();
    }

    void FixedUpdate()
    {
        //store player vector3 in relation to enemy
        Vector3 toPlayer = player.position - transform.position;
        isChasing = false;

        //if player distance is in the alert distance start chaseing player
        if (toPlayer.magnitude <= alertDistance)
        {
            isChasing = true;
            chaseAgent.isStopped = false;
            chaseAgent.SetDestination(player.position);
        }

        //when not chasing roam around
        if (!isChasing)
        {  
            chaseAgent.isStopped = true;

            //count down direction change timer each frame
            roamTimer -= Time.fixedDeltaTime;

            //when timer reaches 0 change direction
            if (roamTimer <= 0f)
            {
                RandomDirection();
            }

            transform.position += moveDirection * moveSpeed * Time.fixedDeltaTime;
        }
    }

    void RandomDirection() 
    {
        
        Vector3[] directions = { Vector3.forward, Vector3.back, Vector3.left, Vector3.right };

        // Pick random direction from array and set as move direction
        moveDirection = directions[Random.Range(0, directions.Length)];

        //reset timer between 1 and 3 seconds
        roamTimer = Random.Range(1f, 3f);
    }


    void OnCollisionEnter(Collision collision) //collision detections
    {
        //fail safe if enemy hits wall while not chasing, to change direction (stop enemy getting stuck for whole wait time in wall)
        if (collision.gameObject.CompareTag("Wall") && !isChasing)
        {
            RandomDirection();
        }

        if (collision.gameObject.CompareTag("Player"))
        {
            //start takedamage function from health script
            collision.gameObject.GetComponent<Health>().TakeDamage();

            Debug.Log("HIT"); 
        }
    }

    //function to reset the enemies positions when they player takes damage + stops chasing
    public void ResetPosition()
    {
        transform.position = startPosition;
        chaseAgent.ResetPath();
        isChasing = false;

    }
    


}

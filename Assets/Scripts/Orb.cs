using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orb : MonoBehaviour
{
    private int orbScore = 10; //assign point to orb

    //when player collides with orb, send points to score manager then remove orb from scene
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            ScoreManager.Instance.AddPoints(orbScore); 
            Destroy(gameObject);
        }
    }

}

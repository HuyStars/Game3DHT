using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float life = 3;
 
    void Awake()
    {
        Destroy(gameObject, life);
    }
 
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Coin") 
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
        Destroy(gameObject, 5f);
    }
}

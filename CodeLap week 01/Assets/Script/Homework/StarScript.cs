﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class StarScript : MonoBehaviour
{
    public GameObject StarManager;
    public GameObject Controller;
    
    // Start is called before the first frame update
    void Start()
    {
        StarManager = GameObject.FindGameObjectWithTag("StarManager");
        Controller = GameObject.FindGameObjectWithTag("PlayerController");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player1") && !other.CompareTag("Player2"))
        {
            StarManager.GetComponent<StarManager>().spawn(Random.Range(1,3));
            Controller.GetComponent<PlayerController>().Player[0].score += 1;
        }
        
        else if (other.CompareTag("Player2"))
        {
            StarManager.GetComponent<StarManager>().spawn(Random.Range(1,3));
            Controller.GetComponent<PlayerController>().Player[1].score += 1;
        }

        if (other.CompareTag("Player1") || other.CompareTag("Player2"))
        {
            Destroy(gameObject);
            print("yeay");
            StarManager.GetComponent<StarManager>().gameEnd();
        }
    }
}

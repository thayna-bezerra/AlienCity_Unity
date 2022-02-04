using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Armadilhas : MonoBehaviour
{
    //publico:  tempo de dano e quantidade de dano

    public PlayerController pc;

    public float maxTimeToDamage = 1;
    private float currentTimeToDamage = 0;
    private bool isColliding = false;

    void Start()
    {
        pc = FindObjectOfType<PlayerController>();
    }

    void Update()
    {
        if (isColliding)
        {
            if (currentTimeToDamage >= maxTimeToDamage)
            {
                DamagePlayer();
                currentTimeToDamage = 0;
            }
            else
                currentTimeToDamage += Time.deltaTime;
        }

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            isColliding = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            isColliding = false;
        }
    }

    void DamagePlayer()
    {
        pc.lifePlayer--;
    }


    /* public Slider vidaPlayer;
     public float maxTimeToDamage = 1;
     private float currentTimeToDamage = 0;
     private bool isColliding = false;

     void Update()
     {
         if (isColliding)
         {
             if (currentTimeToDamage >= maxTimeToDamage)
             {
                 DamagePlayer();
                 currentTimeToDamage = 0;
             }
             else
                 currentTimeToDamage += Time.deltaTime;
         }
     }

     private void OnTriggerEnter(Collider other)
     {
         if (other.tag == "Player")
         {
             isColliding = true;
         }


     }

     void OnTriggerExit(Collider other)
     {
         if (other.tag == "Player")
         {
             isColliding = false;
         }
     }

     void DamagePlayer()
     {
         vidaPlayer.value--;
     }
 */
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Armadilhas : MonoBehaviour
{
    //publico:  tempo de dano e quantidade de dano

    public PlayerController pc;
    private bool isColliding = false;
    
    private float danoTempoAtual = 0;

    [Header("Tempo entres os DANOS")]
    [Space]
    public float danoTempoMax = 1;

    [Header("Quantidade de DANO")]
    [Space]
    public int dano = 1;

    void Start()
    {
        pc = FindObjectOfType<PlayerController>();
    }

    void Update()
    {
        if (isColliding)
        {
            if (danoTempoAtual >= danoTempoMax)
            {
                DamagePlayer();
                danoTempoAtual = 0;
            }
            else  danoTempoAtual += Time.deltaTime;
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
        pc.energiaAtual-=dano;
    }
}
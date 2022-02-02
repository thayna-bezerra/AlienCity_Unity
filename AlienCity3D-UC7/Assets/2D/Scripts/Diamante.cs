using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Diamante : MonoBehaviour
{
    public GameController gc;

    private void Start() { gc = FindObjectOfType<GameController>(); }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")//COLISÃO COM O PLAYER
        {
            gc.Pontos += 10;
            Destroy(this.gameObject);
        }
    }
}
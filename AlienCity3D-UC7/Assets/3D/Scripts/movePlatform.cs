using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movePlatform : MonoBehaviour
{
    public float speed= 3f;
    public bool move = true;

    public GameObject pontoMeio;
    public GameObject pontoLateralA;
    public GameObject pontoLateralB;

    public Vector3 nextPos; //colocar istrigger

    private void Start()
    {
        nextPos = pontoLateralA.transform.position;
    }

    void Update()
    {
        /*if(transform.position.x < pontoMeio.transform.position.x)
        {
            move = true;
        }
        if (transform.position.x > pontoLateralA.transform.position.x)
        {
            move = false;
        }

        if (move)
        {
            transform.position = new Vector2(transform.position.x + speed * Time.deltaTime, transform.position.y);
        }

        else transform.position = new Vector2(transform.position.x - speed * Time.deltaTime, transform.position.y);
        */

        movingPlatform();
    }

    public void movingPlatform()
    {
        //um dos lados das plataformas

        if(transform.position == pontoLateralA.transform.position)
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
            //nextPos = pontoMeio.transform.position;
        }

        if (transform.position == pontoMeio.transform.position)
        {
            transform.Translate(-Vector3.left * speed * Time.deltaTime);
            //nextPos = pontoLateralA.transform.position;
        }

        transform.position = Vector3.MoveTowards(transform.position, nextPos, speed*Time.deltaTime);

    }
}

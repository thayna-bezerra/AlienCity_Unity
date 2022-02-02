using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMove : MonoBehaviour
{
    public Text textoRodape;

    public bool isActive;

    public Animator AnimacoesPlayer;

    private void Start()
    {
        AnimacoesPlayer = GetComponent<Animator>();
    }

    void Update()
    {
        if(Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            isActive = true;

            if(touch.phase == TouchPhase.Moved)
            {
                transform.position += (Vector3)touch.deltaPosition/100;
                textoRodape.gameObject.SetActive(true);
            }
        }

        else { textoRodape.gameObject.SetActive(false); isActive = false; }

        if (isActive == true) { AnimacoesPlayer.Play("jump"); }
        else if (isActive == false) { AnimacoesPlayer.Play("idle"); }
    }
}
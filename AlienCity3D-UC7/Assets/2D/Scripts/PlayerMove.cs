using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMove : MonoBehaviour
{
    public Text textoRodape; 
    
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

            if(touch.phase == TouchPhase.Moved)
            {
                transform.position += (Vector3)touch.deltaPosition;
                textoRodape.gameObject.SetActive(true);
                AnimacoesPlayer.Play("Jump"); //usar bool isActive para verificar se o player está ou não sendo tocando, para assim tocar a anim
            }

            else { textoRodape.gameObject.SetActive(false); }
        }
    }
}

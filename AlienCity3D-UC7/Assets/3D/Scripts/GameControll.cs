using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameControll : MonoBehaviour
{
    [Header("Panels")] //Para ATIVAR e DESATIVAR 
    public GameObject panelWins;
    public GameObject panelOver;

    public int isVictoryPlayer;

    void Start()
    {
        isVictoryPlayer = PlayerPrefs.GetInt("Victory");

        panelWins.SetActive(false);
        panelOver.SetActive(false);
    }

    void Update()
    {
        if (isVictoryPlayer == 0)
        {
            panelWins.SetActive(false);
            panelOver.SetActive(true);
        }

        else if (isVictoryPlayer == 1)
        {
            panelWins.SetActive(true);
            panelOver.SetActive(false);
        }
    }
    public void primeiroGame()
    {
        SceneManager.LoadScene("Teste01_ToqueBasico");
    }

    public void segundoGame()
    {
        SceneManager.LoadScene("Teste02_MovBasica");
    }

    public void voltarMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void Sair() 
    { 
        Application.Quit();
        PlayerPrefs.DeleteAll();
    }


}

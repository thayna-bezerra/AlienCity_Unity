using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public int Pontos = 0;
    public Text pontos;

    public GameObject Diamante;
    public List<GameObject> spawnPoints; 

    public void Start()
    {
        spawnPoints = new List<GameObject>();
        spawnPoints.AddRange(GameObject.FindGameObjectsWithTag("SpawnPosition"));

        for (int i = 0; i < 3; i++) { InstantiateGem(); }
    }

    public void Update()
    {
        pontos.text = Pontos.ToString();
        while (GameObject.FindGameObjectsWithTag("Diamante").Length < 3) { InstantiateGem(); }
    }

    public void InstantiateGem()
    {
        int index = Random.Range(0, spawnPoints.Count);

        GameObject D = Instantiate(Diamante, spawnPoints[index].transform.position, spawnPoints[index].transform.rotation);
        Destroy(D.gameObject, Random.Range(3, 6));

        //Invoke("Destruir", Random.Range(3, 6));
    }

    //void Destruir() { Destroy(Diamante); }
}
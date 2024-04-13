using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject Obstacle;
    float startDelay = 1.5f;
    float repeatRate = 2;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnObstacles", startDelay, repeatRate);
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    void SpawnObstacles()
    {
        Vector3 spawnPos = new Vector3(25, 0, 0);
        Instantiate(Obstacle, spawnPos, Obstacle.transform.rotation);
        Debug.Log("GameOver");
    }
}

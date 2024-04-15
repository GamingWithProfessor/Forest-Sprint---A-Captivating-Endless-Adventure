
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject Obstacle;
    float startDelay = 2;
    float repeatRate;
    PlayerController playerControllerScript;
    // Start is called before the first frame update
    void Start()
    {
        repeatRate = Random.Range(1, 5);
        InvokeRepeating("SpawnObstacles", startDelay, repeatRate);
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnObstacles()
    {        
        if (playerControllerScript.gameOver == false)
        {
            Vector3 spawnPos = new Vector3(25, 0, 0);
            Instantiate(Obstacle, spawnPos, Obstacle.transform.rotation);
        }          
    }
}

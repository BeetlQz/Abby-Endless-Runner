using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] obstaclePrefabs;

    public float ObstacleSpawnTime = 2f;

    [SerializeField] private float SpawnTimeMin = 2f;
    [SerializeField] private float SpawnTimeMax = 6f;
    [SerializeField] private float ObstacleSpeed = 3f;

    private float TimeUntilObstacleSpawn;

    GameManager gameManager;

    public List<GameObject> activeObstacles;

    [SerializeField] private GameObject stageStart;

    private void Start()
    {
        StartSpawn();
    }

    // Update is called once per frame
    private void Update()
    {
        if (GameManager.Instance.IsPlaying == true)
        {
            SpawnLoop();
        }
    }
    private void SpawnLoop()
    {
        TimeUntilObstacleSpawn += Time.deltaTime;

        if(TimeUntilObstacleSpawn >= ObstacleSpawnTime)
        {
            Spawn();
            ObstacleSpawnTime = Random.Range(SpawnTimeMin, SpawnTimeMax);
            TimeUntilObstacleSpawn = 0f;
        }

    }

    private void StartSpawn()
    {
        if(stageStart != null)
        {
            Rigidbody2D ObstacleRB = stageStart.GetComponent<Rigidbody2D>();
            ObstacleRB.velocity = Vector2.left * ObstacleSpeed;
            activeObstacles.Add(stageStart);
        }
    }
    private void Spawn()
    {
        GameObject ObstacleToSpawn = obstaclePrefabs[Random.Range(0, obstaclePrefabs.Length)];

        GameObject SpawnedObstacle = Instantiate(ObstacleToSpawn, transform.position, Quaternion.identity);

        Rigidbody2D ObstacleRB = SpawnedObstacle.GetComponent<Rigidbody2D>();
        ObstacleRB.velocity = Vector2.left * ObstacleSpeed;
        activeObstacles.Add(SpawnedObstacle);
    }

   /* public void ResumeObstacles()
    {
        foreach (GameObject obstacle in activeObstacles)
        {
            Rigidbody2D obstacleRB = obstacle.GetComponent<Rigidbody2D>();
            obstacleRB.velocity = Vector2.left * ObstacleSpeed;
        }
    }*/
}


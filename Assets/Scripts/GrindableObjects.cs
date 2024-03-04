using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrindableObjects : MonoBehaviour
{
    [SerializeField] private GameObject[] GrindObsPrefabs;

    public float GrindObsSpawnTime = 2f;

    [SerializeField] private float GrindObsSpawnTimeMin = 6f;
    [SerializeField] private float GrindObsSpawnTimeMax = 12f;
    [SerializeField] private float GrindObsSpeed = 3f;

    private float TimeUntilGrindObsSpawn;

    GameManager gameManager;

    public List<GameObject> activeGrindObs;

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
        TimeUntilGrindObsSpawn += Time.deltaTime;

        if (TimeUntilGrindObsSpawn >= GrindObsSpawnTime)
        {
            Spawn();
            GrindObsSpawnTime = Random.Range(GrindObsSpawnTimeMin, GrindObsSpawnTimeMax);
            TimeUntilGrindObsSpawn = 0f;
        }

    }

    private void StartSpawn()
    {
        if (stageStart != null)
        {
            Rigidbody2D ObstacleRB = stageStart.GetComponent<Rigidbody2D>();
            ObstacleRB.velocity = Vector2.left * GrindObsSpeed;
            activeGrindObs.Add(stageStart);
        }
    }
    private void Spawn()
    {
        GameObject ObstacleToSpawn = GrindObsPrefabs[Random.Range(0, GrindObsPrefabs.Length)];

        GameObject SpawnedObstacle = Instantiate(ObstacleToSpawn, transform.position, Quaternion.identity);

        Rigidbody2D ObstacleRB = SpawnedObstacle.GetComponent<Rigidbody2D>();
        ObstacleRB.velocity = Vector2.left * GrindObsSpeed;
        activeGrindObs.Add(SpawnedObstacle);
    }
}

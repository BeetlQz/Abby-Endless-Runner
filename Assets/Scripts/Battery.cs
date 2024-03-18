using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Battery : MonoBehaviour
{
    GameManager gameManager;

    private void OnTriggerEnter(Collider other)
    {
       /* PlayerInventory playerInventory = other.GetComponent<PlayerInventory>();

        if (playerInventory != null)
        {
            playerInventory.BatteryCollected();
            gameObject.SetActive(false);
        } */

    }  
    
    public void Start()
    {
        StartSpawn();
        gameManager = GameManager.Instance;
    }
   /* public void Collected()
    {
        gameManager.BatteryCollected();
    } */

    [SerializeField] private GameObject[] batteryPrefabs;

    public float BatterySpawnTime = 2f;

    [SerializeField] private float BatterySpawnTimeMin = 2f;
    [SerializeField] private float BatterySpawnTimeMax = 6f;
    [SerializeField] private float BatterySpeed = 3f;

    private float TimeUntilBatterySpawn;

    public List<GameObject> activeBatteries;

    [SerializeField] private GameObject stageStart;

  

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
        TimeUntilBatterySpawn += Time.deltaTime;

        if (TimeUntilBatterySpawn >= BatterySpawnTime)
        {
            Spawn();
            BatterySpawnTime = Random.Range(BatterySpawnTimeMin, BatterySpawnTimeMax);
            TimeUntilBatterySpawn = 0f;
        }

    }

    private void StartSpawn()
    {
        if (stageStart != null)
        {
            Rigidbody2D BatteryRB = stageStart.GetComponent<Rigidbody2D>();
            BatteryRB.velocity = Vector2.left * BatterySpeed;
            activeBatteries.Add(stageStart);
        }
    }
    private void Spawn()
    {
        GameObject BatteryToSpawn = batteryPrefabs[Random.Range(0, batteryPrefabs.Length)];

        GameObject SpawnedBattery = Instantiate(BatteryToSpawn, transform.position, Quaternion.identity);

        Rigidbody2D BatteryRB = SpawnedBattery.GetComponent<Rigidbody2D>();
        BatteryRB.velocity = Vector2.left * BatterySpeed;
        activeBatteries.Add(SpawnedBattery);
    }

}

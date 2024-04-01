using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundTile : MonoBehaviour
{
    public GameObject obstaclePrefab;
    public GameObject coinPrefab = null;
    GroundSpawner groundSpawner;
    // Start is called before the first frame update
    void Start()
    {
        groundSpawner = GameObject.FindObjectOfType<GroundSpawner>();
        SpawnObstacle();
        SpawnCoins();
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerExit(Collider other)
    {
        groundSpawner.SpawnTile();
        Destroy(gameObject, 2);
    }

    void SpawnObstacle()
    {
        int obstacleSpawnIndex = Random.Range(2, 5);
        Transform spawnPoint = transform.GetChild(obstacleSpawnIndex).transform;

        Instantiate(obstaclePrefab, spawnPoint.position, Quaternion.identity, transform);
    }

    void SpawnCoins()
    {
        int coinsToSpawn = 4;
        for (int i = 0; i < coinsToSpawn; i++)
        {
            GameObject temp = Instantiate(coinPrefab, transform);
            temp.transform.position = GetRandomPointInCollider(GetComponent<Collider>());
        }
    }
    Vector3 GetRandomPointInCollider(Collider collider)
    {
        Vector3 point = new Vector3(
        Random.Range(collider.bounds.min.x + 10, collider.bounds.max.x - 10),
        Random.Range(collider.bounds.min.y + 10, collider.bounds.max.y - 10),
        Random.Range(collider.bounds.min.z + 10, collider.bounds.max.z - 10)
        );

        if (point != collider.ClosestPoint(point))
        {
            point = GetRandomPointInCollider(collider);
        }

        point.y = 1;
        return point;
    }
}

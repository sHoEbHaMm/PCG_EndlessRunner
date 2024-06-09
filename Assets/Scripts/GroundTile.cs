using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundTile : MonoBehaviour
{
    public GameObject obstaclePrefab;
    public GameObject coinPrefab = null;
    GroundSpawner groundSpawner;

    public float noiseScale = 100f;
    public float noiseOffset = 0.0f;
    public float maxHeight = 5.0f;
    // Start is called before the first frame update
    void Start()
    {
        groundSpawner = GameObject.FindObjectOfType<GroundSpawner>();
        //SpawnObstacle();
        GenerateTerrainAtLocations(transform.GetChild(2).transform.position, transform.GetChild(3).transform.position, transform.GetChild(4).transform.position);
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

    void GenerateTerrainAtLocations(Vector3 location1, Vector3 location2, Vector3 location3)
    {
        GenerateCubeAtLocation(location1);
        GenerateCubeAtLocation(location2);
        GenerateCubeAtLocation(location3);
    }

    void GenerateCubeAtLocation(Vector3 location)
    {
        float noiseValue = Mathf.PerlinNoise((location.x + noiseOffset) * noiseScale, location.z * noiseScale);
        float height = noiseValue * maxHeight;

        Vector3 position = location;
        Vector3 scale = new Vector3(obstaclePrefab.transform.localScale.x, height, obstaclePrefab.transform.localScale.z);
        Quaternion rotation = Quaternion.identity;

        GameObject cube = Instantiate(obstaclePrefab, position, rotation);
        cube.transform.position = position;
        cube.transform.rotation = rotation;
        cube.transform.localScale = scale;
    }
}

using UnityEngine;
using System.Collections.Generic;

public class RoadSpawner : MonoBehaviour
{
    public GameObject roadPrefab;
    public Transform player;

    public float roadLength = 50f;
    public int roadCountAhead = 6;

    private float nextSpawnZ = 0f;

     private Queue<GameObject> roads = new Queue<GameObject>();

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
         // 最初に数枚生成
        for (int i = 0; i < roadCountAhead; i++){
            SpawnRoad();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(player.position.z + roadLength * roadCountAhead > nextSpawnZ){
            SpawnRoad();
        }
    }

    void SpawnRoad(){
        Vector3 spawnPosition = new Vector3(0f, 0f, nextSpawnZ);

        GameObject newRoad = Instantiate(roadPrefab, spawnPosition, Quaternion.identity);

        roads.Enqueue(newRoad);

        nextSpawnZ += roadLength;

        if (roads.Count>roadCountAhead){
            GameObject oldRoad = roads.Dequeue();
            Destroy(oldRoad);
        }
    }

}

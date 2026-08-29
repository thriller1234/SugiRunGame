using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject[] obstaclePrefabs;
    public Transform player;

    public float laneWidth = 3f;
    public float spawnDistance = 30f;
    public float spawnInterval = 2f;
    private float timer = 0f;

    void Update(){
        timer+=Time.deltaTime;

        if(timer>=spawnInterval){
            SpawnObstacle();
            timer=0f;
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void SpawnObstacle()
    {
        int lane=Random.Range(0,3);

        float xPosition=(lane-1)*laneWidth;
        //Obstacle_A~Cからランダムに1つ選ぶ
        int obstacleIndex=Random.Range(0, obstaclePrefabs.Length);

        Vector3 spawnPosition=new Vector3(xPosition,0.5f, player.position.z+spawnDistance);

        Instantiate(obstaclePrefabs[obstacleIndex], spawnPosition, Quaternion.identity);

    }

}

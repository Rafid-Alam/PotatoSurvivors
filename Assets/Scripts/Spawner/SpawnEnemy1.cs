using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy1 : MonoBehaviour
{
    private GameObject player;
    private float nextSpawnTime;
    public static float spawnCooldown;
    //public GameObject Enemy1Prefab;
    public GameObject[] enemyPrefabs;

    void Start(){
        player = GameObject.Find("Hero");
        nextSpawnTime = 0;
        spawnCooldown = 1.7f;
    }

    void Update(){
        if(Time.time > nextSpawnTime){
            int randEnemy = Random.Range(0, enemyPrefabs.Length);
            GameObject p = GameObject.Instantiate(enemyPrefabs[randEnemy]) as GameObject;
            Vector2 playerPos = player.transform.position;
            float[] xRanges = {Random.Range(playerPos.x - 230, playerPos.x - 180), Random.Range(playerPos.x + 180, playerPos.x + 230)};
            float[] yRanges = {Random.Range(playerPos.x -120, playerPos.x - 80), Random.Range(playerPos.x + 120, playerPos.x + 80)};
            float x = xRanges[Random.Range(0,2)];
            float y = yRanges[Random.Range(0,2)];
            p.transform.position = new Vector3(x, y, 0f);

            nextSpawnTime = Time.time + spawnCooldown; // sets cooldown until next spawn
        }
    }
}

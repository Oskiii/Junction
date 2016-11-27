using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PowerUpSpawner : MonoBehaviour {


    [SerializeField]
    private List<GameObject> PowerUps;
    public float SpawnDelay;
    private float lastSpawn;

    void SpawnPowerUp()
    {
        GameObject PoweUp = (GameObject)Instantiate(PowerUps[Random.Range(0, PowerUps.Count - 1)], new Vector2(Random.Range(-4, 4), Random.Range(-2, 2)), Quaternion.identity);
    }

    void Update()
    {
        if ((Time.time - lastSpawn) > SpawnDelay)
        {
            SpawnPowerUp();
            lastSpawn = Time.time;
        }

    }
}

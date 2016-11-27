using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PowerUpSpawner : MonoBehaviour {


    [SerializeField]
    private List<GameObject> PowerUps;
    public float SpawnDelay = 3;
    private float lastSpawn = 0;

    void SpawnPowerUp()
    {
        GameObject PoweUp = (GameObject)Instantiate(PowerUps[Random.Range(0, PowerUps.Count - 1)], new Vector2(Random.Range(-4, 4), Random.Range(-2, 2)), Quaternion.identity);
    }

    void Update()
    {
        print("PU: "+(Time.time - lastSpawn));
        if ((Time.time - lastSpawn) > SpawnDelay)
        {
            SpawnPowerUp();
            lastSpawn = Time.time;
        }

    }
}

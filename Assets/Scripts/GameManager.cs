using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
    public int ZombieAmount = 4;
	// Use this for initialization
    public void SpawnZombie()
    {
        GameObject zomb = (GameObject)Instantiate(ZombieObject, new Vector2 (Random.Range(-6, 6), Random.Range(-3,3)), Quaternion.identity);
    }
	void Start () {
        for (int i = 0; i < ZombieAmount; i++)
        {
            SpawnZombie();
        }
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}

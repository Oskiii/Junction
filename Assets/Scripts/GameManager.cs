using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour {
    public int ZombieAmount = 4;
    [SerializeField] private GameObject ZombieObject;
    public static GameManager Instance;
    public float SpawnDelay;
    private float lastSpawn;

    void Awake()
    {
        Instance = this;
    }
	// Use this for initialization
    public void SpawnZombie()
    {
        GameObject zomb = (GameObject)Instantiate(ZombieObject, new Vector2 (Random.Range(-3, 3), Random.Range(-1,1)), Quaternion.identity);
    }
	void Start () {
        Time.timeScale = 1;
        for (int i = 0; i < ZombieAmount; i++)
        {
            SpawnZombie();
        }
    }

    public void GameOver()
    {
        Time.timeScale = 0;
        GUIManager.Instance.ShowGameOverScreen();
    }
	
	// Update is called once per frame
	void Update () {

    }
}

using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
    public int ZombieAmount = 4;
    [SerializeField] private GameObject ZombieObject;
    public static GameManager Instance;

    void Awake()
    {
        Instance = this;
    }
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

    public void GameOver()
    {
        Time.timeScale = 0;
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}

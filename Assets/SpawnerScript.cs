using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpawnerScript : MonoBehaviour {

    public List<Vector2> path;
    public List<GameObject> enemies;

    public GameObject baseTower;

    public GameObject[,] objectGrid;

    List<GameObject> curTowers;

    struct Wave
    {
        public int enemy;
        public int count;
    }
    List<Wave> waves = new List<Wave>();

    public void AddWave(int enemy, int count)
    {
        Wave wave = new Wave();
        wave.enemy = enemy;
        wave.count = count;
        waves.Add(wave);
    }
    Wave nextWave;
    float enemyInterval = 1.0f;
    float enemyTimer = 0.0f;

    public float waveInterval = 5.0f;
    float waveTimer = 5.0f;


    public void Spawn(int enemyNum)
    {
        GameObject enemy = (GameObject)Instantiate(enemies[enemyNum], new Vector3(path[0].x, path[0].y, enemies[enemyNum].transform.position.z), Quaternion.identity);
        EnemyScript script = enemy.GetComponent<EnemyScript>();
        script.path = path;
    }

	// Use this for initialization
	public void StartSpawner () {
        curTowers = new List<GameObject>();
	}

    public void PlaceTower(int x, int y)
    {
        Vector3 p = objectGrid[x, y].transform.position;
        Vector3 spawnPoint = new Vector3(p.x, p.y, baseTower.transform.position.z);
        curTowers.Add((GameObject)Instantiate(baseTower, spawnPoint, Quaternion.identity));
    }
	
	// Update is called once per frame
	void Update () {
	    if(waveTimer > waveInterval)
        {
            if(nextWave.count <= 0)
            {
                if(waves.Count > 0)
                {
                    nextWave = waves[0];
                    waves.RemoveAt(0);
                    waveTimer = 0;
                }
                
                
            }
            else
            {
                if(enemyTimer > enemyInterval)
                {
                    Spawn(nextWave.enemy);
                    nextWave.count--;
                    enemyTimer = 0;
                }
                else
                {
                    enemyTimer += Time.deltaTime;
                }
            }
        }
        else
        {
            waveTimer += Time.deltaTime;
        }
	}
}

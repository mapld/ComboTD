using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpawnerScript : MonoBehaviour {

    public List<Vector2> path;
    public List<GameObject> enemies;

    public GameObject baseTower;

    public GameObject[,] objectGrid;

    List<GameObject> curTowers;

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
	
	}
}

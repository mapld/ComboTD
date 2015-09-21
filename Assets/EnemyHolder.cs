using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyHolder : MonoBehaviour {

    List<GameObject> enemies;

	// Use this for initialization
	void Start () {
        enemies = new List<GameObject>();
	}

    public void Add(GameObject enemy)
    {
        enemies.Add(enemy);
        
    }

    public void Remove(GameObject enemy)
    {
        enemies.Remove(enemy);
    }

    public GameObject getTarget(TowerScript towerScript)
    {
        GameObject tower = towerScript.gameObject;
        for (int i = 0; i < enemies.Count;i++ )
        {
            float diff = ((Vector2)tower.transform.position - (Vector2)enemies[i].transform.position).magnitude;
            if(diff < towerScript.attackRange)
            {
                return enemies[i];
            }
        }

        return null;
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}

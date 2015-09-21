using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyScript : MonoBehaviour {

    public List<Vector2> path;
    int goalPos = -1;

    public float moveSpeed = 1;
    public float moveThreshold = 0.1f;

    EnemyHolder enemyHolder;

    public int health;

    public void Hit(int damage)
    {
        health -= damage;
        if(health <= 0)
        {
            SelfDestruct();
        }
    }

    public void SelfDestruct()
    {
        enemyHolder.Remove(this.gameObject);
        Destroy(this.gameObject);
    }

	// Use this for initialization
	void Start () {
	    if(path != null)
        {
            transform.position = new Vector3(path[0].x, path[0].y, transform.position.z);
            if(path.Count > 1)
            {
                goalPos = 1;
            }
        }
        else
        {
            Debug.Log("No path found on enemy startup");
            path = new List<Vector2>();
        }

        enemyHolder = GameObject.FindObjectOfType<EnemyHolder>();
        enemyHolder.Add(this.gameObject);
	}
	
	// Update is called once per frame
	void Update () {
	    if(goalPos > 0)
        {
            Vector3 position = new Vector3(path[goalPos].x, path[goalPos].y, transform.position.z);
            Vector3 diff = (position - transform.position);
            Vector3 dir = diff.normalized;

            transform.position += dir * moveSpeed * Time.deltaTime;

            if(diff.magnitude < moveThreshold)
            {
                goalPos++;
                if(goalPos >= path.Count)
                {
                    goalPos = -1;
                }
            }

        }
	}
}

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TowerScript : MonoBehaviour {

    public float attackRange = 1;
    public GameObject ammo;

    EnemyHolder enemyHolder;

	// Use this for initialization
	void Start () {
        enemyHolder = GameObject.FindObjectOfType<EnemyHolder>();
	}
	
	// Update is called once per frame
	void Update () {
        GameObject target = enemyHolder.getTarget(this.GetComponent<TowerScript>());
        if(target)
        {
            Debug.Log("Shoot");
        }
	}

    
}

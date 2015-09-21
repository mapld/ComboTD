using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TowerScript : MonoBehaviour {

    public float attackRange = 1;
    public GameObject ammo;

    EnemyHolder enemyHolder;

    public float fireInterval = 0.5f;
    float fireTimer = 0.0f;

    public float ammoSpeed = 2;

	// Use this for initialization
	void Start () {
        enemyHolder = GameObject.FindObjectOfType<EnemyHolder>();
	}
	
	// Update is called once per frame
	void Update () {
        GameObject target = enemyHolder.getTarget(this.GetComponent<TowerScript>());
        if(target)
        {
            if(fireTimer > fireInterval)
            {
                GameObject bullet = (GameObject)Instantiate(ammo, transform.position, Quaternion.identity);
                bullet.GetComponent<ProjectileScript>().speed = ammoSpeed;
                bullet.GetComponent<ProjectileScript>().target = target;
                fireTimer = 0;
            }
            else
            {
                fireTimer += Time.deltaTime;
            }
            
        }
	}

    
}

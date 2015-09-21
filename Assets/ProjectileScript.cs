using UnityEngine;
using System.Collections;

public class ProjectileScript : MonoBehaviour {

    public GameObject target;
    public float speed;
    public float endThreshold = 0.05f;
    public int damage = 1;

	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
        if(target == null)
        {
            Destroy(this.gameObject);
            return;
        }

        Vector3 heading = (target.transform.position - transform.position);
        if(heading.magnitude < endThreshold)
        {
            target.GetComponent<EnemyScript>().Hit(damage);
            Destroy(this.gameObject);
        }
        heading.Normalize();
        transform.position += heading * speed * Time.deltaTime;
	}
}

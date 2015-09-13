using UnityEngine;
using System.Collections;

public class LevelScript : MonoBehaviour {

    protected GridScript grid;
    protected SpawnerScript spawner;

	protected void StartSpawner()
    {
        spawner = GetComponent<SpawnerScript>();
        spawner.path = grid.path;
        spawner.objectGrid = grid.objectGrid;
        spawner.StartSpawner();
    }
}

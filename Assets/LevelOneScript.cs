using UnityEngine;
using System.Collections;

public class LevelOneScript : LevelScript {

    //protected GridScript grid;
    //protected SpawnerScript spawner;

    void Start()
    {
        grid = GetComponent<GridScript>();
        grid.InitGrid();

        grid.addToPath(10, -1);
        grid.addToPath(10, 0);
        grid.addToPath(10, 1);
        grid.addToPath(10, 2);
        grid.addToPath(10, 3);
        grid.addToPath(9, 3);
        grid.addToPath(8, 3);
        grid.addToPath(7, 3);
        grid.addToPath(7, 4);
        grid.addToPath(7, 5);
        grid.addToPath(7, 6);
        grid.addToPath(8, 6);
        grid.addToPath(9, 6);
        grid.addToPath(10, 6);
        grid.addToPath(11, 6);
        grid.addToPath(12, 6);
        grid.addToPath(13, 6);
        grid.addToPath(14, 6);
        grid.addToPath(15, 6);
        grid.addToPath(16, 6);
        grid.addToPath(17, 6);
        grid.addToPath(18, 6);
        grid.addToPath(19, 6);
        grid.addToPath(20, 6);

        grid.StartGrid();


        StartSpawner();
        
        spawner.PlaceTower(6, 4);
        spawner.PlaceTower(8, 4);

        spawner.AddWave(0, 5);
        spawner.AddWave(0, 5);
        spawner.AddWave(0, 7);
        
    }


}

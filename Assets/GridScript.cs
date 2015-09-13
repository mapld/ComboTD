using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GridScript : MonoBehaviour {

    
    public int rows;
    public int columns;

    public GameObject baseOfGrid;
    public GameObject baseOfPath;
    
    public float lineWidth;

    float gridSize;
    float gapSize;

    float cameraWidth;
    float cameraHeight;

    public int[,] grid;
    public GameObject[,] objectGrid;
    public List<Vector2> path;

    Vector3 topLeftCorner;

    

    public void addToPath(int x, int y) // Adds a given location in the grid to the path and marks the spot in the grid
    {
        if(x >= 0 && x < grid.GetLength(0) && y >= 0 && y < grid.GetLength(1))
        {
            grid[x, y] = 1;
        }
        

        Vector3 curPos = topLeftCorner + new Vector3(gridSize / 2, -gridSize / 2, 0)
                    + new Vector3(gridSize * x, -gridSize * y)
                    + new Vector3(gapSize * (1 + x), -gapSize * (1 + y), 0);

        path.Add(curPos);
    }

    public void InitGrid()
    {
        gridSize = baseOfGrid.GetComponent<SpriteRenderer>().bounds.size.x;
        gapSize = gridSize * lineWidth / 1000;

        cameraWidth = Camera.main.orthographicSize * Screen.width / Screen.height; // get canera width in world size
        cameraHeight = cameraWidth * Screen.height / Screen.width;                 // get height from that

        topLeftCorner = (Vector2)Camera.main.transform.position + new Vector2(-cameraWidth, cameraHeight);

        grid = new int[columns, rows];
        path = new List<Vector2>();
        objectGrid = new GameObject[columns, rows];
        
    }

    

    

	public void StartGrid () 
    {

        for (int i = 0; i < columns; i++)
        {
            for (int j = 0; j < rows; j++)
            {
                Vector3 curPos = topLeftCorner + new Vector3(gridSize / 2, -gridSize / 2, 0)
                    + new Vector3(gridSize * i, -gridSize * j)
                    + new Vector3(gapSize * (1 + i), -gapSize * (1 + j), 0);

                if(grid[i,j] == 1) // 1 == path
                {
                    objectGrid[i,j] = (GameObject)Instantiate(baseOfPath, curPos, Quaternion.identity);
                    
                }
                else // default / 0 == basic grid piece
                {
                    objectGrid[i, j] = (GameObject)Instantiate(baseOfGrid, curPos, Quaternion.identity);
                }
                
            }
        }

         
	}
	

	void Update () 
    {
	
	}
}

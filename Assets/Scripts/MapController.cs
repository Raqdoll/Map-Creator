using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapController : MonoBehaviour
{
    [Range(1,50)]
    public int mapSize = 24;
    public GameObject tilePrefab;
    public GameObject[,] grid;
    public Canvas c;
    public InputField loadInput;
    [Range(5,50)]
    public float squareSize = 25;
    [Range(1, 20)]
    public float gapSize = 10;
    [Range(-100, 100)]
    public float offsetX = 10;
    [Range(-100, 100)]
    public float offsetY = 10;
    
    void Start()
    {
        grid = new GameObject[mapSize,mapSize];
        GenerateGrid();
    }

    //Loads a map added to the ReadMapFiles map list
    public void LoadMap()
    {
        string id = loadInput.text;
        int[,] loadedGrid = GetComponent<ReadMapFiles>().SearchMapByID(id);
        //Remove grid
        for (int i = 0; i < mapSize; i++)
        {
            for (int j = 0; j < mapSize; j++)
            {
                grid[i, j].GetComponent<Square>().DestroyThis();
            }
        }
        grid = new GameObject[mapSize, mapSize];
        //Create new one and apply the values
        GenerateGrid();
        for (int i = 0; i < mapSize; i++)
        {
            for (int j = 0; j < mapSize; j++)
            {
                grid[i, j].GetComponent<Square>().SetState(loadedGrid[i, j]);
            }
        }
    }
    //Creates a new grid of map tiles
    public void GenerateGrid()
    {
        for (int i = 0; i < mapSize; i++)
        {
            for (int j = 0; j < mapSize; j++)
            {
                Vector3 position = new Vector3((squareSize+gapSize)*c.transform.localScale.x*j+offsetX, (squareSize+gapSize)*c.transform.localScale.y*i+offsetY, 0f);
                grid[i, j] = Instantiate(tilePrefab, position, Quaternion.identity, c.transform);
            }
        }
    }
    //Resets all values given to the grid tiles
    public void ResetGrid()
    {
        for (int i = 0; i < mapSize; i++)
        {
            for (int j = 0; j < mapSize; j++)
            {
                grid[i, j].GetComponent<Square>().ResetThis();
            }
        }
    }
}

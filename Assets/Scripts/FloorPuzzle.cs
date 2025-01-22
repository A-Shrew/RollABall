using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FloorPuzzle : MonoBehaviour
{
    [SerializeField] private Material floorOn;
    [SerializeField] private Material floorOff;
    [SerializeField] private GameObject middleWall;
    [SerializeField] private GameObject[] floorTiles;
    private List<string> floorNames = new List<string>();
    private bool[] floorStatus = { false, false, false, false, false, false, false, false, false };

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
            foreach (GameObject tile in floorTiles)
            {
                tile.GetComponent<Renderer>().material = floorOff;
                floorNames.Add(tile.name);
            }
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("puzzle"))
        {
            Puzzle(collision.gameObject);
        }
    }
    private void Puzzle(GameObject tile)
    {
        switch (tile.name)
        {
            case "Cube00":
                flip(tile);
                flip(floorTiles[1]);
                flip(floorTiles[3]);
                break;
            case "Cube01":
                flip(tile);
                flip(floorTiles[0]);
                flip(floorTiles[2]);
                flip(floorTiles[4]);
                break;
            case "Cube02":
                flip(tile);
                flip(floorTiles[1]);
                flip(floorTiles[5]);
                break;
            case "Cube10":
                flip(tile);
                flip(floorTiles[0]);
                flip(floorTiles[4]);
                flip(floorTiles[6]);
                break;
            case "Cube11":
                flip(tile);
                flip(floorTiles[1]);
                flip(floorTiles[3]);
                flip(floorTiles[5]);
                flip(floorTiles[7]);
                break;
            case "Cube12":
                flip(tile);
                flip(floorTiles[2]);
                flip(floorTiles[4]);
                flip(floorTiles[8]);
                break;
            case "Cube20":
                flip(tile);
                flip(floorTiles[3]);
                flip(floorTiles[7]);
                break;
            case "Cube21":
                flip(tile);
                flip(floorTiles[4]);
                flip(floorTiles[6]);
                flip(floorTiles[8]);
                break;
            case "Cube22":
                flip(tile);
                flip(floorTiles[5]);
                flip(floorTiles[7]);
                break;
            default:
                return;
        }

        bool win = true;
        foreach(bool b in floorStatus)
        {
            if (b == false)
            {
                win = false;
            }
        }
        if (win == true)
        {
            Win();
        }
    }
    private void flip(GameObject tile)
    {
        int index = floorNames.IndexOf(tile.name);
        if (floorStatus[index] == false)
        {
            tile.GetComponent<Renderer>().material = floorOn;
            floorStatus[index] = true;  
        }
        else if (floorStatus[index] == true)
        {
            tile.GetComponent<Renderer>().material = floorOff;
            floorStatus[index] = false;
        }
    }
    private void Win()
    {
        GameObject.Destroy(middleWall);
    }
}

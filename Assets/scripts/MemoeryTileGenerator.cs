using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MemoeryTileGenerator : MonoBehaviour
{
    public GameObject myPrefab;
    public GameObject playerPrefab;

    public InputField input;

    public GameObject memoryField;

    public GameObject playerField;

    public GameObject startPoint;
    public GameObject playerStartPoint;

    private GameObject[,] spawnTiles = new GameObject[100, 100];
      
    private GameObject[,] spawnPlayerTiles = new GameObject[100, 100];
    private GameObject player;

    public float delta;

    public void GenerateTiles(int numbers)
    {
        foreach (GameObject item in spawnTiles)
        {
            Destroy (item);
        }
        
        foreach (GameObject item in spawnPlayerTiles)
        {
            Destroy (item);
        }
        Destroy(player);
        int n = int.Parse(input.text);
        var fieldSize = memoryField.GetComponent<Collider2D>().bounds.size.x;
        var tileSize = fieldSize / n;
        float spacing = tileSize * 0.1f;
        tileSize -= spacing;

        myPrefab.transform.localScale = new Vector3(tileSize, tileSize, 1); // tileize - faktor skliranja

        delta = Mathf.Sqrt(2) * (tileSize);
        Debug.Log(memoryField.transform.position);
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                Vector3 spawnPoint =
                    startPoint.transform.position +
                    new Vector3(i * (tileSize), j * (tileSize), .0f) +
                    new Vector3(tileSize / 2 + i * spacing,
                        tileSize / 2 + j * spacing,
                        -2f);

                spawnTiles[i, j] = getTile(spawnPoint);
                spawnPoint =
                    playerStartPoint.transform.position +
                    new Vector3(i * (tileSize), j * (tileSize), 0.0f) +
                    new Vector3(tileSize / 2 + i * spacing,
                        tileSize / 2 + j * spacing,
                        -2f);
                if(i==2 && j==2)
                    spawPlayerOnTile(spawnPoint, tileSize);
                spawnPlayerTiles[i,j]= getTile(spawnPoint);
                
            }
        }
    }
    private void spawPlayerOnTile(Vector3 spawnPoint, float tileSize){
        var player = Instantiate(playerPrefab, spawnPoint, Quaternion.identity) as GameObject;  
        player.transform.localScale = new Vector3(tileSize*2,tileSize*2,0.0f);
        player.transform.position += new Vector3(0,0,-1.0f);
        this.player = player;
        GameObject.FindGameObjectsWithTag("Start")[0].GetComponent<GameStart>().player = player;

    }
    private GameObject getTile(Vector3 spawnPoint)    
    {
        var tile = Instantiate(myPrefab, spawnPoint, Quaternion.identity) as GameObject;
        tile.AddComponent<MemoryFieldHandler>();
        tile.GetComponent<MemoryFieldHandler>().fieldValue =  setTileValue();
        tile.GetComponent<Renderer>().material = Resources.Load("dark", typeof (Material)) as Material;
        return tile;
    }
    private string setTileValue()
    {
        string[] tileValues =
            new string[] { "leftleft", "rightright", "upup", "downdown" };
        return tileValues[Random.Range(0, tileValues.Length) ];
        //return tileValues[2];
    }
}

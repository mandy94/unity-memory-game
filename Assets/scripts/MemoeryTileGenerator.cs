using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MemoeryTileGenerator : MonoBehaviour
{
    public GameObject myPrefab;

    public InputField input;

    public GameObject memoryField;

    public GameObject playerField;

    public GameObject startPoint;

    private GameObject[,] spawnTiles = new GameObject[100, 100];

    public float delta;

    public void GenerateTiles(int numbers)
    {
        foreach (GameObject item in spawnTiles)
        {
            Destroy (item);
        }

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
                    new Vector3(i * (tileSize), j * (tileSize), -2.0f) +
                    new Vector3(tileSize / 2 + i * spacing,
                        tileSize / 2 + j * spacing,
                        -2f);

                spawnTiles[i, j] =
                    Instantiate(myPrefab, spawnPoint, Quaternion.identity) as
                    GameObject;
                spawnTiles[i, j].AddComponent<MemoryFieldHandler>();

                spawnTiles[i, j].GetComponent<MemoryFieldHandler>().fieldValue =
                    setTileValue();

                spawnTiles[i, j].GetComponent<Renderer>().material =
                    Resources.Load("dark", typeof (Material)) as Material;
            }
        }
    }

    private string setTileValue()
    {
        string[] tileValues =
            new string[] { "leftleft", "rightright", "upup", "downdown" };
        return tileValues[Random.Range(0, tileValues.Length) ];
    }
}

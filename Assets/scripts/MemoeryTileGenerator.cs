using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MemoeryTileGenerator : MonoBehaviour
{
    public GameObject myPrefab;

    public GameObject otherPrefab;

    public GameObject playerPrefab;

    public InputField input;

    public GameObject memoryField;

    public GameObject playerField;

    public GameObject startPoint;

    public GameObject playerStartPoint;

    private List<GameObject> spawnTiles = new List<GameObject>();

    private List<GameObject> spawnPlayerTiles = new List<GameObject>();

    private GameObject player;

    public float delta;

    public void GenerateTiles()
    {
        foreach (GameObject item in spawnTiles)
        {
            Destroy (item);
        }

        foreach (GameObject item in spawnPlayerTiles)
        {
            Destroy (item);
        }
        Destroy (player);
        int n = SceneChanger.MATRIX_SIZE;
        if(n==0) n = 4; // This is probably because of a wrong scene order render. Just run the other one first
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
                        -0.2f);
                spawnTiles.Add(getTile(spawnPoint, tileSize));

                spawnPoint =
                    playerStartPoint.transform.position +
                    new Vector3(i * (tileSize), j * (tileSize), 0.0f) +
                    new Vector3(tileSize / 2 + i * spacing,
                        tileSize / 2 + j * spacing,
                        -0.2f);
                if (i == 2 && j == 2) spawPlayerOnTile(spawnPoint, tileSize);

                spawnPlayerTiles.Add(getOtherTile(spawnPoint, tileSize));
            }
        }

        setGoal(spawnPlayerTiles[spawnPlayerTiles.Count - 1]);
        validateTileValues();
    }

    void setGoal(GameObject goal)
    {
        goal.GetComponent<Renderer>().material =
            Resources.Load("end", typeof (Material)) as Material;
        goal.name = "End";

        GameObject
            .FindGameObjectsWithTag("Start")[0]
            .GetComponent<GameStart>()
            .end = goal;
    }

    private void spawPlayerOnTile(Vector3 spawnPoint, float tileSize)
    {
        var player =
            Instantiate(playerPrefab, spawnPoint, Quaternion.identity) as
            GameObject;
        player.transform.localScale =
            new Vector3(tileSize * 0.7f, tileSize * 0.7f, tileSize * 0.7f);
        player.transform.position += new Vector3(0, 0, -1.0f);
        player.name = "Player";

        player.GetComponent<Renderer>().material =
            Resources.Load("player", typeof (Material)) as Material;
        this.player = player;
        GameObject
            .FindGameObjectsWithTag("Start")[0]
            .GetComponent<GameStart>()
            .player = player;
    }

    private GameObject getTile(Vector3 spawnPoint, float tileSize)
    {
        var tile =
            Instantiate(myPrefab, spawnPoint, Quaternion.identity) as
            GameObject;
        tile.AddComponent<MemoryFieldHandler>();
        tile.GetComponent<MemoryFieldHandler>().fieldValue = setTileValue();

        return tile;
    }

    private GameObject getOtherTile(Vector3 spawnPoint, float tileSize)
    {
        var tile =
            Instantiate(otherPrefab, spawnPoint, Quaternion.identity) as
            GameObject;
        tile.transform.localScale =
            new Vector3(tileSize * 0.7f, tileSize * 0.7f, tileSize * 0.7f);

        return tile;
    }

    private void validateTileValues()
    {
      /*  if (arr[0] == arr[1] &&== arr[2] == arr[3]) return;
        var min = arr[0];
        var max = 0;
        foreach (var item in arr)
        {
            if (item < min)
            {
                min = item;
            }
            else if (item > max) max = item;
        }*/
    }

    private int[] arr = new int[3];

    private string setTileValue()
    {
        string[] tileValues = new string[] { "left", "up", "right", "down" };
        var i = Random.Range(0, tileValues.Length);
        arr[i]++;
        return tileValues[i];
    }
}

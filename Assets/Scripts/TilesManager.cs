using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TilesManager : MonoBehaviour
{
    public GameObject[] titlesPrefabs;

    private Transform player;

    private List<GameObject> activeTiles;

    private float spawnZ = 0f;

    private float tileLength = 44f;

    private int tilesOnScreen = 3;

    private void TaoDiaHinh(int index = -1)
    {
        GameObject gameObject;
        if (index == 0)
        {
            gameObject = Instantiate(titlesPrefabs[0]);
        }
        else
        {
            gameObject = Instantiate(titlesPrefabs[Random.Range(1, titlesPrefabs.Length)]);
        }
        gameObject.transform.SetParent(transform);
        gameObject.transform.position = Vector3.forward * spawnZ;
        spawnZ += tileLength;
        activeTiles.Add(gameObject);
    }

    private void XoaDiaHinh()
    {
        Destroy(activeTiles[0]);
        activeTiles.RemoveAt(0);
    }
    // Start is called before the first frame update
    void Start()
    {
        activeTiles = new List<GameObject>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        for (int i = 0; i < tilesOnScreen; i++)
        {
            if (i<1)
            {
                TaoDiaHinh(0);
            }
            else
            {
                TaoDiaHinh();
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if ((player.position.z - tileLength) > (spawnZ - tileLength*tilesOnScreen))
        {
            TaoDiaHinh();
            XoaDiaHinh();
        }
    }
}

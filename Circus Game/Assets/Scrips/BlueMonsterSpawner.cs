using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueMonsterSpawner : MonoBehaviour
{
    public GameObject MonsterPrefab;
    public int count = 30;


    public float timeBetSpawnerMin = 1.25f;
    public float timeBetSpawnerMax = 2.25f;

    private float timeBetSpawn;

    private GameObject[] Monster;

    private int currentIndex = 0;

    private Vector2 MonsterPosition = new Vector2(0, 0);


    private float lastSpawnTime;
    // Start is called before the first frame update
    void Start()
    {
        Monster = new GameObject[count];

        for (int i = 0; i < count; i++)
        {
            Monster[i] = Instantiate(MonsterPrefab, transform.position, Quaternion.identity);
            Monster[i].SetActive(false);
        }


        lastSpawnTime = 0f;
        timeBetSpawn = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.isGameOver)
        {
            return;
        }
        if (lastSpawnTime + timeBetSpawn <= Time.time)
        {
            lastSpawnTime = Time.time;
            timeBetSpawn = Random.Range(timeBetSpawnerMin, timeBetSpawnerMax);

            Monster[currentIndex].SetActive(false);
            Monster[currentIndex].SetActive(true);
            Monster[currentIndex].transform.position = transform.parent.position;
            currentIndex += 1;

            if (count <= currentIndex)
            {
                currentIndex = 0;
            }

        }
    }
}

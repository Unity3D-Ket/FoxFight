using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject [] EnemyList; //reference Enemy List
    private List <GameObject> Enemies = new List <GameObject>();


    // Start is called before the first frame update
    void Awake()
    {
        SpawnEnemy();
        StartCoroutine(EnemySpawnTimer(1));
    }


    void SpawnEnemy()
    {
        int index = 0;

        for (int b =0; b < EnemyList.Length * 8; b++) {
            GameObject Enemy = Instantiate(EnemyList[index], transform.position, Quaternion.identity) as GameObject;
            Enemies.Add(Enemy);
            Enemies[b].SetActive(false);

            index++;
            if (index == EnemyList.Length)
                index = 0;
        }
    }

    IEnumerator EnemySpawnTimer(float SpawnTime)
    {
        yield return new WaitForSeconds(SpawnTime);

        int RandomIndex = Random.Range (0,Enemies.Count);

        while (true)
        {

            if (!Enemies[RandomIndex].activeInHierarchy)
            {
                Enemies[RandomIndex].SetActive(true);
                Enemies[RandomIndex].transform.position = transform.position;
                break;
            }
            else {
                RandomIndex = Random.Range(0, Enemies.Count);
            }

        }

        StartCoroutine(EnemySpawnTimer(Random.Range(2,7)));
    }

}//spawner

using System.Collections;
using System.Collections.Generic;
using EnemySystem;
using UnityEngine;

public class Stage : MonoBehaviour
{
    // 스테이지의 전체 타일맵 정보
    [SerializeField] public List<TileMap> tilemapList;
    // 해당 스테이지에 필요한 몹 정보
    [SerializeField] public List<GameObject> enemyList;

    private List<int> mapIndex;
    private int excludeIndex;


    private void Awake() 
    {
        mapIndex        = new List<int>();
    }

    private void OnEnable()
    {
        for(int i = 0; i < tilemapList.Count; i++)
        {
            mapIndex.Add(i);
        }
        PoolEnemy();
        SpawnTilemap();
    }

    private void OnDisable()
    {
        mapIndex.Clear();
    }

    public void PoolEnemy()
    {
        for(int i = 0; i < enemyList.Count; i++)
        {
            PoolManager.Instance.AddPool(enemyList[i].name, enemyList[i], 10);
        }
    }

    public void NextTilemap()
    {
        SpawnTilemap();
    }

    private void SpawnTilemap()
    {
        excludeIndex = Random.Range(0, mapIndex.Count);
        mapIndex.Remove(excludeIndex);
        Instantiate(tilemapList[excludeIndex],transform);
    }

    public void StageClear()
    {
        gameObject.SetActive(false);
    }
}

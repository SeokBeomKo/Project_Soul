using System.Collections;
using System.Collections.Generic;
using EnemySystem;
using UnityEngine;

public class Stage : MonoBehaviour
{
    // 스테이지의 전체 타일맵 정보
    [SerializeField] public List<TileMap> tilemapList;
    // 해당 스테이지에 미리 풀링해야하는 오브젝트 정보
    [SerializeField] public List<GameObject> poolList;

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
        for(int i = 0; i < poolList.Count; i++)
        {
            PoolManager.Instance.AddPool(poolList[i].name, poolList[i], 10);
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

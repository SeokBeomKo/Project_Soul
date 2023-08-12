using System.Collections;
using System.Collections.Generic;
using EnemySystem;
using UnityEngine;

public class Stage : MonoBehaviour
{
    // 스테이지의 전체 타일맵 정보
    [SerializeField] public List<TileMap> tilemapList;
    // 해당 스테이지에 필요한 몹 정보
    [SerializeField] public List<EnemyData> enemyList;

    private List<int> mapIndex;
    private int excludeIndex;


    private void Awake() 
    {
        mapIndex        = new List<int>();
        for(int i = 0; i < tilemapList.Count; i++)
        {
            mapIndex.Add(i);
        }
    }

    public void Init()
    {
        SpawnTilemap();
    }

    public void NextTilemap()
    {
        SpawnTilemap();
    }

    private void SpawnTilemap()
    {
        excludeIndex = GetExcludeIndex();
        mapIndex.Remove(excludeIndex);
        Instantiate(tilemapList[excludeIndex],transform);
    }

    private int GetExcludeIndex()
    {
        return Random.Range(0, mapIndex.Count + 1);
    }

    public void ClearStage()
    {
        Destroy(gameObject);
    }
}

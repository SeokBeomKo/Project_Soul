using System.Collections;
using System.Collections.Generic;
using EnemySystem;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Stage : MonoBehaviour
{
    // 스테이지의 전체 타일맵 정보
    [SerializeField] public List<Tilemap> tilemapList;
    // 해당 스테이지에 필요한 몹 정보
    [SerializeField] public Dictionary<string, Enemy> enemyDic;

    [SerializeField] public List<int> mapIndex;
    [SerializeField] public List<int> excludeIndex;

    private void Awake() 
    {
        mapIndex = new List<int>();
    }




}

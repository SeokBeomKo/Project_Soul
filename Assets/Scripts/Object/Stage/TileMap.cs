using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tile;
using System;

public class TileMap : MonoBehaviour
{
    // 맵 로드 완료 이벤트 정의
    public delegate void OnMapLoadedHandler();
    public static event OnMapLoadedHandler OnMapLoaded;

    [SerializeField]    public List<Transform> tileList;
    [SerializeField]    public Dictionary<string,Vector2[]> enemyList;

    [SerializeField]    private StringListVector2Dictionary  exampleDictionary;

    // 이벤트를 정의합니다.
    public static event Action<GameObject> OnUIHPBar;

    private void OnEnable()
    {
        GameManager.Instance.nodeMap.Clear();
        foreach(Transform transform in tileList)
        {
            Vector2 position = new Vector2(transform.position.x,transform.position.z);
            GameManager.Instance.nodeMap[position] = new TileNode(position, null, int.MaxValue, int.MaxValue);
        }

        OnMapLoaded?.Invoke();

        for(int i = 0; i < exampleDictionary.Entries.Count; i++)
        {
            for(int j = 0; j < exampleDictionary.Entries[i].Value.Count; j++)
            {
                OnUIHPBar?.Invoke(PoolManager.Instance.SpawnFromPool(exampleDictionary.Entries[i].Key,new Vector3(exampleDictionary.Entries[i].Value[j].x,0,exampleDictionary.Entries[i].Value[j].y),Quaternion.identity));
            }
        }

        OnUIHPBar?.Invoke(GameManager.Instance.player.transform.parent.gameObject);
        GameManager.Instance.player.transform.parent.position = Vector3.zero;
    }
}

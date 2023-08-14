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
        // 맵 노드 초기화
        GameManager.Instance.nodeMap.Clear();
        foreach(Transform transform in tileList)
        {
            Vector2 position = new(transform.position.x,transform.position.z);
            GameManager.Instance.nodeMap[position] = new(position, null, int.MaxValue, int.MaxValue);
        }

        OnMapLoaded?.Invoke();

        // 에너미 생성
        for(int i = 0; i < exampleDictionary.Entries.Count; i++)
        {
            for(int j = 0; j < exampleDictionary.Entries[i].Value.Count; j++)
            {
                OnUIHPBar?.Invoke(PoolManager.Instance.SpawnFromPool(exampleDictionary.Entries[i].Key,new Vector3(exampleDictionary.Entries[i].Value[j].x,0,exampleDictionary.Entries[i].Value[j].y),Quaternion.identity));
            }
        }

        StartCoroutine(WaitForPlayer());
    }

    private IEnumerator WaitForPlayer()
    {
        // 플레이어가 null이 아닐 때까지 대기
        while (GameManager.Instance.player == null)
        {
            yield return null; // 다음 프레임까지 기다림
        }

        // 플레이어 생성 후 실행할 작업
        OnUIHPBar?.Invoke(GameManager.Instance.player.transform.parent.gameObject);
        GameManager.Instance.player.transform.parent.position = Vector3.zero;
    }
}

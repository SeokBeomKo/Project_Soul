using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tile;

public class TileMap : MonoBehaviour
{
    // 맵 로드 완료 이벤트 정의
    public delegate void OnMapLoadedHandler();
    public static event OnMapLoadedHandler OnMapLoaded;

    [SerializeField]    public List<Transform> tileList;
    [SerializeField]    public Dictionary<string,Vector2[]> enemyList;

    [SerializeField]    private StringListVector2Dictionary  exampleDictionary;


    private void OnEnable()
    {
        GameManager.Instance.nodeMap.Clear();
        foreach(Transform transform in tileList)
        {
            Vector2 position = new Vector2(transform.position.x,transform.position.z);
            GameManager.Instance.nodeMap[position] = new TileNode(position, null, int.MaxValue, int.MaxValue);
        }

        OnMapLoaded?.Invoke();
    }

}

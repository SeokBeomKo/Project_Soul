using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tile;

public class TileMap : MonoBehaviour
{
    [SerializeField]    public List<Transform> tileList;

    public void Init()
    {
        foreach(Transform transform in tileList)
        {
            Vector3Int position = Vector3Int.FloorToInt(new Vector3(transform.position.x,0,transform.position.z));
            GameManager.Instance.nodeMap[position] = new TileNode(position, null, int.MaxValue, int.MaxValue);
        }
    }
}

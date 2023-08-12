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
            Vector2 position = new Vector2(transform.position.x,transform.position.z);
            GameManager.Instance.nodeMap[position] = new TileNode(position, null, int.MaxValue, int.MaxValue);
        }
    }
}

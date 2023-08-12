using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using Tile;

public class GameManager : Singleton<GameManager>
{
    // 플레이어
    [SerializeField] private Player Player;
    public Player player { get => Player; } 

    // 씨네머신 카메라
    [SerializeField] public CinemachineBrain cinemachineBrain;

    // 불러올 맵 정보
    [SerializeField] public List<TileMap> tileMapList;
    // 현재 맵
    [SerializeField] public TileMap curTileMap;

    // 타일 맵 정보
    [SerializeField] public Dictionary<Vector2, TileNode> nodeMap;
    [SerializeField] public List<GameObject> entities;

    int rand;

    private void Awake() 
    {
        nodeMap = new Dictionary<Vector2, TileNode>();

        InitStage();
    }

    public void InitStage()
    {
        rand = Random.Range(0, tileMapList.Count);
        curTileMap = tileMapList[rand];
        curTileMap.Init();
        Instantiate(curTileMap);
        tileMapList.RemoveAt(rand);
    }

    public void InitPath()
    {
        foreach (KeyValuePair<Vector2, TileNode> entry in nodeMap)
        {
            entry.Value.G = int.MaxValue;
            entry.Value.H = int.MaxValue;
            entry.Value.Parent = null;
        }
    }

    public void SetWalkable(Vector2 _pos, bool _isWalkable)
    {
        nodeMap[_pos].isWalkable = _isWalkable;
    }

    public Camera GetActiveVirtualCamera()
    {  
        return cinemachineBrain.OutputCamera;
    }

}

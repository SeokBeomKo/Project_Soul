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

    // 스테이지 컨트롤러
    [SerializeField] public StageController stageController;

    // 현재 맵 정보
    [SerializeField] public Dictionary<Vector2, TileNode> nodeMap;      // 현재 타일맵 경로
    [SerializeField] public List<GameObject> entities;                  // 현재 타일맵 엔티티

    private void Awake() 
    {
        nodeMap = new Dictionary<Vector2, TileNode>();
    }

    void Start()
    {
        stageController.Init();
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

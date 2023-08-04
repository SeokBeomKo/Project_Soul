using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using Tile;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] private Player Player;
    public Player player { get => Player; } 

    [SerializeField] public CinemachineBrain cinemachineBrain;

    [SerializeField] public Dictionary<Vector3Int, TileNode> nodeMap;

    private void Awake() 
    {
        nodeMap = new Dictionary<Vector3Int, TileNode>();
    }

    public void InitPath()
    {
        foreach (KeyValuePair<Vector3Int, TileNode> entry in nodeMap)
        {
            entry.Value.G = int.MaxValue;
            entry.Value.H = int.MaxValue;
            entry.Value.Parent = null;
        }
    }

    public void SetWalkable(Vector3Int pos, bool isWalkable)
    {
        nodeMap[pos].isWalkable = isWalkable;
    }

    public Camera GetActiveVirtualCamera()
    {  
        return cinemachineBrain.OutputCamera;
    }

}

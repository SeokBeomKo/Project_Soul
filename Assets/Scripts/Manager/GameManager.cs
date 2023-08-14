using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using Tile;
using UnityEngine.TextCore.Text;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] StringGameObjectDictionary playerDictionary;
    // 플레이어
    private Player _player;
    [HideInInspector]   public Player player
    {
        get { return _player; }
        set
        {
            _player = value;
            Setting(_player.transform);
        }
    }

    // 씨네머신 카메라
    [SerializeField] public CinemachineBrain cinemachineBrain;

    // 미니맵 카메라
    [SerializeField] public Camera miniCam;

    // 스테이지 컨트롤러
    [SerializeField] public StageController stageController;

    // 현재 맵 정보
    [SerializeField] public Dictionary<Vector2, TileNode> nodeMap;      // 현재 타일맵 경로

    private void Awake() 
    {
        nodeMap = new Dictionary<Vector2, TileNode>();
    }

    void Start()
    {
        stageController.Init();
        
        for(int i = 0; i < playerDictionary.Entries.Count; i++)
        {
            PoolManager.Instance.AddPool(playerDictionary.Entries[i].Key,playerDictionary.Entries[i].Value,1);
        }
        player = PoolManager.Instance.SpawnFromPool(playerDictionary.Entries[0].Key,Vector3.zero,Quaternion.identity).GetComponentInChildren<Player>();
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

    public void Setting(Transform _target)
    {
        cinemachineBrain.ActiveVirtualCamera.Follow = _target;
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

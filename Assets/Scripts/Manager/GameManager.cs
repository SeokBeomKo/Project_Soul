using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] private Player Player;
    public Player player { get => Player; } 

    [SerializeField] public CinemachineBrain cinemachineBrain;

    private void Awake() 
    {
        
    }

    public Camera GetActiveVirtualCamera()
    {  
        return cinemachineBrain.OutputCamera;
    }

}

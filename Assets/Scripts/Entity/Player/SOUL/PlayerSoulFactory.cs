using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSoulFactory : MonoBehaviour
{
    private Dictionary<string, IPlayerSoul> soulInstances;

    public PlayerSoulFactory()
    {
        soulInstances = new Dictionary<string, IPlayerSoul>();

        // 게임의 직업을 사전에 생성하고 Dictionary에 추가합니다.
        soulInstances.Add("Archer", new Archer());
        soulInstances.Add("Warrior", new Warrior());
    }

    public IPlayerSoul GetJobInstance(string jobName)
    {
        if (soulInstances.ContainsKey(jobName))
        {
            return soulInstances[jobName];
        }
        return null;
    }
}

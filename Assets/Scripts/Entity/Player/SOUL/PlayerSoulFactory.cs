using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSoulFactory : MonoBehaviour
{
    public Player player;
    private Dictionary<PlayerSoulType, PlayerSoul> soulDic;

    private void Awake()
    {
        soulDic = new Dictionary<PlayerSoulType, PlayerSoul>();

        // 게임의 직업을 사전에 생성하고 Dictionary에 추가합니다.
        soulDic.Add(PlayerSoulType.NONE,          new NoneSoul());
        soulDic.Add(PlayerSoulType.SWORD,         new SwordSoul());
        soulDic.Add(PlayerSoulType.BLADE,         new BladeSoul());
        soulDic.Add(PlayerSoulType.SPEAR,         new SpearSoul());
        soulDic.Add(PlayerSoulType.BOW,           new BowSoul());
        soulDic.Add(PlayerSoulType.DUAL,          new DualSoul());
        soulDic.Add(PlayerSoulType.GREATESWORD,   new GreateSwordSoul());
        soulDic.Add(PlayerSoulType.HALBERD,       new HalberdSoul());
        soulDic.Add(PlayerSoulType.FIST,          new FistSoul());
        soulDic.Add(PlayerSoulType.GUN,           new GunSoul());
        soulDic.Add(PlayerSoulType.KATANA,        new KatanaSoul());

        foreach(PlayerSoul Value in soulDic.Values)
        {
            Value.player = player;
        }
    }

    public PlayerSoul GetSoul(PlayerSoulType soulType)
    {
        soulDic.TryGetValue(soulType, out PlayerSoul instance);
        return instance;
    }
}

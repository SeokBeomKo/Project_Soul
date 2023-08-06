using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSoulFactory : MonoBehaviour
{
    public Player player;
    private Dictionary<PlayerSoulType, PlayerSoul> soulDic;

    private void Awake()
    {
        // 게임의 직업을 사전에 생성하고 Dictionary에 추가합니다.
        soulDic = new Dictionary<PlayerSoulType, PlayerSoul>
        {
            { PlayerSoulType.NONE,          new NoneSoul() },
            { PlayerSoulType.SWORD,         new SwordSoul() },
            { PlayerSoulType.BLADE,         new BladeSoul() },
            { PlayerSoulType.SPEAR,         new SpearSoul() },
            { PlayerSoulType.BOW,           new BowSoul() },
            { PlayerSoulType.DUAL,          new DualSoul() },
            { PlayerSoulType.GREATESWORD,   new GreateSwordSoul() },
            { PlayerSoulType.HALBERD,       new HalberdSoul() },
            { PlayerSoulType.FIST,          new FistSoul() },
            { PlayerSoulType.GUN,           new GunSoul() },
            { PlayerSoulType.KATANA,        new KatanaSoul() }
        };

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

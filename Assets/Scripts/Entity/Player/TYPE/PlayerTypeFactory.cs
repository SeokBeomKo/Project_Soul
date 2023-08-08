using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTypeFactory : MonoBehaviour
{
    public Player player;
    private Dictionary<PlayerTypeEnums, PlayerType> typeDic;

    private void Awake()
    {
        // 게임의 직업을 사전에 생성하고 Dictionary에 추가합니다.
        typeDic = new Dictionary<PlayerTypeEnums, PlayerType>
        {
            { PlayerTypeEnums.NONE,          new NoneType() },
            { PlayerTypeEnums.SWORD,         new SwordType() },
            { PlayerTypeEnums.BLADE,         new BladeType() },
            { PlayerTypeEnums.SPEAR,         new SpearType() },
            { PlayerTypeEnums.BOW,           new BowType() },
            { PlayerTypeEnums.DUAL,          new DualType() },
            { PlayerTypeEnums.GREATESWORD,   new GreateSwordType() },
            { PlayerTypeEnums.HALBERD,       new HalberdType() },
            { PlayerTypeEnums.FIST,          new FistType() },
            { PlayerTypeEnums.GUN,           new GunType() },
            { PlayerTypeEnums.KATANA,        new KatanaType() }
        };

        foreach(PlayerType Value in typeDic.Values)
        {
            Value.player = player;
        }
    }

    public PlayerType GetSoul(PlayerTypeEnums type)
    {
        typeDic.TryGetValue(type, out PlayerType instance);
        return instance;
    }
}

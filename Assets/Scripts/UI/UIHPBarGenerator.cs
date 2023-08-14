using System.Collections;
using System.Collections.Generic;
using MagicaCloth2;
using UnityEngine;
using UnityEngine.Tilemaps;

public class UIHPBarGenerator : MonoBehaviour
{
    [SerializeField]    GameObject m_imgPrefab = null;

    [SerializeField]    List<Transform> m_objList = new List<Transform>();
    [SerializeField]    List<GameObject> m_hpBarList = new List<GameObject>();

    [SerializeField]    Dictionary<int,GameObject> hpBarDictionary;

    private void Awake()
    {
        hpBarDictionary = new Dictionary<int,GameObject>();
    }
    
    void Start()
    {
        PoolManager.Instance.AddPool("hpBar", m_imgPrefab, 20, true);
    }

    private void OnEnable() 
    {
        TileMap.OnUIHPBar += SetHPBar;
    }

    private void OnDisable() 
    {
        TileMap.OnUIHPBar -= SetHPBar;
    }

    void SetHPBar(GameObject obj)
    {
        GameObject t_hpBar = PoolManager.Instance.SpawnFromPool("hpBar", transform.position, Quaternion.identity);

        if (null == t_hpBar)
        {
            return;
        }

        UIHPBar uiHPBar = t_hpBar.GetComponent<UIHPBar>();
        Entity entity = obj.GetComponentInChildren<Entity>();

        uiHPBar.Init(entity);
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIHPBarGenerator : MonoBehaviour
{
    [SerializeField]    GameObject m_imgPrefab = null;

    [SerializeField]    List<Transform> m_objList = new List<Transform>();
    [SerializeField]    List<GameObject> m_hpBarList = new List<GameObject>();
    
    void Start()
    {
        List<GameObject> t_objList = new List<GameObject>();

        t_objList.Add(GameManager.Instance.player.transform.parent.gameObject);
        t_objList.AddRange(GameManager.Instance.entities);

        for(int i = 0; i < t_objList.Count; i++)
        {
            m_objList.Add(t_objList[i].transform);
            GameObject t_hpbar = Instantiate(m_imgPrefab, t_objList[i].transform.position, Quaternion.identity, transform);
            t_hpbar.GetComponent<UIHPBar>().Init(t_objList[i].GetComponentInChildren<Entity>());
            m_hpBarList.Add(t_hpbar);
        }
    }

    // Update is called once per frame
    void Update()
    {
        for(int i = 0; i < m_objList.Count; i++)
        {
            m_hpBarList[i].transform.position = GameManager.Instance.GetActiveVirtualCamera().WorldToScreenPoint(m_objList[i].position + Vector3.up);
        }
    }
}
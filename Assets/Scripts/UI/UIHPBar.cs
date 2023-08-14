using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIHPBar : MonoBehaviour, IObserver
{
    [SerializeField]    public Entity entity;

    [SerializeField]    public Image hpBase;
    [SerializeField]    public Image hpEffect;
    [SerializeField]    public bool isHit = false;

    float lerpTime = 0.5f;      // 러프가 진행될 시간
    float currentTime = 0f;


    public void Init(Entity _entity)
    {
        entity = _entity;
        entity.RegisterObserver(this);
    }
    void Update()
    {
        if (entity.entityInfo.hpCur == 0)
        {
            PoolManager.Instance.ReturnToPool("hpBar", gameObject);
        }

        transform.position = GameManager.Instance.GetActiveVirtualCamera().WorldToScreenPoint(entity.transform.parent.position + Vector3.up);

        // if(currentTime >= lerpTime)
        // {
        //     currentTime = lerpTime;
        // }

        if(isHit)
        {
            hpEffect.fillAmount = Mathf.Lerp(hpEffect.fillAmount, entity.entityInfo.hpCur / entity.entityInfo.hpMax, Time.deltaTime * 5f);
            if(hpEffect.fillAmount <= hpBase.fillAmount + 0.01f)
            {
                hpEffect.fillAmount = hpBase.fillAmount;
                isHit = false;
            }
        }
    }

    public void Notify()
    {
        hpBase.fillAmount = entity.entityInfo.hpCur / entity.entityInfo.hpMax;
        StartCoroutine(hpEffectUpdate());
    }

    public IEnumerator hpEffectUpdate()
    {
        yield return WaitForSecondsPool.GetWaitForSeconds(0.5f);
        isHit = true;
    }

    void OnDisable()
    {
        if (null == entity)
        {
            return;
        }
        entity.RemoveObserver(this);
    }
}

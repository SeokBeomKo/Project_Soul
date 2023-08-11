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


    public void Init(Entity _entity)
    {
        entity = _entity;
        entity.RegisterObserver(this);
    }
    void Update()
    {
        if (entity.curHP == 0)
        {
            gameObject.SetActive(false);
        }

        if(isHit)
        {
            hpEffect.fillAmount = Mathf.Lerp(hpEffect.fillAmount, entity.curHP / entity.maxHP, Time.deltaTime * 5f);
            if(hpEffect.fillAmount <= hpBase.fillAmount + 0.01f)
            {
                hpEffect.fillAmount = hpBase.fillAmount;
                isHit = false;
            }
        }
    }

    public void Notify()
    {
        hpBase.fillAmount = entity.curHP / entity.maxHP;
        StartCoroutine(hpEffectUpdate());
    }

    public IEnumerator hpEffectUpdate()
    {
        yield return WaitForSecondsPool.GetWaitForSeconds(0.5f);
        isHit = true;
    }

    void OnDisable()
    {
        entity.RemoveObserver(this);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleProjectile : MonoBehaviour
{
    [SerializeField] public string      objName;
    [SerializeField] LayerMask          layerMask;
    [SerializeField] float              speed = 0.1f;
    [SerializeField] float              disTime = 1f;

    void OnEnable()
    {
        Debug.Log("Projectile enabled");
        StartCoroutine(DisableAfterSeconds());
    }

    void Update()
    {
        transform.position += transform.forward * Time.deltaTime * speed;
    }

    private void OnTriggerEnter(Collider other) 
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {

            PoolManager.Instance.ReturnToPool(objName, gameObject);
        }
    }

    void OnDisable()
    {
        Debug.Log("Projectile disabled");
        StopCoroutine(DisableAfterSeconds());
    }

    private IEnumerator DisableAfterSeconds()
    {
        yield return WaitForSecondsPool.GetWaitForSeconds(disTime);
        PoolManager.Instance.ReturnToPool(objName, gameObject);
    }
}

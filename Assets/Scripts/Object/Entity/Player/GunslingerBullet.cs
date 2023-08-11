using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunslingerBullet : MonoBehaviour
{
    void OnEnable()
    {
        StartCoroutine(DisableAfterSeconds());
    }
    void Update()
    {
        transform.position += transform.forward * Time.deltaTime * 10f;
    }

    private void OnTriggerEnter(Collider other) 
    {
        if(other.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            gameObject.SetActive(false);
        }
    }

    void OnDisable()
    {
        StopCoroutine(DisableAfterSeconds());
    }

    private IEnumerator DisableAfterSeconds()
    {
        yield return WaitForSecondsPool.GetWaitForSeconds(1f);
        gameObject.SetActive(false);
    }
}

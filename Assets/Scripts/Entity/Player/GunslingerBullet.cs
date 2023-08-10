using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunslingerBullet : MonoBehaviour
{
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
}

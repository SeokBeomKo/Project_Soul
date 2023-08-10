using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationEventHandler : MonoBehaviour
{
    [SerializeField]    public PlayerVFX playerVFX;

    public void Test(float a, float b)
    {

    }

    public void attackVFX01()
    {
        playerVFX.attack01.transform.parent.position = transform.position;
        playerVFX.attack01.transform.parent.rotation = transform.rotation;
        playerVFX.attack01.Play();
    }
    public void attackVFX02()
    {
        playerVFX.attack02.transform.parent.position = transform.position;
        playerVFX.attack02.transform.parent.rotation = transform.rotation;
        playerVFX.attack02.Play();
    }
    public void attackVFX03()
    {
        playerVFX.attack03.transform.parent.position = transform.position;
        playerVFX.attack03.transform.parent.rotation = transform.rotation;
        playerVFX.attack03.Play();
    }
    public void attackVFX04()
    {
        playerVFX.attack04.transform.parent.position = transform.position;
        playerVFX.attack04.transform.parent.rotation = transform.rotation;
        playerVFX.attack04.Play();
    }
}

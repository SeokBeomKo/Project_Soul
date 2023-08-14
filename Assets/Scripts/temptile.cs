using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class temptile : MonoBehaviour
{
    [SerializeField] MeshRenderer meshRenderer;
    MaterialPropertyBlock materialPropertyBlock;
    bool isDebug = false;

    private void Start() {
        materialPropertyBlock = new MaterialPropertyBlock();
        meshRenderer.GetPropertyBlock(materialPropertyBlock, 0);
    }
    void Update()
    {
        if (Input.GetButtonDown("DebugMode"))
        {
            isDebug = !isDebug;

            if (isDebug)
            {
                StartCoroutine(DebugMode());
            }
            else
            {
                StopCoroutine("DebugMode");
            }
        }
    }

    public IEnumerator DebugMode()
    {
        if (GameManager.Instance.nodeMap[new Vector2(transform.position.x,transform.position.z)].isWalkable)
        {
            materialPropertyBlock.SetColor("_BaseColor",Color.green);
        }
        else
        {
            materialPropertyBlock.SetColor("_BaseColor",Color.red);
        }
        meshRenderer.SetPropertyBlock(materialPropertyBlock);
        yield return WaitForSecondsPool.GetWaitForSeconds(0.1f);
        StartCoroutine(DebugMode());
    }
}

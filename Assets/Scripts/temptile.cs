using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class temptile : MonoBehaviour
{
    [SerializeField] MeshRenderer meshRenderer;
    MaterialPropertyBlock materialPropertyBlock;

    private void Start() {
        materialPropertyBlock = new MaterialPropertyBlock();
        meshRenderer.GetPropertyBlock(materialPropertyBlock, 0);
    }
    void Update()
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
    }
}

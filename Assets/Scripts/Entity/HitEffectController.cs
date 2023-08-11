using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitEffectController : MonoBehaviour
{
    public SkinnedMeshRenderer characterRenderer;

    private List<MaterialPropertyBlock> propBlocks;
    private List<Dictionary<string, Color>> originalColorsList;

    private const string BaseColor1 = "_BaseColor";
    private const string BaseColor2 = "_1st_ShadeColor";
    private const string BaseColor3 = "_2nd_ShadeColor";

    private void Start()
    {
        int materialCount = characterRenderer.materials.Length;
        propBlocks = new List<MaterialPropertyBlock>(materialCount);
        originalColorsList = new List<Dictionary<string, Color>>(materialCount);

        for (int i = 0; i < materialCount; i++)
        {
            MaterialPropertyBlock propBlock = new MaterialPropertyBlock();
            characterRenderer.GetPropertyBlock(propBlock, i);

            Dictionary<string, Color> originalColors = new Dictionary<string, Color>
            {
                { BaseColor1, characterRenderer.materials[i].GetColor(BaseColor1) },
                { BaseColor2, characterRenderer.materials[i].GetColor(BaseColor2) },
                { BaseColor3, characterRenderer.materials[i].GetColor(BaseColor3) },
            };

            propBlocks.Add(propBlock);
            originalColorsList.Add(originalColors);
        }
    }

    public void ApplyHitEffect()
    {
        StartCoroutine(HitEffect());
    }

    private IEnumerator HitEffect()
    {
        for (int i = 0; i < propBlocks.Count; i++)
        {
            MaterialPropertyBlock propBlock = propBlocks[i];
            propBlock.SetColor(BaseColor1, Color.red);
            propBlock.SetColor(BaseColor2, Color.red);
            propBlock.SetColor(BaseColor3, Color.red);
            characterRenderer.SetPropertyBlock(propBlock, i);
        }

        yield return WaitForSecondsPool.GetWaitForSeconds(0.1f);
        
        for (int i = 0; i < propBlocks.Count; i++)
        {
            MaterialPropertyBlock propBlock = propBlocks[i];
            Dictionary<string, Color> originalColors = originalColorsList[i];

            foreach (var item in originalColors)
            {
                propBlock.SetColor(item.Key, item.Value);
            }

            characterRenderer.SetPropertyBlock(propBlock, i);
        }
    }
}

// MaterialPropertyBlock ?

// 1. 메모리 사용량 감소: 각 캐릭터나 오브젝트에 대해 별도의 메터리얼 인스턴스를 만들지 않으므로 메모리 사용량이 줄어든다.
// 2. 렌더링 성능 향상: 같은 메터리얼을 사용하는 여러 오브젝트가 있다면, 이들을 같이 렌더링하면서 필요한 Draw Call 수를 줄이고 성능이 향상된다.
// 3. 메터리얼 관리의 용이성: MaterialPropertyBlock을 사용하면 특정 오브젝트의 메터리얼 속성을 일시적으로 변경하면서 원본 메터리얼에 영향을 주지 않기 때문에, 더 쉽게 메터리얼을 관리할 수 있다.
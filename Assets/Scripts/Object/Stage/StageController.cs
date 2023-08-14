using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageController : MonoBehaviour
{
    [SerializeField] private List<Stage> stages;
    [SerializeField] public int         curstage;

    public void Init() 
    {
        curstage = 0;
        SpawnCurStage();
    }

    private void SpawnCurStage()
    {
        stages[curstage].gameObject.SetActive(true);
    }

    public void NextStage()
    {
        curstage++;

        SpawnCurStage();
    }
}

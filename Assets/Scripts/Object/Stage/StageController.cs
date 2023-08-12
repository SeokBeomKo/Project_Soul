using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageController : MonoBehaviour
{
    [SerializeField] private List<Stage> stages;
    [SerializeField] public int         curstage;

    private void Start() 
    {
        curstage = 0;
        SpawnCurStage();
    }

    private void SpawnCurStage()
    {
        Instantiate(stages[curstage],transform);
    }

    public void NextStage()
    {
        curstage++;

        SpawnCurStage();
    }
}

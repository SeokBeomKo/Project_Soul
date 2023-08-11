using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageController : MonoBehaviour
{
    [SerializeField] private List<Stage> stages;
    [SerializeField] public int         curstage;

    private void Awake() 
    {
        curstage = 0;    
    }

    public void CurStage()
    {
        Instantiate(stages[curstage],transform);
    }

    public void NextStage()
    {
        curstage++;
    }

    
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using EnemySystem;

[CustomEditor(typeof(EnemyData))]
public class EnemyDataEditor : Editor
{
    EnemyData data;

    SerializedProperty enemyInfo; 
    SerializedProperty meleeInfo; 
    SerializedProperty rangeInfo;
    SerializedProperty bossInfo; 

    public void OnEnable() 
    {
        {
            data = (EnemyData)target;
            enemyInfo = serializedObject.FindProperty("enemyInfo");
            meleeInfo = serializedObject.FindProperty("meleeInfo");
            rangeInfo = serializedObject.FindProperty("rangeInfo");
            bossInfo = serializedObject.FindProperty("bossInfo");
        }
    }

    public override void OnInspectorGUI()
    {
        data.Type = (EnemyTypeEnums)EditorGUILayout.EnumPopup("타입",data.Type);
        
        switch(data.Type)
        {
            case EnemyTypeEnums.MELEE:
                EditorGUILayout.PropertyField(enemyInfo);
                EditorGUILayout.PropertyField(meleeInfo);
                break;
            case EnemyTypeEnums.RANGE:
                EditorGUILayout.PropertyField(enemyInfo);
                EditorGUILayout.PropertyField(rangeInfo);
                break;
            case EnemyTypeEnums.BOSS:
                EditorGUILayout.PropertyField(enemyInfo);
                EditorGUILayout.PropertyField(bossInfo);
                break;
        }

        serializedObject.ApplyModifiedProperties ();
    }
}

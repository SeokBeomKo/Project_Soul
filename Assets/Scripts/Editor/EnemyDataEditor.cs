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
    SerializedProperty eliteInfo; 
    SerializedProperty bossInfo; 

    public void OnEnable() 
    {
        {
            data = (EnemyData)target;
            enemyInfo = serializedObject.FindProperty("enemyInfo");
            eliteInfo = serializedObject.FindProperty("eliteInfo");
            bossInfo = serializedObject.FindProperty("bossInfo");
        }
    }

    public override void OnInspectorGUI()
    {
        data.Type = (EnemyTypeEnums)EditorGUILayout.EnumPopup("타입",data.Type);
        
        switch(data.Type)
        {
            case EnemyTypeEnums.NORMAL:
                EditorGUILayout.PropertyField(enemyInfo);
                break;
            case EnemyTypeEnums.ELITE:
                EditorGUILayout.PropertyField(enemyInfo);
                EditorGUILayout.PropertyField(eliteInfo);
                break;
            case EnemyTypeEnums.BOSS:
                EditorGUILayout.PropertyField(enemyInfo);
                EditorGUILayout.PropertyField(bossInfo);
                break;
        }

        serializedObject.ApplyModifiedProperties ();
    }
}

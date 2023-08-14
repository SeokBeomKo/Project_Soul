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
    SerializedProperty turretInfo;

    SerializedProperty eliteInfo;
    SerializedProperty bossInfo; 

    public void OnEnable() 
    {
        data = (EnemyData)target;
        enemyInfo = serializedObject.FindProperty("enemyInfo");

        meleeInfo = serializedObject.FindProperty("meleeInfo");
        rangeInfo = serializedObject.FindProperty("rangeInfo");
        turretInfo = serializedObject.FindProperty("turretInfo");

        eliteInfo = serializedObject.FindProperty("eliteInfo");
        bossInfo = serializedObject.FindProperty("bossInfo");
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
            case EnemyTypeEnums.TURRET:
                EditorGUILayout.PropertyField(enemyInfo);
                EditorGUILayout.PropertyField(turretInfo);
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
    [SerializeField] public float moveSpeed = 1f;       // 객체의 이동 속도
    [SerializeField] public Vector3 targetPosition;     // 객체의 이동 목표 지점
}

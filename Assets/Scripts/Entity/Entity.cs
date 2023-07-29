using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class Entity : MonoBehaviour, IDamageable
{
    [SerializeField] public float moveSpeed = 2f;       // 객체의 이동 속도
    [SerializeField] public Vector3 targetPosition;     // 객체의 이동 목표 지점
    [SerializeField] public Tile curTile;               // 현재 타일의 정보

    public abstract IEnumerator Damaged();
}

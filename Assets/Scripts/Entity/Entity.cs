using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tile;

abstract public class Entity : MonoBehaviour, IDamageable
{
    public Vector3Int curTilePosition;     // 현재 타일 위치(키 값)
    public Vector3Int startPoint;          // 길 찾기 시작점
    public Vector3Int endPoint;            // 길 찾기 목표지점
    public List<Vector3Int> pathTiles;       // 길 찾기 경로 정보

    [SerializeField] public int                  attackRange;
    [SerializeField] public GameObject           attackTarget;

    [SerializeField] public int MaxHP;
    [SerializeField] public int curHP;
    [SerializeField] public int attDamage;
    [SerializeField] public float attSpeed;
    [SerializeField] public float moveSpeed = 2f;       // 객체의 이동 속도
    [SerializeField] public Vector3 targetPosition;     // 객체의 이동 목표 지점

    public abstract IEnumerator Damaged();
}

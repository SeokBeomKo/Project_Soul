using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

abstract public class Entity : MonoBehaviour, IDamageable, ISubject
{
    [HideInInspector]   public EntityInfo entityInfo;

    private Vector2 _tilePosition;
    [HideInInspector]   public Vector2 tilePosition
    {
        get { return _tilePosition; }
        set
        {
            // 이전 위치의 노드를 가져와서 isWalkable을 true로 설정
            if (GameManager.Instance.nodeMap.ContainsKey(_tilePosition))
            {
                GameManager.Instance.nodeMap[_tilePosition].isWalkable = true;
            }

            // 새로운 위치에 해당하는 노드의 isWalkable을 false로 설정
            if (GameManager.Instance.nodeMap.ContainsKey(value))
            {
                GameManager.Instance.nodeMap[value].isWalkable = false;
            }

            // tilePosition 변수 업데이트
            _tilePosition = value;
        }
    }

    [HideInInspector]   public List<Vector2> pathTiles;                     // 길 찾기 경로 정보
    
    public Vector3 moveTarget;                          // 객체의 이동 목표 지점
    public Entity attackTarget;                         // 공격 타겟

    public abstract void Hit(float _damage, float _ignore);


    // 체력바 UI 연동 옵저버
    private List<IObserver> observers = new List<IObserver>();

    public void RegisterObserver(IObserver observer)
    {
        observers.Add(observer);
    }

    public void RemoveObserver(IObserver observer)
    {
        observers.Remove(observer);
    }

    public void NotifyObservers()
    {
        foreach (var observer in observers)
        {
            observer.Notify();
        }
    }
}

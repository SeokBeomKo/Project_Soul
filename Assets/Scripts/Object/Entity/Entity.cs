using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class Entity : MonoBehaviour, IDamageable, ISubject
{
    [HideInInspector]   public EntityInfo entityInfo;

    [HideInInspector]   public Vector3Int curTilePosition;                  // 현재 타일 위치(키 값)
    [HideInInspector]   public Vector3Int startPoint;                       // 길 찾기 시작점
    [HideInInspector]   public Vector3Int endPoint;                         // 길 찾기 목표지점
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPlayerSoul
{
    Player player {get; set;}

    void Idle();
    void Moving();
    void Melee();
    void Skill();
    void Dead();
}

abstract public class PlayerSoul : IPlayerSoul
{
    public Player player {get; set;}

    abstract public void Melee();
    abstract public void Skill();

    public void Idle()
    {
                
        if (Input.GetMouseButtonDown(0) && !player.isMoving)
        {
            Ray ray = GameManager.Instance.GetActiveVirtualCamera().ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                // 타일 오브젝트를 감지했을 경우 처리
                Tile tileObject = hit.collider.GetComponent<Tile>();

                if (tileObject != null)
                {
                    // 타일 정보 가져오기
                    Vector3 objectPosition = hit.collider.transform.position;
                    int columnIndex = (int)(objectPosition.x);
                    int rowIndex = (int)(objectPosition.z);

                    // 타일 정보 출력
                    Debug.Log($"Clicked Tile: Column Index: {columnIndex}, Row Index: {rowIndex}");

                    player.targetPosition = objectPosition;
                    player.stateMachine.ChangeState(PlayerStateType.Moving);
                }
            }
        }
    }

    public void Moving()
    {
        if(Vector3.Distance(player.transform.position, player.targetPosition) <= 0.01f)
        {
            player.stateMachine.ChangeState(PlayerStateType.Idle);
        }
        float step = player.moveSpeed * Time.deltaTime;
        player.transform.parent.position = Vector3.MoveTowards(player.transform.position, player.targetPosition, step);
    }

    public void Dead()
    {

    }
}
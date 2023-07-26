using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveState : PlayerState
{
    public Player player {get; set;}
    public PlayerStateMachine stateMachine {get; set;}
    public void Init(PlayerStateMachine stateMachine)
    {

    }
    public void Excute()
    {
        if (Input.GetMouseButtonDown(0) && !player.isMoving)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
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
                    player.isMoving = true;
                }
            }
        }
        if (player.isMoving)
        {
            float step = player.moveSpeed * Time.deltaTime;
            player.transform.position = Vector3.MoveTowards(player.transform.position, player.targetPosition, step);
            player.isMoving = (Vector3.Distance(player.transform.position, player.targetPosition) > 0.001f);
        }
    }

    public void OnStateEnter()
    {

    }
    public void OnStateExit()
    {

    }
}

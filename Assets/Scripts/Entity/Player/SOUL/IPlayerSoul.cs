using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tile;

public interface IPlayerSoul
{
    Player player {get; set;}

    void Idle();
    void Moving();
    void Attack();
    void Skill();
    void Dead();
}

abstract public class PlayerSoul : IPlayerSoul
{
    public Player player {get; set;}

    abstract public void Attack();
    abstract public void Skill();

    public void Idle()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = GameManager.Instance.GetActiveVirtualCamera().ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                // 타일 오브젝트를 감지했을 경우 처리
                if (hit.collider.CompareTag("Tile"))
                {
                    Debug.Log("타일 클릭");
                    Debug.Log(Vector3Int.FloorToInt(hit.collider.GetComponent<Transform>().position));
                    TileNode targetTile = GameManager.Instance.nodeMap[Vector3Int.FloorToInt(hit.collider.GetComponent<Transform>().position)];
                    if (targetTile.isWalkable)
                    {
                        // 타일 정보 출력
                        Debug.Log($"Clicked Tile: Column Index: {targetTile.Position.x}, Row Index: {targetTile.Position.y}");

                        player.pathTiles = AStarAlgorithm.FindPath(GameManager.Instance.nodeMap, Vector3Int.FloorToInt(player.transform.parent.position), targetTile.Position);
                        GameManager.Instance.InitPath();
                        player.stateMachine.ChangeState(PlayerStateType.Moving);
                    }
                }
                // 적 오브젝트를 감지했을 경우 처리
                else if (hit.collider.CompareTag("Enemy"))
                {
                    Debug.Log("적 클릭");
                    GameObject enemy = hit.collider.gameObject;
                    Vector3Int enemyPosition = Vector3Int.FloorToInt(enemy.transform.parent.position);
                    Vector3Int playerPosition = Vector3Int.FloorToInt(player.transform.parent.position);

                    Vector3Int? targetTile = AStarAlgorithm.FindNearWalkableTile(playerPosition, enemyPosition, player.attackRange);
                    if (targetTile.HasValue)
                    {
                        Debug.Log($"Clicked Enemy: Column Index: {targetTile.Value.x}, Row Index: {targetTile.Value.y}");
                        player.pathTiles = AStarAlgorithm.FindPath(GameManager.Instance.nodeMap, Vector3Int.FloorToInt(player.transform.parent.position), targetTile.Value);
                        GameManager.Instance.InitPath();
                        player.stateMachine.ChangeState(PlayerStateType.Moving);
                        player.attackTarget = enemy;  // 플레이어의 공격 대상 설정
                    }
                }
            }
        }
    }
    int currentPathIndex = 0;  // 경로 인덱스
    public void Moving()
    {
        Debug.Log("이동 중");
         if (player.pathTiles != null && player.pathTiles.Count > 0 && currentPathIndex < player.pathTiles.Count)
        {
            Vector3 targetPosition = new Vector3(player.pathTiles[currentPathIndex].Position.x, player.transform.position.y, player.pathTiles[currentPathIndex].Position.z);
            player.transform.parent.LookAt(targetPosition);
            if (Vector3.Distance(player.transform.position, targetPosition) > Mathf.Epsilon)
            {
                player.transform.parent.position = Vector3.MoveTowards(player.transform.position, targetPosition, player.moveSpeed * Time.deltaTime);
            }
            else
            {
                player.transform.position = targetPosition;
                currentPathIndex++;

                if (currentPathIndex >= player.pathTiles.Count)
                {
                    currentPathIndex = 0;
                    player.pathTiles = null;  // 경로가 끝났으면 참조 제거, 필요에 따라 유지할 수 있습니다.

                    // 이동 후 공격 대상이 있다면 공격 상태로 전환
                    if (player.attackTarget != null)
                    {
                        player.stateMachine.ChangeState(PlayerStateType.Attack);
                    }
                    else
                    {
                        player.stateMachine.ChangeState(PlayerStateType.Idle);
                    }
                }
            }
        }
    }

    public void Dead()
    {

    }
}
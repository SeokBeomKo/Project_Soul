using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tile;

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
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = GameManager.Instance.GetActiveVirtualCamera().ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                // 타일 오브젝트를 감지했을 경우 처리
                if (hit.collider.CompareTag("Tile"))
                {
                    Debug.Log("클릭");
                    Debug.Log(Vector3Int.FloorToInt(hit.collider.GetComponent<Transform>().position));
                    TileNode targetTile = GameManager.Instance.nodeMap[Vector3Int.FloorToInt(hit.collider.GetComponent<Transform>().position)];
                    if (targetTile.isWalkable)
                    {
                        // 타일 정보 출력
                        Debug.Log($"Clicked Tile: Column Index: {targetTile.Position.x}, Row Index: {targetTile.Position.y}");

                        player.pathTiles = AStarAlgorithm.FindPath(GameManager.Instance.nodeMap, Vector3Int.FloorToInt(player.transform.position), targetTile.Position);
                        GameManager.Instance.InitPath();
                        player.stateMachine.ChangeState(PlayerStateType.Moving);
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

            if (Vector3.Distance(player.transform.position, targetPosition) > Mathf.Epsilon)
            {
                player.transform.parent.position = Vector3.MoveTowards(player.transform.position, targetPosition, player.moveSpeed * Time.deltaTime);
            }
            else
            {
                player.transform.position = targetPosition;
                currentPathIndex++;

                // 이동이 끝났을 때의 추가 로직 (예를 들어 상태 변경 등)은 여기에 추가해주시면 됩니다.
                if (currentPathIndex >= player.pathTiles.Count)
                {
                    currentPathIndex = 0;
                    player.pathTiles = null;  // 경로가 끝났으면 참조 제거, 필요에 따라 유지할 수 있습니다.
                    player.stateMachine.ChangeState(PlayerStateType.Idle);
                }
            }
        }
    }

    public void Dead()
    {

    }
}
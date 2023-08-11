using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tile;

public interface IPlayerType
{
    Player player {get; set;}

    void Idle();
    void Moving();
    void Attack();
    void Skill();
    void Dead();

    void OnAttack();
}

public abstract class PlayerType : MonoBehaviour, IPlayerType
{
    [SerializeField] public Player player{get; set;}

    public abstract void Attack();
    public abstract void Skill();

    public abstract void OnAttack();

    public void Idle()
    {
        // 클릭 감지
        if (!Input.GetMouseButtonDown(0))
        {
            return;
        }

        Ray ray = GameManager.Instance.GetActiveVirtualCamera().ScreenPointToRay(Input.mousePosition);
        if (!Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity, player.clickableLayers))
        {
            return;
        }

        Vector3Int playerPosition = Vector3Int.FloorToInt(player.transform.parent.position);
        Vector3Int clickedPosition = Vector3Int.FloorToInt(hit.collider.GetComponent<Transform>().parent.position);

        // 타일 오브젝트를 감지했을 경우 처리
        if (hit.collider.gameObject.layer == LayerMask.NameToLayer("Tile"))
        {
            TileClick(playerPosition, clickedPosition);
        }
        // 적 오브젝트를 감지했을 경우 처리
        if (hit.collider.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            player.attackTarget = hit.collider.gameObject;  // 플레이어의 공격 대상 설정
            EnemyClick(playerPosition, clickedPosition);
        }
    }

    private void EnemyClick(Vector3Int playerPosition, Vector3Int clickedPosition)
    {
        // 사거리 이내라면 공격
        if (Vector3Int.Distance(playerPosition, clickedPosition) <= player.attackRange)
        {
            player.stateMachine.ChangeState(PlayerStateEnums.Attack);
            return;
        }

        // 사거리 밖이라면 이동
        Vector3Int? targetTile = AStarAlgorithm.FindNearWalkableTile(playerPosition, clickedPosition, player.attackRange);
        if (!targetTile.HasValue)
        {
            return;
        }

        player.pathTiles = AStarAlgorithm.FindPath(GameManager.Instance.nodeMap, Vector3Int.FloorToInt(player.transform.parent.position), targetTile.Value);
        GameManager.Instance.InitPath();
        player.stateMachine.ChangeState(PlayerStateEnums.Moving);
    }

    private void TileClick(Vector3Int playerPosition, Vector3Int clickedPosition)
    {
        if (!GameManager.Instance.nodeMap[clickedPosition].isWalkable)
            {
                return;
            }
        // 타일 정보 출력
        Debug.Log($"Clicked Tile: Column Index: {clickedPosition.x}, Row Index: {clickedPosition.z}");
        player.pathTiles = AStarAlgorithm.FindPath(GameManager.Instance.nodeMap, playerPosition, clickedPosition);
        GameManager.Instance.InitPath();
        player.stateMachine.ChangeState(PlayerStateEnums.Moving);
        return;
    }

    int currentPathIndex = 0;  // 경로 인덱스
    public void Moving()
    {
        Debug.Log("이동 중");
        if (player.pathTiles == null || player.pathTiles.Count == 0 || currentPathIndex >= player.pathTiles.Count)
        {
            return;
        }
        Vector3 targetPosition = new Vector3(player.pathTiles[currentPathIndex].x, 0, player.pathTiles[currentPathIndex].z);
        if (Vector3.Distance(player.transform.parent.position, targetPosition) > Mathf.Epsilon)
        {
            player.transform.parent.LookAt(targetPosition);
            player.transform.parent.position = Vector3.MoveTowards(player.transform.parent.position, targetPosition, player.moveSpeed * Time.deltaTime);
        }
        else
        {
            player.transform.position = targetPosition;
            UpdatePathIndex();
            player.playerArea.NotifyObservers();
        }
    }

    private void UpdatePathIndex()
    {
        currentPathIndex++;
        if (currentPathIndex >= player.pathTiles.Count)
        {
            currentPathIndex = 0;
            player.pathTiles = null;  // 경로가 끝났으면 참조 제거, 필요에 따라 유지할 수 있습니다.
            // 이동 후 공격 대상이 있다면 공격 상태로 전환
            PlayerStateEnums nextState = player.attackTarget != null ? PlayerStateEnums.Attack : PlayerStateEnums.Idle;
            player.stateMachine.ChangeState(nextState);

            // 인식범위 내에 있는 적들에게 위치 업데이트됐음을 알림
            player.playerArea.NotifyObservers();
        }
    }

    public void Dead()
    {

    }
}
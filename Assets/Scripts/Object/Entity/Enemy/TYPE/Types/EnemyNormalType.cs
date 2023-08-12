using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EnemySystem
{
    public class EnemyNormalType : Enemy
    {
        public override void Idle()
        {
            
        }
        int currentPathIndex = 0;  // 경로 인덱스
        public override void Moving()
        {
            if (pathTiles == null || pathTiles.Count == 0 || currentPathIndex >= pathTiles.Count)
            {
                return;
            }
            Vector3 targetPosition = new Vector3(pathTiles[currentPathIndex].x, 0, pathTiles[currentPathIndex].y);
            if (Vector3.Distance(transform.parent.position, targetPosition) > Mathf.Epsilon)
            {
                transform.parent.LookAt(targetPosition);
                transform.parent.position = Vector3.MoveTowards(transform.parent.position, targetPosition, entityInfo.moveSpeed * Time.deltaTime);
            }
            else
            {
                transform.position = targetPosition;
                UpdatePathIndex();
            }
        }

        private void UpdatePathIndex()
        {
            currentPathIndex++;
            if (currentPathIndex >= pathTiles.Count)
            {
                currentPathIndex = 0;
                pathTiles = null;  // 경로가 끝났으면 참조 제거, 필요에 따라 유지할 수 있습니다.
                // 이동 후 공격 대상이 있다면 공격 상태로 전환
                EnemyStateEnums nextState = attackTarget != null ? EnemyStateEnums.Attack : EnemyStateEnums.Idle;
                stateMachine.ChangeState(nextState);
            }
        }

        public override void Battle()
        {
            // 사거리 이내라면 공격
            if (Vector3.Distance(attackTarget.transform.position, transform.parent.position) <= entityInfo.attRange)
            {
                stateMachine.ChangeState(EnemyStateEnums.Attack);
                return;
            }

            // 사거리 밖이라면 이동
            Vector2? targetTile = AStarAlgorithm.FindNearWalkableTile(new Vector2(transform.parent.position.x,transform.parent.position.z), 
                new Vector2(attackTarget.transform.position.x,attackTarget.transform.position.z), entityInfo.attRange);
            if (!targetTile.HasValue)
            {
                return;
            }

            pathTiles = AStarAlgorithm.FindPath(GameManager.Instance.nodeMap, Vector2Int.FloorToInt(new Vector2(transform.parent.position.x,transform.parent.position.y)), targetTile.Value);
            GameManager.Instance.InitPath();
            stateMachine.ChangeState(EnemyStateEnums.Moving);
        }
        public override void Attack()
        {
            if (attackTarget.entityInfo.hpCur <= 0f)
            {
                attackTarget = null;
                stateMachine.ChangeState(EnemyStateEnums.Idle);
            }
        }

        public override void OnAttack()
        {
            if(null == attVFX)
            {
                return;
            }

            attVFX.SetActive(true);
        }

        public override void OffAttack()
        {
            if(null == attVFX)
            {
                return;
            }

            attVFX.SetActive(false);
        }

        public override void Skill()
        {

        }
    }

}

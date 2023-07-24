using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Entity
{
    public float speed = 2.0f;        // 이동 속도
    public Vector3 targetPosition;    // 이동 목표 지점
    public bool isMoving;             // 이동 중인지 여부

    public Tile[,] tiles;             // 타일 맵을 저장하는 2차원 배열
    public TileMap map;
    private void Start()
    {
        targetPosition = transform.position;
        isMoving = false;

        // 여기에 타일 맵 로드와 초기화 코드를 작성하세요.
        tiles = map.tileList;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && !isMoving)
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
                    int columnIndex = (int)(objectPosition.x + 0.5f);
                    int rowIndex = (int)(objectPosition.z + 0.5f);

                    // 타일 정보 출력
                    Debug.Log($"Clicked Tile: Column Index: {columnIndex}, Row Index: {rowIndex}");

                    targetPosition = objectPosition;
                    isMoving = true;
                }
            }
        }

        if (isMoving)
        {
            float step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, step);
            isMoving = (Vector3.Distance(transform.position, targetPosition) > 0.001f);
        }
    }
}

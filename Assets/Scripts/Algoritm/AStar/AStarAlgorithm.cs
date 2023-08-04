using System.Collections;
using System.Collections.Generic;
using System;

using UnityEngine;

using DataStruct;
using Tile;

public class AStarAlgorithm
{
    private static readonly Vector3Int[] directions = {Vector3Int.forward, Vector3Int.back, Vector3Int.left, Vector3Int.right};

    private static int Heuristic(Vector3Int a, Vector3Int b)
    {
        return Mathf.Abs(a.x - b.x) + Mathf.Abs(a.z - b.z);
    }

    private static IEnumerable<Vector3Int> GetNeighbors(Vector3Int currentNode, Dictionary<Vector3Int, TileNode> nodeMap)
    {
        foreach (Vector3Int direction in directions)
        {
            Vector3Int neighborPos = currentNode + direction;
            if (nodeMap.ContainsKey(neighborPos) && nodeMap[neighborPos].isWalkable)
            {
                yield return neighborPos;
            }
        }
    }

    public static Vector3Int? FindNearWalkableTile(Vector3Int playerPosition, Vector3Int targetPosition, int inRange)
    {
        // 플레이어와 적의 상대 위치에 따른 정렬 로직
        List<Vector3Int> sortedDirections = new List<Vector3Int>(directions);
        sortedDirections.Sort((dirA, dirB) =>
        {
            Vector3Int newPosA = targetPosition + dirA;
            Vector3Int newPosB = targetPosition + dirB;
            float distA = Vector3Int.Distance(playerPosition, newPosA);
            float distB = Vector3Int.Distance(playerPosition, newPosB);
            return distA.CompareTo(distB);
        });
        targetPosition.y = 0;
        for (int i = 1; i <= inRange; i++)
        {
            foreach (Vector3Int direction in sortedDirections)
            {
                Vector3Int neighborPos = targetPosition + (direction * i);
                if (GameManager.Instance.nodeMap.ContainsKey(neighborPos) && GameManager.Instance.nodeMap[neighborPos].isWalkable)
                {
                    return neighborPos;
                }
            }
        }
        return null;
    }

    public static List<TileNode> FindPath(Dictionary<Vector3Int, TileNode> nodeMap, Vector3Int startNodePos, Vector3Int endNodePos)
    {
        TileNode startNode = nodeMap[startNodePos];
        TileNode endNode = nodeMap[endNodePos];

        PriorityQueue<TileNode> openSet = new PriorityQueue<TileNode>(new TileNodeComparer());
        HashSet<Vector3Int> closedSetPos = new HashSet<Vector3Int>();

        openSet.Enqueue(startNode);

        while (openSet.Count > 0)
        {
            TileNode current = openSet.Dequeue();
            Vector3Int currentPos = current.Position;

            closedSetPos.Add(currentPos);

            if (currentPos == endNodePos)
            {
                List<TileNode> path = new List<TileNode>();
                Vector3Int temp = currentPos;
                while (nodeMap[temp].Parent != null)
                {
                    path.Add(nodeMap[temp]);
                    temp = nodeMap[temp].Parent.Position;
                }
                path.Reverse();
                return path;
            }

            IEnumerable<Vector3Int> neighbors = GetNeighbors(currentPos, nodeMap);
            foreach (Vector3Int neighborPos in neighbors)
            {
                if (closedSetPos.Contains(neighborPos)) continue;

                int newCostToNeighbor = nodeMap[currentPos].G + Heuristic(currentPos, neighborPos);
                if (newCostToNeighbor < nodeMap[neighborPos].G)
                {
                    nodeMap[neighborPos].G = newCostToNeighbor;
                    nodeMap[neighborPos].H = Heuristic(neighborPos, endNodePos);
                    nodeMap[neighborPos].Parent = current;

                    if (!openSet.Contains(neighborPos))
                    {
                        openSet.Enqueue(nodeMap[neighborPos]);
                    }
                }
            }
        }

        return null;
    }

}

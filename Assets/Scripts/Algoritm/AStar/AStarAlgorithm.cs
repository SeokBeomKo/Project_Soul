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
        Vector3Int nearestTilePosition = Vector3Int.zero;
        float minDistance = float.MaxValue;

        targetPosition.y = 0;
        for (int i = 1; i <= inRange; i++)
        {
            foreach (Vector3Int direction in directions)
            {
                Vector3Int neighborPos = targetPosition + (direction * i);
                TileNode neighborTile;
                if (GameManager.Instance.nodeMap.TryGetValue(neighborPos, out neighborTile) && neighborTile.isWalkable)
                {
                    float distanceToPlayer = Vector3Int.Distance(playerPosition, neighborPos);
                    if (distanceToPlayer < minDistance)
                    {
                        nearestTilePosition = neighborPos;
                        minDistance = distanceToPlayer;
                    }
                }
            }
        }

        if (minDistance != float.MaxValue)
        {
            return nearestTilePosition;
        }
        return null;
    }

    public static List<Vector3Int> FindPath(Dictionary<Vector3Int, TileNode> nodeMap, Vector3Int startNodePos, Vector3Int endNodePos)
    {
        PriorityQueue<TileNode> openSet = new PriorityQueue<TileNode>(new TileNodeComparer());
        HashSet<Vector3Int> closedSetPos = new HashSet<Vector3Int>();

        openSet.Enqueue(nodeMap[startNodePos]);

        while (openSet.Count > 0)
        {
            TileNode current = openSet.Dequeue();
            Vector3Int currentPos = current.Position;

            closedSetPos.Add(currentPos);

            if (currentPos == endNodePos)
            {
                List<Vector3Int> path = new List<Vector3Int>();
                Vector3Int temp = currentPos;
                while (nodeMap[temp].Parent != null)
                {
                    path.Add(temp);
                    temp = nodeMap[temp].Parent.Position;
                }
                path.Reverse();
                return path;
            }

            IEnumerable<Vector3Int> neighbors = GetNeighbors(currentPos, nodeMap);
            foreach (Vector3Int neighborPos in neighbors)
            {
                if (closedSetPos.Contains(neighborPos)) continue;

                TileNode neighborNode = nodeMap[neighborPos];
                int newCostToNeighbor = neighborNode.G + Heuristic(currentPos, neighborPos);
                if (newCostToNeighbor < neighborNode.G)
                {
                    neighborNode.G = newCostToNeighbor;
                    neighborNode.H = Heuristic(neighborPos, endNodePos);
                    neighborNode.Parent = current;

                    if (!openSet.Contains(neighborPos))
                    {
                        openSet.Enqueue(neighborNode);
                    }
                }
            }
        }
        return null;
    }
}

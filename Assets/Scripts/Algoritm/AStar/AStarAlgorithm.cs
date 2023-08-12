using System.Collections;
using System.Collections.Generic;
using System;

using UnityEngine;

using DataStruct;
using Tile;

public class AStarAlgorithm
{
    private static readonly Vector2Int[] directions = {Vector2Int.up, Vector2Int.down, Vector2Int.left, Vector2Int.right};

    private static int Heuristic(Vector2Int a, Vector2Int b)
    {
        return Mathf.Abs(a.x - b.x) + Mathf.Abs(a.y - b.y);
    }

    private static IEnumerable<Vector2> GetNeighbors(Vector2 currentNode, Dictionary<Vector2, TileNode> nodeMap)
    {
        foreach (Vector2 direction in directions)
        {
            Vector2 neighborPos = currentNode + direction;
            if (nodeMap.ContainsKey(neighborPos) && nodeMap[neighborPos].isWalkable)
            {
                yield return neighborPos;
            }
        }
    }

    public static Vector2? FindNearWalkableTile(Vector2 playerPosition, Vector2 targetPosition, int inRange)
    {
        // 플레이어와 적의 상대 위치에 따른 정렬 로직
        Vector2 nearestTilePosition = Vector2.zero;
        float minDistance = float.MaxValue;

        for (int i = 1; i <= inRange; i++)
        {
            foreach (Vector2 direction in directions)
            {
                Vector2 neighborPos = targetPosition + (direction * i);
                TileNode neighborTile;
                if (GameManager.Instance.nodeMap.TryGetValue(neighborPos, out neighborTile) && neighborTile.isWalkable)
                {
                    float distanceToPlayer = Vector2.Distance(playerPosition, neighborPos);
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

    public static List<Vector2> FindPath(Dictionary<Vector2, TileNode> nodeMap, Vector2 startNodePos, Vector2 endNodePos)
    {
        PriorityQueue<TileNode> openSet = new PriorityQueue<TileNode>(new TileNodeComparer());
        HashSet<Vector2> closedSetPos = new HashSet<Vector2>();

        openSet.Enqueue(nodeMap[startNodePos]);

        while (openSet.Count > 0)
        {
            TileNode current = openSet.Dequeue();
            Vector2 currentPos = current.Position;

            closedSetPos.Add(currentPos);

            if (currentPos == endNodePos)
            {
                List<Vector2> path = new List<Vector2>();
                Vector2 temp = currentPos;
                while (nodeMap[temp].Parent != null)
                {
                    path.Add(temp);
                    temp = nodeMap[temp].Parent.Position;
                }
                path.Reverse();
                return path;
            }

            IEnumerable<Vector2> neighbors = GetNeighbors(currentPos, nodeMap);
            foreach (Vector2 neighborPos in neighbors)
            {
                if (closedSetPos.Contains(neighborPos)) continue;

                TileNode neighborNode = nodeMap[neighborPos];
                int newCostToNeighbor = neighborNode.G + Heuristic(Vector2Int.FloorToInt(currentPos), Vector2Int.FloorToInt(neighborPos));
                if (newCostToNeighbor < neighborNode.G)
                {
                    neighborNode.G = newCostToNeighbor;
                    neighborNode.H = Heuristic(Vector2Int.FloorToInt(neighborPos), Vector2Int.FloorToInt(endNodePos));
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

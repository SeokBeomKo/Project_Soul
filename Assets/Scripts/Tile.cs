using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
     // 타일 좌표
    public int X { get; set; }
    public int Y { get; set; }

    // 이동 가능 여부
    public bool IsEmpty { get; set; }

    public Tile(int x, int y, bool isEmpty)
    {
        X = x;
        Y = y;
        IsEmpty = isEmpty;
    }
}

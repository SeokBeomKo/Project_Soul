using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Tile
{
    public enum Info
    {
        Null,

        Entity,
        Item,
        Portal
    }
    public class TileNode : IComparable<TileNode>
    {
        public Info infoNode = Info.Null;
        public bool isWalkable = true;
        public Vector2 Position { get; set; }
        public TileNode Parent { get; set; }
        public int G { get; set; }
        public int H { get; set; }
        public int F { get { return G + H; } }

        public TileNode(Vector2 position, TileNode parent, int g, int h)
        {
            Position = position;
            Parent = parent;
            G = g;
            H = h;
        }

        public int CompareTo(TileNode other)
        {
            return F.CompareTo(other.F);
        }
    }
    public class TileNodeComparer : IComparer<TileNode>
    {
        public int Compare(TileNode x, TileNode y)
        {
            if (x == null && y == null) return 0;
            if (x == null) return -1;
            if (y == null) return 1;

            int xF = x.G + x.H;
            int yF = y.G + y.H;

            if (xF < yF) return -1;
            if (xF > yF) return 1;
            return 0;
        }
    }
}



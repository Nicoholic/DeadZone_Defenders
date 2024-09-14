using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrassTile : Tile
{
    [SerializeField] private Color _baseColor, _offColor;

    public override void Init(int x, int y)
    {
        var isOffSet = (x + y) % 2 == 1;
        _renderer.color = isOffSet ? _offColor : _baseColor;
    }
}

using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public abstract class Tile :  MonoBehaviour
{
    public string TilesName;
    [SerializeField] protected SpriteRenderer _renderer;
    [SerializeField] private GameObject _highLighter;
    [SerializeField] private bool _isWalkable;

    public BaseUnit occupiedUnit;
    public bool walkable => _isWalkable && occupiedUnit == null;

    public virtual void Init(int x, int y)
    {

    }

    private void OnMouseEnter()
    {
        _highLighter.SetActive(true);
        MenuManager.instance.ShowTileInfo(this);
    }

    private void OnMouseExit()
    {
        _highLighter.SetActive(false);
        MenuManager.instance.ShowTileInfo(null);
    }

    private void OnMouseDown()
    {
        if (GameManager.Instance.GameState != GameState.PlayerTurn)
        {
            return;
        }
        if (occupiedUnit != null)
        {
            if (occupiedUnit.faction == Faction.Player)
            {
                UnitManager.Instance.SetSelectedPlayer((BasePlayer)occupiedUnit);

                AudioManager.Instance.PlayerSFX();
                
            }
            else
            {
                if (UnitManager.Instance.selectedPlayer != null)
                {
                    var enemy = (BaseZombie)occupiedUnit;
                    Destroy(enemy.gameObject);
                    UnitManager.Instance.SetSelectedPlayer(null);
                }
            }
        }
        else
        {
            if (UnitManager.Instance.selectedPlayer != null)
            {
                SetUnit(UnitManager.Instance.selectedPlayer);
                UnitManager.Instance.selectedPlayer = null;
                
            }
        }
    }

    public void SetUnit(BaseUnit unit)
    {
        if (unit._occupiedTile != null)
        {
            unit._occupiedTile.occupiedUnit = null;
        }
        unit.transform.position = transform.position;
        occupiedUnit = unit;
        unit._occupiedTile = this;
    }
}

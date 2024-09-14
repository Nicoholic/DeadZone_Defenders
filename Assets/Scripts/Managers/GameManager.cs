using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public GameState GameState;

    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        ChangeState(GameState.GenerateGrid);
    }
    public void ChangeState(GameState _newState)
    {
        GameState = _newState;
        switch (_newState)
        {
            case GameState.GenerateGrid:
                GridManager.Instance.GenerateGrid();
                break;
            case GameState.SpawnPlayer:
                UnitManager.Instance.SpawnPlayer();
                break;
            case GameState.SpawnZombies:
                UnitManager.Instance.SpawnZombies();
                break;
            case GameState.PlayerTurn:
                UnitManager.Instance.PlayerTurn();
                break;
            case GameState.BuildingPhase:
                MenuManager.instance.ShowBuyStage();
                break;
            case GameState.ZombiesTurn:
                break;

        }
    }
}

public enum GameState
{
    GenerateGrid = 0,
    SpawnPlayer = 1,
    SpawnZombies = 2,
    PlayerTurn = 3,
    BuildingPhase = 4,
    ZombiesTurn = 5

}
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class UnitManager : MonoBehaviour
{
    [Header("Units Debug")]
    [SerializeField] bool _spawnPlayer;
    [SerializeField] bool _spawnZombie;
    [SerializeField] private int zombieCount = 1;
    public static UnitManager Instance;
    private List<ScriptableUnit> _units;
    public BasePlayer selectedPlayer;
    private void Awake()
    {
        Instance = this;

        _units = Resources.LoadAll<ScriptableUnit>("Units").ToList();
    }

    public void SpawnPlayer()
    {
        if (_spawnPlayer)
        {
            var heroCount = 1;
            for (int i = 0; i < heroCount; i++)
            {
                var randomPrefab = GetRandomUnit<BasePlayer>(Faction.Player);
                var spawnedPlayer = Instantiate(randomPrefab);
                var randomSpawnedTile = GridManager.Instance.GetPlayerSpawn();

                randomSpawnedTile.SetUnit(spawnedPlayer);
            } 
        }
        GameManager.Instance.ChangeState(GameState.SpawnZombies);
    }

    public void SpawnZombies()
    {

        if (_spawnZombie)
        {
            for (int i = 0; i < zombieCount; i++)
            {
                var randomPrefab = GetRandomUnit<BaseZombie>(Faction.Zombie);
                var spawnedZombie = Instantiate(randomPrefab);
                var randomSpawnedTile = GridManager.Instance.GetEnemySpawn();

                randomSpawnedTile.SetUnit(spawnedZombie);
            } 
        }

        GameManager.Instance.ChangeState(GameState.PlayerTurn);
    }

    private T GetRandomUnit<T>(Faction faction) where T : BaseUnit
    {
        return (T)_units.Where(u=>u.Faction == faction).OrderBy(o=>Random.value).First().unitPrefab;
    }


    public void SetSelectedPlayer(BasePlayer player)
    {
        selectedPlayer = player; 
        MenuManager.instance.ShowSelectedHero(player);
    }

    public void PlayerTurn()
    {
        //GameManager.Instance.ChangeState(GameState.BuildingPhase);
    }
}

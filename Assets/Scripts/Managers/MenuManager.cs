using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public static MenuManager instance;
    [SerializeField] private GameObject _selectedHeroObject, _tileObject, _tileUnitObject;
    
    
   
    private void Awake()
    {
        instance = this;
    }

    public void ShowTileInfo(Tile tile)
    {

        if (tile == null)
        {
            _tileObject.SetActive(false);
            _tileUnitObject.SetActive(false);
            return;
        }

        _tileObject.GetComponentInChildren<Text>().text = tile.TilesName;
        _tileObject.SetActive(true);

        if (tile.occupiedUnit)
        {
            _tileUnitObject.GetComponentInChildren<Text>().text = tile.occupiedUnit.unitName;
            _tileUnitObject.SetActive(true);
        }
    }
    public void ShowSelectedHero(BasePlayer player)
    {
        if (player == null)
        {
            _selectedHeroObject.SetActive(false);
            return;
        }
        _selectedHeroObject.GetComponentInChildren<Text>().text = player.unitName;
        _selectedHeroObject.SetActive(true);
    }


    public void ShowBuyStage()
    {
      
    }

    


    
}

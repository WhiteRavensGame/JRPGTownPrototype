using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BuildingUpgradeInfo : MonoBehaviour
{
    [SerializeField] private Building _building;
    [SerializeField] private BuildingController _buildingController;
    private BuildingLevel _buildingLevel;
                   
    [SerializeField] private TextMeshProUGUI _vNeedCurrent;
    [SerializeField] private TextMeshProUGUI _vNeedNext;

    [SerializeField] private TextMeshProUGUI _rProdCurrent;
    [SerializeField] private TextMeshProUGUI _rProdNext;

    [SerializeField] private TextMeshProUGUI _rNeedCurrent;
    [SerializeField] private TextMeshProUGUI _rNeedNext;
                    
    [SerializeField] private TextMeshProUGUI _r2ProdCurrent;
    [SerializeField] private TextMeshProUGUI _r2ProdNext;
                    
    [SerializeField] private TextMeshProUGUI _upgradeCost;

    [SerializeField] private TextMeshProUGUI _levelText;

    private void Awake()
    {
        _levelText.text = "Level: " + _building.GetLevel() + "/" + _building.GetMaxLevel();
    }

    public void UpdateResources()
    {
        _buildingLevel = _building.GetBuildingLevelInfo();

        _upgradeCost.text = "Upgrade " + _buildingLevel.getUpgradeCost.ToString();

        _vNeedCurrent.text = _buildingLevel.getMaxVillagers.ToString();
        _rProdCurrent.text = _buildingLevel.getMaxIncome.ToString();

        switch ((int)_building.GetBuildingType())
        {
            case 0:
                {
                    _rNeedCurrent.text = _buildingLevel.GetResourcesToRun().ToString();
                    break;
                }
            case 1:
                {
                    _rNeedCurrent.text = _buildingLevel.GetResourcesToRun().ToString();
                    //_r2ProdCurrent.text = (_building.GetLevel() * _building.GetLevel()).ToString();
                    break;
                }
            case 2:
                {
                    _rNeedCurrent.text = _buildingLevel.GetResourcesToRun().ToString();
                    int silkLevel = _building.GetLevel();
                    float amt = (0.25f * (silkLevel * silkLevel)) - (0.25f * silkLevel) + 0.5f;
                    _r2ProdCurrent.text = amt.ToString();
                    break;
                }
            default: break;
        }

        if (_buildingLevel.GetNextLevel != null)
        {
            _vNeedNext.text = _buildingLevel.GetNextLevel.getMaxVillagers.ToString();
            _rProdNext.text = _buildingLevel.GetNextLevel.getMaxIncome.ToString();

            switch ((int)_building.GetBuildingType())
            {
                case 0:
                    {
                        _rNeedNext.text = _buildingLevel.GetNextLevel.GetResourcesToRun().ToString();
                        break;
                    }
                case 1:
                    {
                        _rNeedNext.text = _buildingLevel.GetNextLevel.GetResourcesToRun().ToString();
                        _r2ProdNext.text = (_building.GetNextLevel() * _building.GetNextLevel()).ToString();
                        break;
                    }
                case 2:
                    {
                        _rNeedNext.text = _buildingLevel.GetNextLevel.GetResourcesToRun().ToString();
                        int x = _building.GetNextLevel();
                        int amt = (int)(((x * x) * 0.5f) - (x * 0.5f) + 1);
                        _r2ProdNext.text = amt.ToString();
                        break;
                    }
                default: break;
            }
        }
    }

    public void UpgradeBuilding()
    {
        _buildingController.ExecuteBuildingLevel();
        ServiceLocator.Get<ResourceManager>().UpdateResourceText();
        _levelText.text = "Level: " + _building.GetLevel() + "/" + _building.GetMaxLevel();
    }
}                                   
                                    

                                    
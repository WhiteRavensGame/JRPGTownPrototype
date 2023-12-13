using System.Collections.Generic;
using UnityEngine;

public class ResourceManager : MonoBehaviour
{
    //all the amounts of different resources will be here
    //functions for exchanging resources will also be here
    private UIManager _ui;

    private int _gold = 1500;
    private int _fish = 20;
    private int _iron = 20;
    private int _silk = 20;

    private float _morale = 50;
    private int _troops = 5;

    private int[] _borrowedMoney = new int[6];
    private int[] _daysLeftToReturnLoan = new int[6];

    public int Fish { get { return _fish; } }
    public int Iron { get { return _iron; } }
    public int Silk { get { return _silk; } }

    public void Initialize(UIManager ui)
    {
        if (ServiceLocator.Get<GameManager>().LoadGame)
        {
            Load();
        }

        _ui = ui;
        _ui.UpdateResourceText(_gold, _fish, _iron, _silk, _morale, _troops);
    }

    private void Update()
    {
        if(_morale > 100)
        {
            _morale = 100;
        }
    }

    public void AddGold(int gold)
    {
        _gold += gold;
    }

    public void TakeGold(int gold)
    {
        _gold -= gold;
    }

    public void AddResource(Resources resource, int amount)
    {
        switch (resource)
        {
            case Resources.Fish:
                _fish += amount;
                break;
            case Resources.Iron:
                _iron += amount;
                break;
            case Resources.Silk:
                _silk += amount;
                break;
            case Resources.Gold:
                _gold += amount;
                break;
            case Resources.Moral:
                _morale += amount;
                break;
            case Resources.Troops:
                _troops += amount;
                break;
            default:
                break;
        }
    }

    public bool CanUseGold(int amount)
    {
        if (_gold - amount < 0)
        {
            return false;
        }

        return true;
    }

    public int GetResourceAmt(Resources resource)
    {
        switch (resource)
        {
            case Resources.Fish:
                return _fish;
            case Resources.Iron:
                return _iron;
            case Resources.Silk:
                return _silk;
            case Resources.Troops:
                return _troops;
            case Resources.Gold:
                return _gold;
            case Resources.Moral:
                return (int)_morale;
            default: return 0;
        }
    }

    public float GetMorale()
    {
        return _morale;
    }

    public void SetMorale(float morale)
    {
        _morale = morale;
    }

    public void AddMorale(float amount)
    {
        _morale += amount;
    }

    public int UseResources(Resources resource, int amount)
    {
        switch (resource)
        {
            case Resources.Fish:
                if (_fish - amount <= 0)
                {
                    return 0;
                }
                _fish -= amount;
                return amount;
            case Resources.Iron:
                if (_iron - amount <= 0)
                {
                    return 0;
                }
                _iron -= amount;
                return amount;
            case Resources.Silk:
                if (_silk - amount <= 0)
                {
                    return 0;
                }
                _silk -= amount;
                return amount;
            case Resources.Moral:
                if (_morale - amount <= 0)
                {
                    return 0;
                }
                _morale -= amount;
                return amount;
            case Resources.Troops:
                if (_troops - amount <= 0)
                {
                    return 0;
                }
                _troops -= amount;
                return amount;
            default:
                return 0;
        }
    }

    public void LoanMoney(string resource, int val)
    {
        switch (resource)
        {
            case "Gold":
                _borrowedMoney[(int)Resources.Gold] = val;
                _daysLeftToReturnLoan[(int)Resources.Gold] = 5;
                _gold += val;
                return;
            case "Food":
                _borrowedMoney[(int)Resources.Fish] = val;
                _daysLeftToReturnLoan[(int)Resources.Fish] = 5;
                _fish += val;
                return;
            case "Materials":
                _borrowedMoney[(int)Resources.Iron] = val;
                _daysLeftToReturnLoan[(int)Resources.Iron] = 5;
                _iron += val;
                return;
            case "Silk":
                _borrowedMoney[(int)Resources.Silk] = val;
                _daysLeftToReturnLoan[(int)Resources.Silk] = 5;
                _silk += val;
                return;
            case "Morale":
                _borrowedMoney[(int)Resources.Moral] = val;
                _daysLeftToReturnLoan[(int)Resources.Moral] = 5;
                _morale += val;
                return;
            case "Troops":
                _borrowedMoney[(int)Resources.Troops] = val;
                _daysLeftToReturnLoan[(int)Resources.Troops] = 5;
                _troops += val;
                return;
            default: return;
        }
    }

    public void CheckLoanStatus()
    {
        for (int i = 0; i < _borrowedMoney.Length; ++i)
        {
            if (_daysLeftToReturnLoan[i] <= 0)
            {
                AddResource((Resources)i, -_borrowedMoney[i]);
                _borrowedMoney[i] = 0;
            }
            else
            {
                --_daysLeftToReturnLoan[i];
            }
        }
    }

    public void UpdateResourceText()
    {
        _ui.UpdateResourceText(_gold, _fish, _iron, _silk, _morale, _troops);
    }

    private void Load()
    {
        var newData = ServiceLocator.Get<SaveSystem>().Load<SaveResources>("RMsave.doNotOpen");
        if (!EqualityComparer<SaveResources>.Default.Equals(newData, default))
        {
            _gold = newData.gold;
            _fish = newData.fish;
            _iron = newData.iron;
            _silk = newData.silk;

            _morale = newData.morale;
            _troops = newData.troops;
        }
    }

    [ContextMenu("TestSave")]
    public void Save()
    {
        SaveResources saveResources = new SaveResources();
        saveResources.gold = _gold;
        saveResources.fish = _fish;
        saveResources.iron = _iron;
        saveResources.silk = _silk;
        saveResources.morale = _morale;
        saveResources.troops = _troops;
        ServiceLocator.Get<SaveSystem>().Save<SaveResources>(saveResources, "RMsave.doNotOpen");
    }

    [System.Serializable]
    public class SaveResources
    {
        public int gold = 1500;
        public int fish = 20;
        public int iron = 20;
        public int silk = 20;

        public float morale = 50;
        public int troops = 10;
    }
}

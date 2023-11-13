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

    private int _morale = 50;
    private int _defense = 50;
    private int _reputation = 0;

    public int Fish { get { return _fish; } }
    public int Iron { get { return _iron; } }
    public int Silk { get { return _silk; } }  

    public void Initialize(UIManager ui)
    {
        _ui = ui;
        _ui.UpdateResourceText(_gold, _fish, _iron, _silk);
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
            case Resources.Defence:
                _defense += amount;
                break;
            case Resources.Reputation:
                _reputation += amount;
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
        switch(resource)
        {
            case Resources.Fish:
                return _fish;
            case Resources.Iron:
                return _iron;
            case Resources.Silk:
                return _silk;
            default:
                return 0;
        }
    }

    public int UseResources(Resources resource, int amount)
    {
        switch (resource)
        {
            case Resources.Fish:
                if (_fish - amount <= 0)
                {
                    amount = _fish;
                    _fish = 0;
                    return amount;
                }
                _fish -= amount;
                return amount;
            case Resources.Iron:
                if (_iron - amount <= 0)
                {
                    amount = _iron;
                    _iron = 0;
                    return amount;
                }
                _iron -= amount;
                return amount;
            case Resources.Silk:
                if (_silk - amount <= 0)
                {
                    amount = _silk;
                    _silk = 0;
                    return amount;
                }
                _silk -= amount;
                return amount;
            case Resources.Moral:
                if (_morale - amount <= 0)
                {
                    amount = _morale;
                    _morale = 0;
                    return amount;
                }
                _morale -= amount;
                return amount;
            case Resources.Defence:
                if (_defense - amount <= 0)
                {
                    amount = _defense;
                    _defense = 0;
                    return amount;
                }
                _defense -= amount;
                return amount;
            case Resources.Reputation:
                if (_reputation - amount <= 0)
                {
                    amount = _reputation;
                    _reputation = 0;
                    return amount;
                }
                _reputation -= amount;
                return amount;
            default:
                return 0;
        }
    }

    public void UpdateResourceText()
    {
        _ui.UpdateResourceText(_gold, _fish, _iron, _silk);
    }
}

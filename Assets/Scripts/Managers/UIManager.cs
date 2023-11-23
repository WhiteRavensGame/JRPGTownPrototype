using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _goldText;
    [SerializeField] private TextMeshProUGUI _fishText;
    [SerializeField] private TextMeshProUGUI _ironText;
    [SerializeField] private TextMeshProUGUI _silkText;

    [SerializeField] private TextMeshProUGUI _villagerCount;

    public void UpdateResourceText(int gold, int fish, int iron, int silk)
    {
        _goldText.text = gold.ToString();
        _ironText.text = iron.ToString();
        _silkText.text = silk.ToString();
        _fishText.text = fish.ToString();
    }

    public void UpdateVillagerCount(int left, int total)
    {
        _villagerCount.text = left.ToString() + "/" + total.ToString();
    }
}

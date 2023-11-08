using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _goldText;
    [SerializeField] private TextMeshProUGUI _fishText;
    [SerializeField] private TextMeshProUGUI _ironText;
    [SerializeField] private TextMeshProUGUI _silkText;

    public void UpdateResourceText(int gold, int fish, int iron, int silk)
    {
        _goldText.text = gold.ToString().PadLeft(3);
        _ironText.text = fish.ToString().PadLeft(3);
        _silkText.text = iron.ToString().PadLeft(3);
        _fishText.text = silk.ToString().PadLeft(3);
    }
}

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
        _goldText.text = gold.ToString();
        _ironText.text = fish.ToString();
        _silkText.text = iron.ToString();
        _fishText.text = silk.ToString();
    }
}

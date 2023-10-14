using UnityEngine;
using UnityEngine.UI;

public class ShowCost : MonoBehaviour
{
    [SerializeField, Tooltip("コスト管理のスクリプト")] CostController _costController;
    [SerializeField, Tooltip("コスト表示のテキスト")] Text _nowText;
    [SerializeField, Tooltip("最大コスト表示のテキスト")] Text _nowMaxText;
    void Start()
    {
        _nowText.text = $"{_costController.NowHadCost}";
        _nowMaxText.text = $":{_costController.NowMaxCost}";
    }

    void Update()
    {
        _nowText.text = $"{_costController.NowHadCost.ToString("00000")}";
        _nowMaxText.text = $":{_costController.NowMaxCost.ToString("00000")}";
    }
}

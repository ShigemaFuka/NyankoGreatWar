using UnityEngine;
using UnityEngine.UI;

public class ShowCost : MonoBehaviour
{
    [SerializeField, Tooltip("�R�X�g�Ǘ��̃X�N���v�g")] CostController _costController;
    [SerializeField, Tooltip("�R�X�g�\���̃e�L�X�g")] Text _nowText;
    [SerializeField, Tooltip("�ő�R�X�g�\���̃e�L�X�g")] Text _nowMaxText;
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

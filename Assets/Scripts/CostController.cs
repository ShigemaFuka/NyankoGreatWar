using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// コスト増減
///時間経過でコストが貯まる
///コスト貯蓄レベルを上げると、貯蓄額の上限が上がる
///グレードを上げるには、一定額を消費する必要がある
///コストを消費してキャラクターを生成する 
/// 上限あり
///
///GM内で時間計算、それを読み取ってコスト計算、
///キャラ生成側でコストを読み取り、コストとインターバルが満たされたら生成可能にし、
///コスト管理側でコスト消費の関数を作り、キャラ生成側でそれを参照する
///最大コストを超えたら加算をやめ(TimerFlagをGMで用意)、余分を切り捨てる
///
/// 時間*加算量
/// </summary>
public class CostController : MonoBehaviour
{
    [SerializeField, Tooltip("最大コスト")] float _maxCost = 10000;
    [SerializeField, Tooltip("現在の保有コスト")] float _nowMaxCost = 1000;
    public float NowMaxCost { get => _nowMaxCost; set => _nowMaxCost = value; }
    [SerializeField, Tooltip("初期の最大コスト")] float _initialMaxCost;
    [SerializeField, Tooltip("現在の保有コスト")] float _nowHadCost;
    public float NowHadCost { get => _nowHadCost; set => _nowHadCost = value; }
    [SerializeField, Tooltip("加算する量")] float _addCost = 21.2f;
    [SerializeField, Tooltip("コスト表示のテキスト")] Text _nowText;
    [SerializeField, Tooltip("最大コスト表示のテキスト")] Text _nowMaxText;
    [SerializeField, Tooltip("最大コスト増加のフラグ")] bool _costGreadUp = false;
    [SerializeField, Tooltip("グレードアップに必要なコスト")]
    void Start()
    {
        NowHadCost = 0;
        _nowText.text = $"{NowHadCost}";
        _nowMaxText.text = $":{NowMaxCost}";
    }

    void Update()
    {
        //時間経過とともに現在の保有コストを増やす
        //if(NowHadCost < NowMaxCost) NowHadCost = GameManager.Instance.Timer * _addCost;
        if(NowHadCost < NowMaxCost) NowHadCost += Time.deltaTime * _addCost;
        _nowText.text = $"{NowHadCost.ToString("00000")}";
        _nowMaxText.text = $":{NowMaxCost.ToString("00000")}";
    }

    /// <summary>
    /// 使用時にコストを消費する 
    /// </summary>
    /// <param name="charaCost">生成するキャラのコスト</param>
    public void UseNowHadCost(float charaCost)
    {
        NowHadCost -= charaCost;
    }
    /// <summary>
    /// キャラのコスト以上に保有コストがあるか否か
    /// </summary>
    /// <param name="charaCost">生成するキャラのコスト</param>
    public bool JudgeCostValue(float charaCost)
    {
        if(0 <= NowHadCost - charaCost) return true;
        else return false;
    }
    /// <summary>
    /// 貯蓄コストの量を増加
    /// グレードを上げる際に、保有コストを一定数消費する
    /// </summary>
    public void GreadUpMaxCost()
    {
        if (_maxCost > _nowMaxCost)
        {
            _nowMaxCost *= 1.5f;
        }
        //加算後に_maxCostをオーバーしても補正する
        if (_maxCost <= _nowMaxCost) _nowMaxCost = _maxCost;
    }
}
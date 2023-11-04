using UnityEngine.EventSystems;
using UnityEngine;
using System.Collections.Generic;
/// <summary>
/// ドラッグするオブジェクトにアタッチする
/// そのオブジェクトを子オブジェクトにするための親オブジェクトが必要
/// ただし、どちらもRectTransformが必要
/// </summary>
public class PartySetController : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler, IBeginDragHandler
{
    RectTransform _rectTransform = default;
    [Tooltip("動かす前に所属していたデッキ")] Transform _originDeck = default;
    [SerializeField, Tooltip("カードをデッキの外に置けるかどうかの設定")] bool _canPutOutOfDeck = false;
    /// <summary>
    /// テーブルオブジェクト（"TableTag" が付いている UI オブジェクト）
    /// 元からオブジェクトがあるデッキでも、これから置くデッキでもないエリアのUIに当たる
    /// デッキ間の移動に必要
    /// </summary>
    GameObject _table = null;
    CountChild _countChild;

    void Start()
    {
        _rectTransform = GetComponent<RectTransform>();
        _table = GameObject.FindGameObjectWithTag("TableTag");
        _countChild = FindAnyObjectByType<CountChild>();
    }

    /// <summary>
    /// オブジェクトをドラッグするだけで、親子関係は影響なし
    /// </summary>
    /// <param name="eventData"></param>
    void IDragHandler.OnDrag(PointerEventData eventData)
    {
        _rectTransform.position = eventData.position;
    }

    /// <summary>
    /// _canPutOutOfDeckが真のとき、デッキ外におけるように
    /// 親子関係を変更している
    /// </summary>
    /// <param name="eventData"></param>
    void IBeginDragHandler.OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log($"OnBeginDrag: {this.name}");
        this.transform.SetParent(_table.transform);
    }

    void IPointerDownHandler.OnPointerDown(PointerEventData eventData)
    {
        var currentDeck = GetCurrentDeck(eventData);
        //デッキ外で離したときに、元のデッキに戻す
        if (!_canPutOutOfDeck) _originDeck = currentDeck.transform;
        //最前面になるようにヒエラルキーの下に配置
        this.gameObject.transform.SetAsLastSibling();
        string message = $"OnPointerDown: {this.name}: ";
        Debug.Log(message);
    }

    void IPointerUpHandler.OnPointerUp(PointerEventData eventData)
    {
        var currentDeck = GetCurrentDeck(eventData);
        // 親オブジェクトにするデッキエリアが見当たらないか
        // パーティーの最大数以上のとき
        if (currentDeck == null || _countChild.Count() >= _countChild.MaxPartyNum)
        {
            if (!_canPutOutOfDeck)
            {
                // 直前まで居たデッキに戻す
                this.transform.SetParent(_originDeck);
            }
        }
        else if (currentDeck != null)
        {
            if (currentDeck)
            {
                //子オブジェクトにする 
                this.transform.SetParent(currentDeck.transform);
            }
        }
    }

    /// <summary>
    /// ドラッグしたものをどの親オブジェクトの子オブジェクトにするか
    /// その親オブジェクトを返す
    /// </summary>
    /// <param name="eventData"></param>
    /// <returns>デッキエリアに該当する親オブジェクト</returns>
    GameObject GetCurrentDeck(PointerEventData eventData)
    {
        //親オブジェクトにあたるものと、その他ドラッグしているもの等を入れるList 
        var results = new List<RaycastResult>();
        // マウスポインタの位置上に重なっている UI を全て results に取得する（※）
        EventSystem.current.RaycastAll(eventData, results);
        // results に入っているオブジェクトのうち、DeckTag(親オブジェクトのタグ) が
        // 付いているオブジェクトを一つ result に取得する
        RaycastResult result = default;
        foreach (var item in results)
        {
            //親オブジェクトにあたるオブジェクトにつけたタグ
            //マウスポインタに感知したときに特定のタグつき親オブジェクトがあるということは、その上で
            //特定のものをドラッグしているということ
            if (item.gameObject.CompareTag("DeckTag"))
            {
                result = item;
                break;
            }
        }
        return result.gameObject;   // 結果の GameObject を返す
        //（※）EventSystem のインターフェイスを使った通常のプログラミングだと、オブジェクトが重なっている場合は「一番上に描画されているオブジェクト」しかマウスの動きを検出できない。
        // そのため、デッキの上にカードが重なっている場合、デッキ側でマウスの動きを検出できない。そのため EventSystem.current.RaycastAll を使う必要があった。
        // ちなみに Hierarchy 上で下にある UI オブジェクトが前面に描画される。
    }
}

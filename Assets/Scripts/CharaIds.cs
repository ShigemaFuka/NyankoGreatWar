using UnityEngine;
/// <summary>
/// 選択されたキャラのidを保存し、それに該当するidのボタンとジェネレータをアクティブ化する
/// その他は非アクティブにする
/// ボタンUIは非アクティブにすると、位置がそれ以外で右から配置されるため、要らない分のボタンUIを非アクティブにするだけでいい
/// 事前にボタンUIを全キャラ分用意（よって、キャラの配置順は強制的に決まっている）
/// ただし、同じキャラを選択することができない
/// </summary>
public class CharaIds : MonoBehaviour
{
    [SerializeField] public CharacterData _characterData;
    //[SerializeField] Ids _ids;
    //public Ids Id { get => _ids; set => _ids = value; }
    //public enum Ids
    //{
    //    Mouse,
    //    Tiger,
    //    Cow,
    //    Dragon,
    //    Rabbit,
    //    None
    ////}
    //void Start()
    //{
    //    _ids = (Ids)_characterData.Id;
    //}
}

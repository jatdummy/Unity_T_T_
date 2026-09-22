using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    private HashSet<float> _hashSet = new();

    private void Start()
    {
        _hashSet.Add(5f);
        _hashSet.Add(3.5f);
        _hashSet.Add(2.6f);
        _hashSet.Add(93.5f);

        if (_hashSet.Contains(5f)) Debug.Log("5f 들어있나?");

        Debug.Log(_hashSet.Count);
    }


}



/*
private Dictionary<string, GameObject> _dict = new();

private void Start()
{
_dict.Add("aaa", new GameObject());
_dict.Add("bbb", new GameObject());
_dict.Add("ccc", new GameObject());
_dict.Add("ddd", new GameObject());

Debug.Log(_dict.Count);

_dict.Remove("aaa");

if (!_dict.ContainsKey("aaa"))
{
    Debug.Log("aaa 삭제");
}
Debug.Log(_dict.Count);
}
*/




/*
private Dictionary<GameObject, int> dict = new();

[SerializeField] private GameObject _player;
[SerializeField] private GameObject _turret;
private void Start()
{
    dict[_player] = 5;
    dict.Add(_turret, 99);
    // dict.Add(_player, 10); 중복 키 추가 -> 에러

    Debug.Log(dict[_player]);

    int result;
    dict.TryGetValue(_player, out result);
    Debug.Log(result);

    // 키 조절하고 추가하기
    if (!dict.ContainsKey(_player))
    {
        dict[_player] = 10; // 혹은 Add 사용 가능.
    }
    else
    {
        Debug.Log("키 중복");
    }
    Debug.Log(dict[_player]);



    // TryAdd 사용하기
    if (dict.TryAdd(_player, 10))
    {
        Debug.Log("추가 성공");
    }
    else
    {
        Debug.Log("추가 실패");
    }

    Debug.Log(dict[_player]);
}
*/


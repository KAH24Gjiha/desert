using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum Type
{
    ingrediant, //식재료
    food, //모닥불에 가공한 음식 (먹을수 있음)
    material //부자재나무
}


[CreateAssetMenu]
public class Item : ScriptableObject
{
    public string Name;
    public int ItemNum; //아이템 고유번호, 이걸로 이미지를 받아올 것
    public Sprite sprite;
    public int Amount;
    public Type IType;

    public int fullness; //포만감, 부자재는 0
}

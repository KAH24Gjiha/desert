<<<<<<< HEAD:DesertQuest/Assets/Scripts/Item/Item.cs
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum Type
{
    ingrediant, //�����
    food, //��ںҿ� ������ ���� (������ ����)
    material //�����糪��
}


[CreateAssetMenu]
public class Item : ScriptableObject
{
    public string Name;
    public int ItemNum; //������ ������ȣ, �̰ɷ� �̹����� �޾ƿ� ��
    public Sprite sprite;
    public GameObject item;
    public int Amount;
    public Type IType;

    public int fullness; //������, ������� 0
}
=======
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum Type
{
    ingrediant, //�����
    food, //��ںҿ� ������ ���� (������ ����)
    material //�����糪��
}


[CreateAssetMenu]
public class Item : ScriptableObject
{
    public string Name;
    public int ItemNum; //������ ������ȣ, �̰ɷ� �̹����� �޾ƿ� ��
    public Sprite sprite;
    public int Amount;
    public Type IType;

    public int fullness; //������, ������� 0
}
>>>>>>> 65d51948a86366ec6d31944ab5cdf7f181b1470e:Assets/Scripts/Item/Item.cs

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

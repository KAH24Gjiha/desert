using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum Type
{
    ingrediant, //�����
    food, //��ںҿ� ������ ���� (������ ����)
    material //������
    
}

public class Item
{
    public string Name;
    public int ItemNum; //������ ������ȣ, �̰ɷ� �̹����� �޾ƿ� ��
    public int Amount;
    public Type IType;

    public int fullness; //������, ������� -1
}

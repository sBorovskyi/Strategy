using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class ShopItemSO : ScriptableObject
{
    public Sprite sprite;
    public int price;
    public GameObject itemPrefab;
}

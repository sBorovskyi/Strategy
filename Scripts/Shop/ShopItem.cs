using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopItem : MonoBehaviour
{
    [SerializeField] private Image itemImage;
    [SerializeField] private TextMeshProUGUI priceText;

    public void Setup(Sprite icon, int price)
    {
        itemImage.sprite = icon;
        priceText.text = price.ToString() + "$";
    }
}

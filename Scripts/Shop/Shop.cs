using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    [SerializeField] private List<ShopItemSO> shopItemsList;
    [SerializeField] private ShopItem buttonPrefab;
    [SerializeField] private Transform grid;

    private void Start()
    {
        SpawnAllButtons();
    }

    public void SpawnAllButtons()
    {
        foreach (ShopItemSO shopItem in shopItemsList)
        {
            ShopItem newShopItem = Instantiate(buttonPrefab, grid);
            newShopItem.Setup(shopItem.sprite, shopItem.price);
    
        }
    }
}

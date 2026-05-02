using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemUpdate : InventoryAbstract
{
    protected override void LoadComponents()
    {
        base.LoadComponents();
    }
    protected override void Start()
    {
        base.Start();
        Invoke(nameof(Test), 1);
        Invoke(nameof(Test), 1);


    }

    protected virtual void Test()
    {
        this.UpgradeItem(0);
    }

    protected virtual bool UpgradeItem(int index)
    {
        if (index >= this.inventory.items.Count) return false;
        ItemInventory itemInventory = this.inventory.items[index];
        if (itemInventory.itemCount < 1) return false;
        List<ItemRecipes> upgradeLevels = itemInventory.itemProfile.upgradeLevels;

        if (!ItemUpgradeable(upgradeLevels)) return false;
        if (!this.HaveEnoughIngredients(upgradeLevels, itemInventory.upgradeLevel)) return false;

        this.DeductIngredients(upgradeLevels, itemInventory.upgradeLevel);
        itemInventory.upgradeLevel++;

        return true;
    }

    protected virtual bool ItemUpgradeable(List<ItemRecipes> upgradeLevels)
    {
        if (upgradeLevels == null) return false;
        if (upgradeLevels.Count < 1) return false;
        return true;
    }

    protected virtual bool HaveEnoughIngredients(List<ItemRecipes> upgradeLevels, int currentLevel)
    {
        ItemCode itemCode;
        int itemCount;

        if (currentLevel > upgradeLevels.Count)
        {
            Debug.LogError("Item cant upgrade anymore, current: " + currentLevel);
            return false;
        }

        ItemRecipes currentRecipeLevel = upgradeLevels[currentLevel];
        foreach (ItemRecipeIngredient ingredient in currentRecipeLevel.ingredients)
        {
            itemCode = ingredient.itemProfile.itemCode;
            itemCount = ingredient.itemCount;

            if (!this.inventory.ItemCheck(itemCode, itemCount)) return false;
        }
        return true;
    }

    protected virtual void DeductIngredients(List<ItemRecipes> upgradeLevels, int currentLevel)
    {
        ItemCode itemCode;
        int itemCount;

        ItemRecipes currentRecipeLevel = upgradeLevels[currentLevel];
        foreach (ItemRecipeIngredient ingredient in currentRecipeLevel.ingredients)
        {
            itemCode = ingredient.itemProfile.itemCode;
            itemCount = ingredient.itemCount;

            this.inventory.DeductItem(itemCode, itemCount);
        }
    }





}

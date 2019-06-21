using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Items/Item")]
public class Item : ScriptableObject {

    public Sprite sprite;

}

[Serializable]
public class ItemInstance {

    public Item item;
    public int amount;

    public ItemInstance(Item item, int amount) {
        this.item = item;
        this.amount = amount;
    }

}
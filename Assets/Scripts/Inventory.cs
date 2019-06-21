using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour {

    public List<ItemInstance> items;

    public ItemInstance GetCurrenItem(Item item) {
        return this.items.Find(inst => inst.item == item);
    }

    public void AddItem(ItemInstance inst) {
        var curr = this.GetCurrenItem(inst.item);
        if (curr == null) {
            this.items.Add(inst);
        } else {
            curr.amount += inst.amount;
        }
    }

    public void RemoveItem(ItemInstance inst) {
        var curr = this.GetCurrenItem(inst.item);
        if (curr != null) {
            curr.amount -= inst.amount;
            if (curr.amount <= 0)
                this.items.Remove(curr);
        }
    }

}
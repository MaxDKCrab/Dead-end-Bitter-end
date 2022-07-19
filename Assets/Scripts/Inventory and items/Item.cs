using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New item", menuName = "Inventory/item")]
public class Item : ScriptableObject
{
    new public string name = "New Item";
    public Sprite icon = null;


    public virtual void Use()
    {
        // Use the item
        // Thing happen
        
        Debug.Log("Using " + name);
    }
    
}

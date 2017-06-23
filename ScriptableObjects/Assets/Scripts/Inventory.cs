using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour {
    public List<Item> items;
}

[System.Serializable]
public class Item : ScriptableObject{
    public string itemName;
    public List<ItemAttribute> attributes;
}

[System.Serializable]
public abstract class ItemAttribute : ScriptableObject{ }

[System.Serializable]
public class DamageAttribute : ItemAttribute {
    public float minDamage;
    public float maxDamage;
}

[System.Serializable]
public class StackableAttribute : ItemAttribute{
    public float maxStack;
}

[System.Serializable]
public class ImageAttribute : ItemAttribute
{
    public Texture2D image;
}

[System.Serializable]
public class ObjectAttribute : ItemAttribute
{
    public GameObject physRepresentation;
}
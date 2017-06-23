using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public enum eAttribTypes {
    STACK,
    DAMAGE,
    IMAGE,
    OBJECT
};

public class AddInventoryItem {
    static int itemCount = 0;

    [MenuItem("Assets/Create/Add New Item")]
    public static Item CreateItemAsset(string name = "item") {
        Item item = ScriptableObject.CreateInstance<Item>();
        item.itemName = name;

        AssetDatabase.CreateFolder("Assets/Inventory", name);
        AssetDatabase.CreateAsset(item, "Assets/Inventory/" + name + "/" + name + ".asset");
        AssetDatabase.SaveAssets();

        EditorUtility.FocusProjectWindow();

        itemCount++;
        Selection.activeObject = item;

        GameObject.FindObjectOfType<Inventory>().items.Add(item);

        return item;
    }

    public static ItemAttribute CreateItemAttrib(eAttribTypes type, string a_assetName, ref Item a_item) {
        ItemAttribute item = null;
        switch (type) {
            case eAttribTypes.STACK: item = ScriptableObject.CreateInstance<StackableAttribute>(); break;
            case eAttribTypes.DAMAGE: item = ScriptableObject.CreateInstance<DamageAttribute>(); break;
            case eAttribTypes.OBJECT: item = ScriptableObject.CreateInstance<ObjectAttribute>(); break;
            case eAttribTypes.IMAGE: item = ScriptableObject.CreateInstance<ImageAttribute>(); break;
        }

        if (item != null) {
            AssetDatabase.CreateAsset(item, "Assets/Inventory/" + a_assetName + "/" + type.ToString().ToLower() + "Attrib.asset");
            AssetDatabase.SaveAssets();

            EditorUtility.FocusProjectWindow();

            Selection.activeObject = item;
            if (a_item != null) {
                if(a_item.attributes == null){
                    a_item.attributes = new List<ItemAttribute>();
                }
                a_item.attributes.Add(item);
            }

        } else {
            Debug.LogWarning("NO TYPE DEFINED, NO ATTRIBUTE WAS ADDED");
        }

        return item;
    }

    [MenuItem("Assets/Create/Add New Damage Attribute")]
    public static ItemAttribute CreateItemDmgAttrib() {
        ItemAttribute item = ScriptableObject.CreateInstance<DamageAttribute>();

        AssetDatabase.CreateAsset(item, "Assets/Inventory/dmgAttrib.asset");
        AssetDatabase.SaveAssets();

        EditorUtility.FocusProjectWindow();

        Selection.activeObject = item;

        return item;
    }

    [MenuItem("Assets/Create/Add New Stackable Attribute")]
    public static ItemAttribute CreateItemStackAttrib()
    {
        ItemAttribute item = ScriptableObject.CreateInstance<StackableAttribute>();

        AssetDatabase.CreateAsset(item, "Assets/Inventory/stackAttrib.asset");
        AssetDatabase.SaveAssets();

        EditorUtility.FocusProjectWindow();

        Selection.activeObject = item;

        return item;
    }


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

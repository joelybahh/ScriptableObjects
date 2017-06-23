using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class InventoryEditor : EditorWindow {

    string myString = "Hello World";
    bool groupEnabled;
    bool dmgAttrib = false;
    bool stckAttrib = false;
    float myFloat = 1.23f;
    Inventory inv;

    List<SerializedObject> items;

    [MenuItem("Window/Inventory Manager")]
    public static void ShowWindow(){
        GetWindow(typeof(InventoryEditor), false, "Inventory Manager");
    }

    void OnEnable() {
    }

    void OnGUI() {
        GUILayout.Label("Item Creation Settings", EditorStyles.boldLabel);
        myString = EditorGUILayout.TextField("Item Name: ", myString);

        dmgAttrib = GUILayout.Toggle(dmgAttrib, "Add Damage Attribute");
        stckAttrib = GUILayout.Toggle(stckAttrib, "Add Stackable Attribute");

        if (GUILayout.Button("Add Item")) {
            Item createdItem = AddInventoryItem.CreateItemAsset(myString);

            if (dmgAttrib)
            {
                AddInventoryItem.CreateItemAttrib(eAttribTypes.DAMAGE, myString, ref createdItem);
            }
            if (stckAttrib)
            {
                AddInventoryItem.CreateItemAttrib(eAttribTypes.STACK, myString, ref createdItem);
            }
        }
    }
}


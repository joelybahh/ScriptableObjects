using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class InventoryEditor : EditorWindow {

    string myString = "Hello World";
    bool groupEnabled;

    bool objAttrib = false;
    bool imgAttrib = false;
    bool dmgAttrib = false;
    bool stckAttrib = false;

    float minDmg = 0.0f;
    float maxDmg = 0.0f;

    int maxStack = 1;
    Inventory inv;
    SerializedProperty obj;
    Object phys;

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

        //objAttrib = EditorGUILayout.BeginToggleGroup("Add Object Attribute", objAttrib);
        //EditorGUILayout.ObjectField("Gameobject", obj, );
        //EditorGUILayout.EndToggleGroup();

        dmgAttrib = EditorGUILayout.BeginToggleGroup("Add Damage Attribute", dmgAttrib);
        minDmg = EditorGUILayout.Slider("Min Damage", minDmg, 0, 100);
        maxDmg = EditorGUILayout.Slider("Max damage", maxDmg, minDmg, 200);
        EditorGUILayout.EndToggleGroup();
        
        stckAttrib = EditorGUILayout.BeginToggleGroup("Add Stackable Attribute", stckAttrib);
        maxStack = (int)EditorGUILayout.Slider("Max Stack", maxStack, 1, 100);
        EditorGUILayout.EndToggleGroup();

        if (GUILayout.Button("Add Item")) {
            Item createdItem = AddInventoryItem.CreateItemAsset(myString);

            if (dmgAttrib) {
                DamageAttribute da = (DamageAttribute)AddInventoryItem.CreateItemAttrib(eAttribTypes.DAMAGE, myString, ref createdItem);
                da.minDamage = minDmg;
                da.maxDamage = maxDmg;
            }
            if (stckAttrib) {
                StackableAttribute sa = (StackableAttribute)AddInventoryItem.CreateItemAttrib(eAttribTypes.STACK, myString, ref createdItem);
                sa.maxStack = maxStack;
            }
        }
    }
}


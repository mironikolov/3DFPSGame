using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class PrefabReplace : MonoBehaviour {
    public GameObject newPrefab;
    public string oldPrefabTag;
    public GameObject parentToNewObject;
    
    private GameObject[] oldPrefabs;
	
    public void prefabSwich() {
        oldPrefabs = GameObject.FindGameObjectsWithTag(oldPrefabTag);
        foreach (var prefab in oldPrefabs)
        {
            Quaternion rotation = prefab.transform.rotation;
            Vector3 position = prefab.transform.position;
            GameObject newGameObject = Instantiate(newPrefab, position, rotation);
            newGameObject.transform.SetParent(parentToNewObject.transform);
            DestroyImmediate(prefab);
        }
    }
}
[CustomEditor(typeof(PrefabReplace))]
public class PrefabSwitchEditor : Editor
{
    /// <summary>Calls on drawing the GUI for the inspector.</summary>
    public override void OnInspectorGUI()
    {
        // Draw the default inspector.
        DrawDefaultInspector();

        // Grab a reference to the target script, so we can identify it as a 
        // PrefabSwitch, instead of a simple Object.
        PrefabReplace prefabSwitch = (PrefabReplace)target;

        // Create a Button for "Swap By Tag",
        if (GUILayout.Button("Swap By Tag"))
        {
            // if it is clicked, call the SwapAllByTag method from prefabSwitch.
            prefabSwitch.prefabSwich();
        }
    }
}

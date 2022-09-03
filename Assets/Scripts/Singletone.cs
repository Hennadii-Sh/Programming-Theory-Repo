using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singletone<T> : MonoBehaviour where T : Component
{
    private static T instance;

    public static T Instance
    {

        get
        {
            if (instance == null) // If instance field not set, then:
            {
                instance = FindObjectOfType<T>(); // Looking for Object of type T in the scene and assign it to the "instance"

                if (instance == null) // If there is no Objects of type T in the scene, then:
                {
                    var obj = new GameObject(); // Create new GameObject

                    // Make G.Object not shown in the Hierarchy, not saved to Scenes, and not unloaded by Resources.UnloadUnusedAssets:
                    obj.hideFlags = HideFlags.HideAndDontSave; 

                    obj.AddComponent<T>(); // Add component T to created object
                }
            }

            return instance;
        }


        set => instance = value;
    }
}

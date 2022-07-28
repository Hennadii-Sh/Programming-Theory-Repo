using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainManager : MonoBehaviour
{
    public Material shapeMaterial;
    public Texture2D[] shapeTextures;
    public GameObject shapeObject;
    public bool isNewShapeCreated;

    public static MainManager Instance;

    private void Awake()
    {
        if (Instance != null)
            Destroy(gameObject);
        else Instance = this;
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GeometricShape : MonoBehaviour
{
    public GameObject spawnPointObj;
    public Transform spawnPointTr;
    [SerializeField] protected MainManager mainManager;
    protected GameObject shapeObj;

    protected virtual float StartingYAngle { get; set; } = 0;


    // DOES I NEED THIS ????
    private float volume;
    public virtual float Volume { get => volume; set => volume = value; }
    private float area;
    public virtual float Area { get => area; set => area = value; }
    //---------------------------------------------

    public abstract float VolumeCalculation();
    public abstract float AreaCalculation();



    public void DestroySpawnPointChildren()
    {
        foreach (Transform child in spawnPointTr)
        {
            Destroy(child.gameObject);
        }
    }
    public abstract void CreateNewShape();
    public void InstantiateNewShape()
    {
        DestroySpawnPointChildren();
        CreateNewShape();
        shapeObj.AddComponent<ObjectController>();
        SetShapeMaterial();
        shapeObj.transform.Rotate(transform.up, StartingYAngle);
    }
    
    public bool IsFloat(string value)
    {
        float f;
        return float.TryParse(value, out f);
    }

    public void SetShapeMaterial()
    {
        Renderer rend = shapeObj.GetComponent<Renderer>();
        rend.material = mainManager.shapeMaterial;


        //This works to:
        //rend.material.SetTexture("_MainTex", mainManager.selectedTexture);   //Instantiate instance of Default-material on object and set it texture to selected
        //MeshRenderer meshrend = shapeObj.GetComponent<MeshRenderer>();
        //meshrend.material = mainManager.shapeMaterial;  //Do the same as "rend.material = mainManager.shapeMaterial;"
    }

    private void Awake()
    {
        spawnPointObj = GameObject.Find("Spawn Point");
        spawnPointTr = spawnPointObj.GetComponent<Transform>();
        mainManager = GameObject.Find("Main Manager").GetComponent<MainManager>();
    }
}

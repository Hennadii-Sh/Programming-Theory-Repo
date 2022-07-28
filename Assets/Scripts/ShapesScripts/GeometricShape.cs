using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GeometricShape : MonoBehaviour
{
    public GameObject spawnPointObj;
    public Transform spawnPointTr;
    protected DataSetPanelController dataSetPanelController;
    protected GameObject shapeObj;

    protected abstract float StartingYAngle { get; set; }

    private List<string> propertieName = new List<string>();

    // DOES I NEED THIS ????
    private float volume;
    public virtual float Volume { get => volume; set => volume = value; }
    private float area;
    public virtual float Area { get => area; set => area = value; }
    //---------------------------------------------

    public abstract float VolumeCalculation();
    public abstract float AreaCalculation();

    public virtual void SendPropertiesNames()
    {
        dataSetPanelController.propertieName = new List<string>(propertieName);
    }

    private void DestroySpawnPointChildren()
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
        ClearDataSetPanel();
        CreateNewShape();
        SendPropertiesNames();

        MainManager.Instance.isNewShapeCreated = true;
        MainManager.Instance.shapeObject = shapeObj;
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
        rend.material = MainManager.Instance.shapeMaterial;

        //This works to:
        //rend.material.mainTexture = MainManager.Instance.shapeTextures[1];   //Create instance of object applied material and set it texture to selected
        //rend.material.SetTexture("_MainTex", shapeTextures[1]);   //(Same) Create instance of object applied material and set it texture to selected
        //MeshRenderer meshrend = shapeObj.GetComponent<MeshRenderer>();  //Do the same as "rend.material = MainManager.Instance.shapeMaterial;"
        //meshrend.material = MainManager.Instance.shapeMaterial;
    }

    protected virtual void Awake()
    {
        spawnPointObj = GameObject.Find("Spawn Point");
        spawnPointTr = spawnPointObj.GetComponent<Transform>();
        dataSetPanelController = GameObject.Find("DataSet Panel").GetComponent<DataSetPanelController>();
    }




    private void ClearDataSetPanel()
    {
        Transform transform = dataSetPanelController.gameObject.transform;
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject, 0);
        }
    }
}

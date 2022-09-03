using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereScript : GeometricShape
{
    private List<string> propertieName = new List<string>() { "Volume", "Area", "Radius", "Diameter" };


    private float radius = 1;
    public float Radius { get; set; }
    private float diameter = 1;
    public float Diameter { get; set; }


    protected override float StartingYAngle { get; set; } = 0;

    //--------------------------------------------------------------------------------------------------------------------------

    public override void SendPropertiesNames()
    {
        dataSetPanelController.lineOfDataName = new List<string>(propertieName);
    }

    public override void CreateNewShape()
    {
        shapeObj = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        shapeObj.transform.position = spawnPointTr.position;
        shapeObj.transform.SetParent(spawnPointTr);

        shapeObj.AddComponent<SphereCalculation>();
    }
    public void InstantiateSphere()
    {
        InstantiateNewShape();
    }


}

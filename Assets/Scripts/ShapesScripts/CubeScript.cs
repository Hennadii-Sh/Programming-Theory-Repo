using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeScript : GeometricShape
{
    private List<string> propertieName = new List<string>() { "Volume", "Area", "Edge" };

   
    private float side = 1;
    public float Side { get; set; }

    protected override float StartingYAngle { get; set; } = 0;

    //--------------------------------------------------------------------------------------------------------------------------



    public override void SendPropertiesNames()
    {
        dataSetPanelController.lineOfDataName = new List<string>(propertieName);
    }

    public override void CreateNewShape()
    {
        shapeObj = GameObject.CreatePrimitive(PrimitiveType.Cube);
        shapeObj.transform.position = spawnPointTr.position;
        shapeObj.transform.SetParent(spawnPointTr);

        StartingYAngle = 45;
    }
    public void InstantiateCube()
    {
        InstantiateNewShape();
    }

}

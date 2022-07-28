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

    public override void SendPropertiesNames()
    {
        dataSetPanelController.propertieName = new List<string>(propertieName);
    }

    public override void CreateNewShape()
    {
        shapeObj = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        shapeObj.transform.position = spawnPointTr.position;
        shapeObj.transform.SetParent(spawnPointTr);
    }
    public void InstantiateSphere()
    {
        InstantiateNewShape();
    }


    // Calculation methods!!!
    public override float AreaCalculation()
    {
        float area = 4 * Mathf.PI * radius;
        return area;
    }
    public override float VolumeCalculation()
    {
        float volume = 4 / 3 * Mathf.PI * Mathf.Pow(radius, 3);
        return volume;
    }
    public float DiameterFromRadiusCalculation()
    {
        diameter = radius * 2;
        return diameter;
    }
    public float RadiusFromDiameterCalculation()
    {
        radius = diameter / 2;
        return radius;
    }
    public float RadiusFromVolumeCalculation()
    {
        radius = Mathf.Sqrt(Volume / Mathf.PI);     // !!!!!!!!!!!!!!!!!!!!!!!!!!!! Maybe chose another variable for Area??
        return radius;
    }
    public float RadiusFromAreaCalculation()
    {
        radius = Area / 2 * Mathf.PI;     // !!!!!!!!!!!!!!!!!!!!!!!!!!!! Maybe chose another variable for Area??
        return radius;
    }

}

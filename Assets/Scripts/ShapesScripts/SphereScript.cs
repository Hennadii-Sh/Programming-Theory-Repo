using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereScript : GeometricShape
{
    private float radius = 1;
    public float Radius { get; set; }
    protected override float StartingYAngle { get; set; } = 0;
    public override int FigurePropertiesQuantity { get; set; } = 4;

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
}

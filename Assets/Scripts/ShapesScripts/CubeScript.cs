using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeScript : GeometricShape
{
    private float side = 1;
    public float Side { get; set; }
    protected override float StartingYAngle { get; set; } = 45;


    public override void CreateNewShape()
    {
        shapeObj = GameObject.CreatePrimitive(PrimitiveType.Cube);
        shapeObj.transform.position = spawnPointTr.position;
        shapeObj.transform.SetParent(spawnPointTr);
    }

    public override float AreaCalculation()
    {
        float area = 6 * side * side;
        return area;
    }
    public override float VolumeCalculation()
    {
        float volume = side * side * side;
        return volume;
    }
}

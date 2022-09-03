using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICalculate
{
    public void InitializeDataPanel();
    public void ChangeCalculationData(int index, float data);
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class SphereCalculation : MonoBehaviour, ICalculate
{
    [SerializeField] private GameObject dataSetPanel;
    [SerializeField]  private List<GameObject> dataLineObj = new List<GameObject>();

    // List of calculable variables:
    [SerializeField] private float volume;
    [SerializeField] private float area;
    [SerializeField] private float radius;
    [SerializeField] private float diameter;
    [SerializeField] private List<float> dataList = new List<float>();

    [SerializeField] private bool isEnoughData = false;  // not used any more, was used in commented section
    //----------------------------------------------------------------------------------------------


    //This method called if new shape created and menu switched to calculation panel.
    public void InitializeDataPanel()
    {
        dataSetPanel = GameObject.Find("DataSet Panel");

        dataLineObj.Clear();
        FillListOfDataLines();
    }


    private void FillListOfDataLines()
    {
        foreach (Transform child in dataSetPanel.transform)
        {
            if (child.CompareTag("LineOfData"))
            {
                dataLineObj.Add(child.gameObject);
            }
        }
    }

    public void ChangeCalculationData(int index, float data)
    {
        DoCalculations(index, data);

        SendDataToUI();
    }

    private void DoCalculations(int index, float data)
    {
        switch (index)
        {
            case 0:
                volume = data;

                RadiusFromVolumeCalculation();
                AreaCalculation();
                DiameterFromRadiusCalculation();
                break;

            case 1:
                area = data;

                RadiusFromAreaCalculation();
                VolumeCalculation();
                DiameterFromRadiusCalculation();
                break;

            case 2:
                radius = data;

                VolumeCalculation();
                AreaCalculation();
                DiameterFromRadiusCalculation();
                break;

            case 3:
                diameter = data;

                RadiusFromDiameterCalculation();
                VolumeCalculation();
                AreaCalculation();
                break;

            default:
                break;
        }
        UpdateDataList();

    }

    private void UpdateDataList()
    {
        dataList.Clear();
        dataList.Add(volume);
        dataList.Add(area);
        dataList.Add(radius);
        dataList.Add(diameter);
    }

    private void SendDataToUI()
    {
        for (int i = 0; i < dataLineObj.Count; i++)
        {
            Transform inputFieldTr = dataLineObj[i].transform.Find("InputField");
            TMP_InputField inputField = inputFieldTr.gameObject.GetComponent<TMP_InputField>();
            inputField.text = dataList[i].ToString();
        } 
    }

    // Calculation methods!!!
    public float AreaCalculation()
    {
        float area = 4 * Mathf.PI * radius;
        return area;
    }
    public float VolumeCalculation()
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
        radius = Mathf.Sqrt(volume / Mathf.PI);
        return radius;
    }
    public float RadiusFromAreaCalculation()
    {
        radius = area / 2 * Mathf.PI;
        return radius;
    }
}

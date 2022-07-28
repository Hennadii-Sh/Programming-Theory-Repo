using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DataSetPanelController : MonoBehaviour
{
    public List<string> propertieName = new List<string>();
    public List<GameObject> LinesOfDataObj = new List<GameObject>();

    [SerializeField] private GameObject lineOfdDataPanel;



    public void StartNewCalculations()
    {
        AddLinesOfDataToDataSetPanel(propertieName.Count);

        LinesOfDataObj.Clear();
        GetLinesOfDataObjList();

        SetNamesToLinesOfData(LinesOfDataObj, propertieName);
        //++++++++Add another function and/or entry to further calculations
    }

    public void AddLinesOfDataToDataSetPanel(int quantity)
    {
        for (int i = 0; i < quantity; i++)
        {
            GameObject newLine = Instantiate(lineOfdDataPanel, gameObject.transform, false);
            float lineHeight = 60;
            if (i > 0)
            {
                newLine.transform.Translate(Vector3.down * lineHeight * i);
            }
        }
    }

    private void GetLinesOfDataObjList()
    {
        LinesOfDataObj.Clear();

        foreach (Transform child in gameObject.transform)
        {
            LinesOfDataObj.Add(child.gameObject);
        }
    }
    private void SetNamesToLinesOfData(List<GameObject> ListToSetNames, List<string> ListOfNames)
    {
        for (int i = 0; i < ListToSetNames.Count; i++)
        {
            NamingLinesOfData(ListToSetNames[i], ListOfNames[i]);
        }
    }
    private void NamingLinesOfData(GameObject lineOfDataObj, string name)
    {
        Transform dataLineNameTr = lineOfDataObj.transform.Find("Text");
        TextMeshProUGUI dataLineName = dataLineNameTr.gameObject.GetComponent<TextMeshProUGUI>();
        dataLineName.text = name;
    }

}

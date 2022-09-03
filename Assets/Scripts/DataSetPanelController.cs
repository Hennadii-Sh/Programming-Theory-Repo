using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DataSetPanelController : MonoBehaviour
{
    public List<string> lineOfDataName = new List<string>();
    public List<GameObject> linesOfDataObj = new List<GameObject>();

    [SerializeField] private GameObject lineOfdDataPrefab;
    [SerializeField] private GameObject calculateButton;  // // DELETE ????????????????????????????????????????????????
    private float lineHeight = 60;

    //--------------------------------------------------------------------------------------------------------------------------

    public void CreateNewDataSetPanel()
    {
        AddLinesOfDataToDataSetPanel(lineOfDataName.Count);
        //AddCalculateButton(lineOfDataName.Count);    // DELETE ????????????????????????????????????????????????

        linesOfDataObj.Clear();
        GetLinesOfDataObjList();

        SetNamesToLinesOfData(linesOfDataObj, lineOfDataName);
        //++++++++Add another function and/or entry to further calculations
    }

    // Methods, adding UI ELEMENTS !!
    public void AddLinesOfDataToDataSetPanel(int linesQuantity)
    {
        GameObject newLine;

        for (int i = 0; i < linesQuantity; i++)
        {
            newLine = Instantiate(lineOfdDataPrefab, gameObject.transform, false);

            Transform newLineTr = newLine.transform.Find("InputField");
            newLineTr.gameObject.GetComponent<ValueFieldController>().FieldIndex = i;  //Set index to new input field!!

            //Position new line on panel, depending on index:
            if (i > 0)
            {
                newLine.transform.Translate(Vector3.down * lineHeight * i);
            }
        }
    }
  
    //public void AddCalculateButton(int linesQuantity)   // DELETE ????????????????????????????????????????????????
    //{
    //    GameObject newCalculateButton = Instantiate(calculateButton, gameObject.transform, false);
    //    newCalculateButton.transform.Translate(Vector3.down * lineHeight * linesQuantity);

    //}
    // END


    // Methods, NAMING lines of data in UI
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
    // END

    // Getting LineOfData objects to list
    private void GetLinesOfDataObjList()
    {
        linesOfDataObj.Clear();

        foreach (Transform child in gameObject.transform)
        {
            if (child.CompareTag("LineOfData"))
            {
                linesOfDataObj.Add(child.gameObject);
            }
        }
    }

}

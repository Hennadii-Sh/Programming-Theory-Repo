using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class ValueFieldController : MonoBehaviour
{
    [SerializeField] private TMP_InputField inputField;

    private string fieldText;
    private string FieldText { get => fieldText; set => fieldText = value; }

    private bool isFieldTextFloatValue;
    public bool IsFieldTextFloatValue { get => isFieldTextFloatValue; private set => isFieldTextFloatValue = value; }

    private float fieldValue;
    public float FieldValue { get => fieldValue; private set => fieldValue = value; }

    private void Start()
    {
        FieldText = null;

        inputField.onValueChanged.AddListener(delegate { SetValue(); });
    }
    public void SetValue()
    {
        GetInputToString();

        IsValueFloat(FieldText);

        ConvertInputToFloat();
    }

    private void GetInputToString()
    {
        FieldText = inputField.text;
    }
    private void IsValueFloat(string value)
    {
        float f;
        IsFieldTextFloatValue = float.TryParse(value, out f);
    }

    private void ConvertInputToFloat()
    {
        if (IsFieldTextFloatValue)
        {
            FieldValue = float.Parse(FieldText);
        }
        if (!IsFieldTextFloatValue)
        {
            Debug.Log("PLEASE, INPUT CORRECT VALUE!");
        }
    }



    //private void CheckingValue()
    //{
    //    if (fieldTextString[fieldTextString.Length - 1] == ',')
    //    {
    //        fieldTextString = fieldTextString.Remove(fieldTextString.Length - 1, 1) + ".";
    //        inputField.text = fieldTextString;
    //    }

    //}
}

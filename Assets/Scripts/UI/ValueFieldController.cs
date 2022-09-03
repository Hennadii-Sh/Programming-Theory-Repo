using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Globalization;


public class ValueFieldController : MonoBehaviour
{
    [SerializeField] private TMP_InputField inputField;

    private string fieldText;
    private string FieldText { get => fieldText; set => fieldText = value; }

    private bool isFieldTextFloatType;
    public bool IsFieldTextFloatType { get => isFieldTextFloatType; private set => isFieldTextFloatType = value; }

    private float fieldValue;
    public float FieldValue { get => fieldValue; private set => fieldValue = value; }

    [SerializeField] private int fieldIndex;
    public int FieldIndex { get => fieldIndex; set => fieldIndex = value; }


    private string calculationScriptName;
    public string CalculationScriptName { get => calculationScriptName; set => calculationScriptName = value; }

    //--------------------------------------------------------------------------------------------------------------------------

    //IN START ADD LISTENER ON VALUE CHANGED
    private void Start()
    {
        FieldText = null;

        inputField.onValueChanged.AddListener(delegate { OnValueInput(); });

    }
  
    public void OnValueInput()
    {
        SetValue();
        SendDataToCalculationComponent();
    }

    private void SendDataToCalculationComponent()
    {
        MainManager.Instance.shapeObject.GetComponent<ICalculate>().ChangeCalculationData(fieldIndex, fieldValue);
    }



    //Get input, check is it float type, show error message or convert to float and save in proper variable. 
    private void SetValue()
    {
        GetInputToString();

        IsValueFloatType(FieldText);

        ConvertInputToFloat();
        //Debug.Log("Field value: " + FieldValue);

        ShowErrorOnIncorrectInput();
    }

    // Methods, getting input, checking is it float type and saving it to float type variable!!
    private void GetInputToString()   // Save input to string variable
    {
        FieldText = inputField.text;
    }
    private void IsValueFloatType(string value)    // Checking is it float type
    {
        float f;
        IsFieldTextFloatType = float.TryParse(value, NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture, out f); //!! Принимает ТОЛЬКО ТОЧКУ как разделитель

        //IsFieldTextFloatValue = float.TryParse(value, out f);  // Принимает ТОЛЬКО запятую как разделитель, зависит от МЕСТНОГО ФОРМАТА ???
    }
 
    private void ConvertInputToFloat()    //Convert and save to float variable
    {
        if (IsFieldTextFloatType)
        {
            FieldValue = float.Parse(FieldText, NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture.NumberFormat); //!! Принимает ТОЛЬКО ТОЧКУ как разделитель

            //FieldValue = float.Parse(FieldText, CultureInfo.InvariantCulture.NumberFormat); // Принимает ТОЛЬКО ТОЧКУ как разделитель, зависит от МЕСТНОГО ФОРМАТА ???
            //FieldValue = float.Parse(FieldText, NumberStyles.Any, CultureInfo.InvariantCulture.NumberFormat); // Принимает ТОЛЬКО запятую как разделитель, зависит от МЕСТНОГО ФОРМАТА ???
        }
    }
    
    private void ShowErrorOnIncorrectInput() // Show error vessage on incorretct input
    {
        if (!IsFieldTextFloatType)
        {
            MenuController.Instance.ShowInputErrorMessage();
        }
    }  
    // END



}

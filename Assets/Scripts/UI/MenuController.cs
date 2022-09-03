using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    [SerializeField] private Button selectShapeButton;
    [SerializeField] private Button backToCalculationsButton;
    [SerializeField] private Button badInputErrorOkButton;
   
    [SerializeField] private GameObject shapeSelectionPanel;
    [SerializeField] private GameObject calculationsPanel;
    [SerializeField] private GameObject badInputErrorPanel;

    [SerializeField] private DataSetPanelController dataSetPanelController;

    public static MenuController Instance;

    //--------------------------------------------------------------------------------------------------------------------------

    private void Awake()
    {
        if (Instance != null)
            Destroy(gameObject);
        else Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        //Add listeners to selected buttons!
        selectShapeButton.onClick.AddListener(SwitchToShapeSelectionPanel);
        backToCalculationsButton.onClick.AddListener(SwitchToCalculationPanel);
        badInputErrorOkButton.onClick.AddListener(HideInputErrorMessage);
    }

    public void HideInputErrorMessage()
    {
        badInputErrorPanel.SetActive(false);
    }

    public void ShowInputErrorMessage()
    {
        badInputErrorPanel.SetActive(true);
    }

    public void SwitchToShapeSelectionPanel()
    {
        shapeSelectionPanel.SetActive(true);
        calculationsPanel.SetActive(false);
    }
    public void SwitchToCalculationPanel()
    {
        shapeSelectionPanel.SetActive(false);
        calculationsPanel.SetActive(true);
        if (MainManager.Instance.isNewShapeCreated)
        {
            dataSetPanelController.CreateNewDataSetPanel();
            MainManager.Instance.shapeObject.GetComponent<ICalculate>().InitializeDataPanel();
            MainManager.Instance.isNewShapeCreated = false;
        }
    }

}

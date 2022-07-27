using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    [SerializeField] private Button selectShapeButton;
    [SerializeField] private Button backToCalculationsButton;
    [SerializeField] private GameObject shapeSelectionPanel;
    [SerializeField] private GameObject calculationsPanel;
    [SerializeField] private GameObject lineOfdDataPanel;
    [SerializeField] private GameObject dataSetPanel;

    public static MenuController Instance;


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
            FillDataPanel(MainManager.Instance.FigurePropertiesQuantity);
            MainManager.Instance.isNewShapeCreated = false;
        }
    }


    private void ClearDataSetPanel()
    {
        foreach (Transform child in dataSetPanel.transform)
        {
            Destroy(child.gameObject);
        }
    }
    public void AddLinesOfDataToDataSetPanel(int quantity)
    {
        for (int i = 0; i < quantity; i++)
        {
            GameObject newLine = Instantiate(lineOfdDataPanel, dataSetPanel.transform, false);
            float lineHeight = 60;
            if (i > 0)
            {
                newLine.transform.Translate(Vector3.down * lineHeight * i);
            }
        }
    }

    public void FillDataPanel(int quantity)
    {
        ClearDataSetPanel();
        AddLinesOfDataToDataSetPanel(quantity);
    }
}

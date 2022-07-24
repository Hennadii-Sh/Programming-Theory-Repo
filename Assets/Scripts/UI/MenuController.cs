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

    public void SwitchToShapeSelectionPanel()
    {
        shapeSelectionPanel.SetActive(true);
        calculationsPanel.SetActive(false);
    }
    public void SwitchToCalculationPanel()
    {
        shapeSelectionPanel.SetActive(false);
        calculationsPanel.SetActive(true);
    }
    // Start is called before the first frame update

    public static MenuController Instance;

    private void Awake()
    {
        if (Instance != null)
            Destroy(gameObject);
        else Instance = this;
    }

    void Start()
    {
        selectShapeButton.onClick.AddListener(SwitchToShapeSelectionPanel);
        backToCalculationsButton.onClick.AddListener(SwitchToCalculationPanel);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

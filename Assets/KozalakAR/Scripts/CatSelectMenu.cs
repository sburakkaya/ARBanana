using UnityEngine;
using UnityEngine.UI;

public class CatSelectMenu : MonoBehaviour
{
    
    [SerializeField] private GameObject[] vehicles;
    [SerializeField] private GameObject[] UImodels;
    [SerializeField] private GameObject catSelectPanel,controlPanel;
    [SerializeField] private Button leftButton;
    [SerializeField] private Button rightButton;
    [SerializeField] private Button okayButton;

    public int selectedVehicleIndex;
    
    public GameObject selectedVehicle;
    public bool isSelected;

    public static CatSelectMenu Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        Application.targetFrameRate = 120;
    }
    
    private void Start()
    {
        leftButton.onClick.AddListener(SelectPreviousVehicle);
        rightButton.onClick.AddListener(SelectNextVehicle);
        okayButton.onClick.AddListener(SelectVehicle);
    }

    public void SelectPreviousVehicle()
    {
        UImodels[selectedVehicleIndex].gameObject.SetActive(false);
        selectedVehicleIndex--;
        if (selectedVehicleIndex < 0)
        {
            selectedVehicleIndex = vehicles.Length - 1;
        }
        UImodels[selectedVehicleIndex].gameObject.SetActive(true);
    }

    public void SelectNextVehicle()
    {
        UImodels[selectedVehicleIndex].gameObject.SetActive(false);
        selectedVehicleIndex++;
        if (selectedVehicleIndex >= vehicles.Length)
        {
            selectedVehicleIndex = 0;
        }
        UImodels[selectedVehicleIndex].gameObject.SetActive(true);
    }

    public void SelectVehicle()
    {
        selectedVehicle = vehicles[selectedVehicleIndex];
        isSelected = true;
        UImodels[selectedVehicleIndex].gameObject.SetActive(false);
        controlPanel.SetActive(true);
        catSelectPanel.SetActive(false);
    }
}
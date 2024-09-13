using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour 
{
    [SerializeField] private Color normalTextColor = Color.blue;
    [SerializeField] private Color cantBuildTextColor = Color.blue;
    [SerializeField] private Color normalCanvasColor = Color.blue;
    [SerializeField] private Color cantBuildCanvasColor = Color.blue;
    [SerializeField] private GameObject buttonPrefab = null;

	private int numOfButtons;
	private bool[] canBuildTower;
	private Transform[] buttons;
	private SoulsCounter soulsCounter;
	private ScoreCounter scoreCounter;
	private BuildManager buildManager;
    private int indexOfThisTower;
    private GameObject gameMaster;
    private TowerManager towerManager;
    private ShopManager shopManager;

	public void PurcheseTower0()
    {
		indexOfThisTower = 0;
		if ( !soulsCounter.CanBuild (indexOfThisTower) )
			return;
		buildManager.SetTowerToBuildIndex (indexOfThisTower);
		buildManager.SetTowerToBuild (buildManager.tower[indexOfThisTower]);
		buildManager.SetSelectionTowerToBuild (buildManager.selectionTower [indexOfThisTower]);
        towerManager.TowerSelected();
    }

	public void PurcheseTower1()
    {
		indexOfThisTower = 1;
		if ( !soulsCounter.CanBuild (indexOfThisTower) )
			return;
		buildManager.SetTowerToBuildIndex (indexOfThisTower);
		buildManager.SetTowerToBuild (buildManager.tower[indexOfThisTower]);
		buildManager.SetSelectionTowerToBuild (buildManager.selectionTower [indexOfThisTower]);
        towerManager.TowerSelected();
    }

	public void PurcheseTower2()
    {
		indexOfThisTower = 2;
		if ( !soulsCounter.CanBuild (indexOfThisTower) )
			return;
		buildManager.SetTowerToBuildIndex (indexOfThisTower);
		buildManager.SetTowerToBuild (buildManager.tower[indexOfThisTower]);
		buildManager.SetSelectionTowerToBuild (buildManager.selectionTower [indexOfThisTower]);
        towerManager.TowerSelected();
    }

    public void PurcheseTower3()
    {
        indexOfThisTower = 3;

        if (!soulsCounter.CanBuild(indexOfThisTower))
            return;
        buildManager.SetTowerToBuildIndex(indexOfThisTower);
        buildManager.SetTowerToBuild(buildManager.tower[indexOfThisTower]);
        buildManager.SetSelectionTowerToBuild(buildManager.selectionTower[indexOfThisTower]);
        towerManager.TowerSelected();
    }

    public void PurcheseTower4()
    {
        indexOfThisTower = 4;
        if (!soulsCounter.CanBuild(indexOfThisTower))
            return;
        buildManager.SetTowerToBuildIndex(indexOfThisTower);
        buildManager.SetTowerToBuild(buildManager.tower[indexOfThisTower]);
        buildManager.SetSelectionTowerToBuild(buildManager.selectionTower[indexOfThisTower]);
        towerManager.TowerSelected();
    }

    public int GetTowerToBuildIndex()
    {
        return indexOfThisTower;
    }

	public bool CanBuildTower(int index)
    {
		return canBuildTower [index];
	}

	private void Awake(){
		numOfButtons = transform.childCount;
		SetTheShopButtons ();
		SetCanBuildTower ();
	}

	private void SetTheShopButtons()
    {
		buttons = new Transform[numOfButtons];
		for (int i = 0; i < numOfButtons; i++)
        {
			buttons [i] = transform.GetChild (i);
		}
	}

	private void SetCanBuildTower()
    {
		canBuildTower = new bool[numOfButtons];
		for (int i = 0; i < numOfButtons; i++)
        {
			canBuildTower [i] = false;
		}
	}

	private void Start()
    {
        gameMaster = GameObject.Find("GameMaster");
        buildManager = gameMaster.GetComponent<BuildManager> ();
		soulsCounter = gameMaster.GetComponent<SoulsCounter> ();
		scoreCounter = gameMaster.GetComponent<ScoreCounter> ();
        towerManager = gameMaster.GetComponent<TowerManager>();
        shopManager = gameMaster.GetComponent<ShopManager>();
	}

	private void Update()
    {
		UpdateCanBuildTower ();
	}

	private void UpdateCanBuildTower()
    {
		for (int i = 0 ; i < buildManager.tower.Length; i ++)
        {
            if ( !soulsCounter.CanBuild( buttons[i].GetComponent<ShopButton>().GetIndexOfThisTower() ))
            {
				canBuildTower [i] = false;
                buttons[i].GetComponentInChildren<PriceFinder>().
                          GetComponent<Text>().color = cantBuildTextColor;
                buttons[i].GetComponentInChildren<DescriptionCanvasFinder>().
                          GetComponent<Image>().color = cantBuildCanvasColor;
			} 
            else 
            {
				canBuildTower [i] = true;
                buttons[i].GetComponentInChildren<PriceFinder>().
                          GetComponent<Text>().color = normalTextColor;
                buttons[i].GetComponentInChildren<DescriptionCanvasFinder>().
                          GetComponent<Image>().color = normalCanvasColor;
			}
		}
	}
}

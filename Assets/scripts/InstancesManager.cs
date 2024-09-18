using UnityEngine;

public class InstancesManager : MonoBehaviour {

    [SerializeField] private GameObject shopGObj = null;
    [SerializeField] private GameObject masterTower = null;
    [SerializeField] private GameObject cameraPlayer = null;
    [SerializeField] private Mesh voxel4x4 = null;
    [SerializeField] private Mesh voxel3x3 = null;
    [SerializeField] private Mesh voxel2x2 = null;
    [SerializeField] private Mesh voxel1x1 = null;
	[SerializeField] private GameObject player = null;
    [SerializeField] private GameObject researchCanvas = null;
    [SerializeField] private GameObject normalBullet = null;
    [SerializeField] private GameObject deathEffect = null;
    [SerializeField] private GameObject lightningEffect = null;

    //private SearchCenterPlace researchTower = null;

    public GameObject GetShopGObj()
    {
		return shopGObj;
    }

    public GameObject GetMasterTowerObj()
    {
        return masterTower;
    }

    public GameObject GetCameraPlayer()
    {
        return cameraPlayer;
    }

    public Mesh GetVoxel4x4()
    {
        return voxel4x4;
    }

    public Mesh GetVoxel3x3()
    {
        return voxel3x3;
    }

    public Mesh GetVoxel2x2()
    {
        return voxel2x2;
    }

    public Mesh GetVoxel1x1()
    {
        return voxel1x1;
    }

	 public GameObject GetPlayerObj ()
    {
		    return player;
    }

    public GameObject GetResearchCanvas()
    {
        return researchCanvas;
    }
  
    public GameObject GetDeathEffect()
    {
        return deathEffect;
    }

    public GameObject GetLightningEffect()
    {
        return lightningEffect;
    }

    private void Start ()
    {
        normalBullet.GetComponent<SkillsProperties>().SetEffect(null);
	}
}

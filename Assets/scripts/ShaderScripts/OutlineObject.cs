using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OutlineObject : MonoBehaviour 
{
    [SerializeField] public Color GlowColor;
    public float FadeFactor = 5;

    private Renderer[] _renderers;
    private List<Material> _materials = new List<Material>();
    private Color _targetColor;
    private Color _relyColor = Color.black;
    private TowerScript masterTowerTowerScript;

    public Color _currentColor;

    #region Get and set method
    public Color GetCurrentColor ()
    {
        return _currentColor;
    }

    public Color GetGlowColor()
    {
        return GlowColor;
    }

    public void SetCurrentColor (Color _color)
    {
        _targetColor = _color;
        _relyColor = _color;
    }
    #endregion

    private void Start () 
    {
        _renderers = GetComponentsInChildren<Renderer>();

        foreach (Renderer renderer in _renderers)
        {
            _materials.AddRange(renderer.materials);
        }
        if (IsInCorrectScene() == false) return;
        masterTowerTowerScript = GameObject.FindWithTag("GameMaster").GetComponent<InstancesManager>().GetMasterTowerObj().GetComponent<TowerScript>();
    }

    private bool IsInCorrectScene()
    {
        return (SceneManager.GetActiveScene().buildIndex != 0 && string.Equals(SceneManager.GetActiveScene().name, "MainMenu") == false);
    }

    private void Update()
    {
        _currentColor = Color.Lerp(_currentColor, _targetColor, Time.deltaTime * FadeFactor);

        for (int i = 0; i < _materials.Count; i++)
        {
            _materials[i].SetColor("_glowColor", _currentColor);
        }

        if (_currentColor.Equals(_targetColor))
            enabled = false;
    }

    private void OnMouseEnter()
    {
        if (IsInCorrectScene() == false)
            return;
        _targetColor = GlowColor;
        enabled = true;
    }

    private void OnMouseExit()
    {
        _targetColor = _relyColor; 
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OutlineObject : MonoBehaviour 
{
    [SerializeField] public Color GlowColor;

    [SerializeField] public Color HaloColor;
    public float FadeFactor = 5;

    private Renderer[] _renderers;
    private List<Material> _materials = new List<Material>();
    private Color _targetColor;
    private Color _relyColor = Color.black;
    private TowerScript masterTowerTowerScript;

    private bool lockEnabled = false;
    private bool hovered = false;

    private bool highlighted = false;

    public Color _currentColor;

    #region Get and set method
    public Color GetCurrentColor ()
    {
        return _currentColor;
    }

    public Color GetGlowColor()
    {
        return highlighted ? HaloColor : GlowColor;
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

    public void lockEnable (bool locked = true) {
        lockEnabled = locked;
        enabled = true;
        if (!hovered) setState(lockEnabled);
    }

    public void setHighlight (bool state) {
        highlighted = state;
        if (hovered || lockEnabled) _targetColor = GetGlowColor();
    }

    private void setState(bool state) {
        enabled = true;
        _targetColor = state ? GetGlowColor() : _relyColor;
    }

    private void OnMouseEnter()
    {
        if (IsInCorrectScene() == false)
            return;
        hovered = true;
        setState(true);
    }

    private void OnMouseExit()
    {
        hovered = false;
        if (!lockEnabled) setState(false);
    }
}

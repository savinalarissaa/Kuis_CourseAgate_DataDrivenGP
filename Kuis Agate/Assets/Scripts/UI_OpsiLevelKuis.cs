using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UI_OpsiLevelKuis : MonoBehaviour
{
    public static event System.Action<int> EventSaatKlik;
    [SerializeField] private Button _tombolLevel = null;
    [SerializeField] private TextMeshProUGUI _levelname = null;
    [SerializeField] private LevelSoalKuis _levelKuis = null;
    

    private void Start()
    {
        if (_levelKuis != null)
            SetLevelKuis(_levelKuis, _levelKuis.levelPackIndex);
        _tombolLevel.onClick.AddListener(SaatKlik);
    }

    private void OnDestroy()
    {
        _tombolLevel.onClick.RemoveListener(SaatKlik);
    }

    public void SetLevelKuis(LevelSoalKuis levelPack, int index)
    {
        _levelname.text = levelPack.name;
        _levelKuis = levelPack;

        _levelKuis.levelPackIndex = index;
    }

    private void SaatKlik()
    {
        EventSaatKlik?.Invoke(_levelKuis.levelPackIndex);
    }
}

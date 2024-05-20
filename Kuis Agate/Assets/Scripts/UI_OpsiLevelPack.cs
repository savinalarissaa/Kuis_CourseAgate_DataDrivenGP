using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_OpsiLevelPack : MonoBehaviour
{
    public static event System.Action<LevelPackKuis> EventSaatKlik;
    [SerializeField] private TextMeshProUGUI _packName = null;
    [SerializeField] private LevelPackKuis _levelPack = null;
    [SerializeField] private Button _tombol = null;

    private void Start()
    {
        if (_levelPack != null)
            SetLevelPack(_levelPack);
        //subscribe event
        _tombol.onClick.AddListener(SaatKlik);
    }

    private void OnDestroy()
    {
        //Unsubscribe event
        _tombol.onClick.RemoveListener(SaatKlik);
    }

    public void SetLevelPack(LevelPackKuis levelPack)
    {
        _packName.text = levelPack.name;
        _levelPack = levelPack;
    }

    public void SaatKlik()
    {
        //Debug.Log("Tombol klik");
        EventSaatKlik?.Invoke(_levelPack);
    }
}

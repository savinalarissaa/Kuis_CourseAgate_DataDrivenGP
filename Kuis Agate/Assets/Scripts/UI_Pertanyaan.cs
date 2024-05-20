using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_Pertanyaan : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _tempatTeks = null;
    [SerializeField] private TextMeshProUGUI _tempatJudulLevel = null;
    [SerializeField] private Image _tempatGambar = null;

    void Start()
    {
        Debug.Log("Start");
    }

    public void SetPertanyaan(string teksJudulLevel, Sprite gambarHint, string teksPernyataan)
    {
        _tempatTeks.text = teksPernyataan;
        _tempatGambar.sprite = gambarHint;
        _tempatJudulLevel.text = teksJudulLevel;
    }
}

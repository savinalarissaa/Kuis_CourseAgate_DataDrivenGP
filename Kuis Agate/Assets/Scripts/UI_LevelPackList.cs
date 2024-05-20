using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_LevelPackList : MonoBehaviour
{
    [SerializeField] private InisialDataGameplay _inisialData = null;
    [SerializeField] private UI_LevelKuisLIst _levelList = null;
    [SerializeField] private UI_OpsiLevelPack _tombolLevelPack = null;
    [SerializeField] private RectTransform _content = null;
    [Space, SerializeField] private LevelPackKuis[] _levelPacks = new LevelPackKuis[0];

    private void Start()
    {
        LoadLevelPack();

        //if (_inisialData.SaatKalah) // kalau di un-comment tidak bisa??
        //{
        //    UI_OpsiLevelPack_EventSaatKlik(_inisialData.levelPack);
        //}

        //subscribe events
        UI_OpsiLevelPack.EventSaatKlik += UI_OpsiLevelPack_EventSaatKlik;
    }

    private void OnDestroy()
    {
        //unsubscribe events
        UI_OpsiLevelPack.EventSaatKlik -= UI_OpsiLevelPack_EventSaatKlik;
    }

    private void UI_OpsiLevelPack_EventSaatKlik(LevelPackKuis levelPack)
    {
        //buka menu levels
        _levelList.gameObject.SetActive(true);
        _levelList.UnloadLevelPack(levelPack);

        //tutup menu level packs
        gameObject.SetActive(false);

        _inisialData.levelPack = levelPack;
    }

    private void LoadLevelPack()
    {
        foreach (var Ip in _levelPacks)
        {
            var t = Instantiate(_tombolLevelPack);
            t.SetLevelPack(Ip);
            t.transform.SetParent(_content);
            t.transform.localScale = Vector3.one; //menormalisasi skala tombol
        }
    }
}

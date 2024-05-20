using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_LevelKuisLIst : MonoBehaviour
{
    [SerializeField] private InisialDataGameplay _inisialData = null;
    [SerializeField] private UI_OpsiLevelKuis _tombolLevel = null;
    [SerializeField] private RectTransform _content = null;
    [SerializeField] private LevelPackKuis _levelPack = null;
    [SerializeField] private GameSceneManager _gameSceneManager = null;
    [SerializeField] private string _gameplayScene = null;

    private void Start()
    {
        //subscribe events
        UI_OpsiLevelKuis.EventSaatKlik += UI_OpsiLevelPack_EventSaatKlik;
    }

    private void OnDestroy()
    {
        //unsubscribe events
        UI_OpsiLevelKuis.EventSaatKlik -= UI_OpsiLevelPack_EventSaatKlik;
    }

    private void UI_OpsiLevelPack_EventSaatKlik(int index)
    {
        _inisialData.levelIndex = index;
        _gameSceneManager.BukaScene(_gameplayScene);
    }

    public void UnloadLevelPack(LevelPackKuis levelPack)
    {
        HapusIsiKonten();
        _levelPack = levelPack;
        for (int i = 0; i < levelPack.BanyakLevel; i++) 
        {
            //membuat salinan prevab tombol level
            var t = Instantiate(_tombolLevel);
            t.SetLevelKuis(levelPack.AmbilLevelKe(i), i);

            //masukkan objek tombol sebagai anak objek "content"
            t.transform.SetParent(_content);
            t.transform.localScale = Vector3.one; //menormalisasi skala tombol
        }
    }

    private void HapusIsiKonten()
    {
        var cc = _content.childCount;

        for (int i = 0; i < cc; i++)
        {
            Destroy(_content.GetChild(i).gameObject);
        }
    }
}

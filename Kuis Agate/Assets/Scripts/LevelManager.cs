using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private InisialDataGameplay _inisialData = null;
    [SerializeField] private LevelPackKuis _soalSoal = null;
    [SerializeField] private PlayerProgress _playerProgress = null;
    [SerializeField] private UI_Pertanyaan _tempatPertanyaan = null;
    [SerializeField] private UI_PoinJawaban[] _tempatPilihanJawaban = new UI_PoinJawaban[0];
    
    private int _indexSoal = -1;

    [SerializeField] private GameSceneManager _gameSceneManager = null;
    [SerializeField] private string _namaScenePilihMenu = string.Empty;

    private void Start()
    {
        //if (!_playerProgress.MuatProgres())
        //{
        //    _playerProgress.SimpanProgres();            
        //}

        //_soalSoal = _inisialData.levelPack;
        _indexSoal = _inisialData.levelIndex - 1;

        NextLevel();
        //subscribe events
        UI_PoinJawaban.EventJawabSoal += UI_PoinJawaban_EventJawabSoal;
    }
    private void OnDestroy()
    {
        //Unsubscribe Events
        UI_PoinJawaban.EventJawabSoal -= UI_PoinJawaban_EventJawabSoal;
    }

    private void OnApplicationQuit()
    {
        _inisialData.SaatKalah = false;
    }

    private void UI_PoinJawaban_EventJawabSoal(string jawaban, bool adalahBenar)
    {
        if (adalahBenar)
        {
            _playerProgress.progresData.koin += 20;
        }
    }

    public void NextLevel()
    {
        _indexSoal++;

        if(_indexSoal >= _soalSoal.BanyakLevel)
        {
            //_indexSoal = 0;
            _gameSceneManager.BukaScene(_namaScenePilihMenu);
            return;
        }
           
        LevelSoalKuis soal = _soalSoal.AmbilLevelKe(_indexSoal );

        _tempatPertanyaan.SetPertanyaan($"Level {_indexSoal + 1}", soal.hint, soal.pertanyaan);

        for (int i = 0; i < _tempatPilihanJawaban.Length; i++)
        {
            UI_PoinJawaban poin = _tempatPilihanJawaban[i];
            LevelSoalKuis.OpsiJawaban opsi = soal.opsiJawaban[i];
            poin.SetPertanyaan(opsi.jawabanTeks, opsi.adalahBenar);
        }

        Debug.Log("Next Level, index : " + _indexSoal);
    }
}
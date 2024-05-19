using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private LevelPackKuis _soalSoal = null;
    [SerializeField] private PlayerProgress _playerProgress = null;
    [SerializeField] private UI_Pertanyaan _tempatPertanyaan = null;
    [SerializeField] private UI_PoinJawaban[] _tempatPilihanJawaban = new UI_PoinJawaban[0];
    
    private int _indexSoal = -1;

    private void Start()
    {
        if (!_playerProgress.MuatProgres())
        {
            _playerProgress.SimpanProgres();            
        }
        
        NextLevel();
    }

    public void NextLevel()
    {
        _indexSoal++;

        if(_indexSoal >= _soalSoal.BanyakLevel)
        {
            _indexSoal = 0;
        }
           
        LevelSoalKuis soal = _soalSoal.AmbilLevelKe(_indexSoal );

        _tempatPertanyaan.SetPertanyaan($"Level {_indexSoal + 1}", soal.hint, soal.pertanyaan);

        for (int i = 0; i < _tempatPilihanJawaban.Length; i++)
        {
            UI_PoinJawaban poin = _tempatPilihanJawaban[i];
            LevelSoalKuis.OpsiJawaban opsi = soal.opsiJawaban[i];
            poin.SetPertanyaan(opsi.jawabanTeks, opsi.adalahBenar);
        }
    }
}
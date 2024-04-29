using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [System.Serializable]

    private struct DataSoal
    {
        public Sprite hint;
        public string pertanyaan;
        public string judulLevel;

        public string[] jawabanTeks;
        public bool[] adalahBenar;
    }

    [SerializeField] private DataSoal[] _soalSoal = new DataSoal[0];
    [SerializeField] private UI_Pertanyaan _tempatPertanyaan = null;
    [SerializeField] private UI_PoinJawaban[] _tempatPilihanJawaban = new UI_PoinJawaban[0];
    private int _indexSoal = -1;

    private void Start()
    {
        NextLevel();
    }

    public void NextLevel()
    {
        _indexSoal++;

        if(_indexSoal >= _soalSoal.Length)
        {
            _indexSoal = 0;
        }

        DataSoal soal = _soalSoal[_indexSoal ];
        _tempatPertanyaan.SetPertanyaan(soal.pertanyaan, soal.hint, soal.judulLevel);

        for (int i = 0; i < _tempatPilihanJawaban.Length; i++)
        {
            UI_PoinJawaban poin = _tempatPilihanJawaban[i];
            poin.SetPertanyaan(soal.jawabanTeks[i], soal.adalahBenar[i]);
        }
    }
}

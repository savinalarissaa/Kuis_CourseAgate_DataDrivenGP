using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UI_PoinJawaban : MonoBehaviour
{
    [SerializeField] private UI_PesanLevel _tempatPesan = null;
    [SerializeField] private TextMeshProUGUI _teksJawaban = null;
    [SerializeField] bool _adalahBenar = false;

    public void PilihJawaban()
    {
        _tempatPesan.Pesan = $"Jawaban Anda adalah {_teksJawaban.text} ({_adalahBenar})";
    }

    public void SetPertanyaan(string teksJawaban, bool adalahBenar)
    {
        _teksJawaban.text = teksJawaban;
        _adalahBenar = adalahBenar;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Timer : MonoBehaviour
{
    [SerializeField] private float _waktuJawab = 38;
    [SerializeField] private Slider _timeBar = null;
    [SerializeField] private UI_PesanLevel _tempatPesan = null;

    private float sisaWaktu = 0;
    private bool waktuBerjalan = false;

    private void Start()
    {
        UlangiWaktu();
        waktuBerjalan = true;
    }

    private void Update()
    {
        if (!waktuBerjalan) return;

        sisaWaktu -= Time.deltaTime;
        _timeBar.value = sisaWaktu/_waktuJawab;

        if (sisaWaktu <= 0f)
        {
            _tempatPesan.Pesan = "Waktu Habis";
            _tempatPesan.gameObject.SetActive(true);
            Debug.Log("Waktu Habis");
            waktuBerjalan = false;
            return;
        }
    }
    public void UlangiWaktu()
    {
        sisaWaktu = _waktuJawab;
    }

    public bool WaktuBerjalan
    {
        get => waktuBerjalan;
        set => waktuBerjalan = value;
    }



}

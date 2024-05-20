using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;


[CreateAssetMenu(
    fileName = "Player Progress Baru",
    menuName = "Game Kuis/Player Progress")]

public class PlayerProgress : ScriptableObject
{
    [System.Serializable]
    public struct MainData
    {
        public int koin;
        public Dictionary<string, int> progresLevel;
    }

    [SerializeField] private string _fileName = "contoh.text";

    public MainData progresData = new MainData();

    public void SimpanProgres()
    {
        progresData.koin = 200;
        if (progresData.progresLevel == null)
            progresData.progresLevel = new();
        progresData.progresLevel.Add("Paket A", 3);
        progresData.progresLevel.Add("Paket B", 5);

        var directory = Application.dataPath + "/Temporary";
        var path =  directory + "/" + _fileName;

        if (!Directory.Exists(directory))
        {
            Directory.CreateDirectory(directory);
            Debug.Log("Directory created : " + directory);
        }

        if (!File.Exists(path))
        {
            File.Create(path).Dispose();
            Debug.Log("File Created: " + path);
        }

        //string kontenData = $"{progresData.koin}\n";
        
        var filestream = File.Open(path, FileMode.Open);
        filestream.Flush();

        /* Binary Formatter : lebih aman dan mudah drpada writer
        
        var formatter = new BinaryFormatter ();

        filestream.Flush(); 

        formatter.Serialize(filestream, progresData);*/

        /* Binary Writer:*/

        var writer = new BinaryWriter(filestream);

        writer.Write(progresData.koin);
        foreach (var i in progresData.progresLevel)
        {
            writer.Write(i.Key);
            writer.Write(i.Value);
        }

        writer.Dispose();
        filestream.Dispose();

        /*foreach (var i in progresData.progresLevel)
        {
            kontenData += $"{i.Key} {i.Value}\n";
        }

        File.WriteAllText(path, kontenData);*/

        Debug.Log("Data saved to file: " + path);
    }

    public bool MuatProgres()
    {
        var directory = Application.dataPath + "/Temporary";
        var path = directory + "/" + _fileName;
        
        var fileStream = File.Open(path, FileMode.OpenOrCreate);

        try
        {
            var reader = new BinaryReader(fileStream);

            try
            {
                progresData.koin = reader.ReadInt32();
                if (progresData.progresLevel == null)
                    progresData.progresLevel = new();
                while (reader.PeekChar() != -1)
                {
                    var namaLevelPack = reader.ReadString();
                    var levelKe = reader.ReadInt32();
                    progresData.progresLevel.Add(namaLevelPack, levelKe);
                    Debug.Log($"{namaLevelPack}; {levelKe}");
                }

                reader.Dispose();
            }
            catch (System.Exception e)
            {
                Debug.Log($"ERROR: Terjadi kesalahan saat memuat binari\n{e.Message}");
                reader.Dispose();
                fileStream.Dispose();
                return false;
            }

            //var formatter = new BinaryFormatter ();

            //progresData = (MainData)formatter.Deserialize(fileStream);

            fileStream.Dispose();

            Debug.Log($"{progresData.koin}; {progresData.progresLevel.Count}");

            return true;
        }
        catch (System.Exception e)
        {
            Debug.Log($"ERROR: Terjadi kesalahan saat memuat progres\n{e.Message}");

            return false;
        }
    }
}

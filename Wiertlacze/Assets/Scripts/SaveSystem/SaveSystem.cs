using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public static class SaveSystem
{
    private static readonly string Path = Application.persistentDataPath + "/game_save_1.save";

    private static bool _isLoadRequested = false;

    public static void RequestLoad()
    {
        _isLoadRequested = true;
    }

    public static bool HasSave()
    {
        return File.Exists(Path);
    }

    public static bool ShouldLoad()
    {
        return _isLoadRequested;
    }

    public static void Save(SaveData data)
    {
        var formatter = new BinaryFormatter();
        var stream = new FileStream(Path, FileMode.Create);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static SaveData Load()
    {
        _isLoadRequested = false;

        if (!File.Exists(Path))
        {
            Debug.LogError("Save file not found in" + Path);
            return null;
        }

        var formatter = new BinaryFormatter();
        var stream = new FileStream(Path, FileMode.Open);
        var data = formatter.Deserialize(stream) as SaveData;
        stream.Close();
        return data;
    }
}
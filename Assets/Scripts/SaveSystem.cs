using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem
{

    public static void SaveGame(Kernen_script kerne) {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/savedData.ker";
        FileStream stream = new FileStream(path, FileMode.Create);

        SaveData data = new SaveData(kerne);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static SaveData LoadGame() {
        string path = Application.persistentDataPath + "/savedData.ker";
        if (File.Exists(path)) {
            // file exists
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            SaveData data = formatter.Deserialize(stream) as SaveData;
            stream.Close();

            return data;
        }
        else {
            // file does not exist
            Debug.Log("NO SUCH FILE TO LOAD: " + path);
            return null;
        }
    }

}

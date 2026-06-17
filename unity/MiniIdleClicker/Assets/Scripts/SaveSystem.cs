using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace MiniIdleClicker
{
    public static class SaveSystem
    {
        private const string FileName = "mini-idle-clicker-save.json";

        public static string SavePath => Path.Combine(Application.persistentDataPath, FileName);

        public static void Save(GameSaveData data)
        {
            var json = JsonUtility.ToJson(data, prettyPrint: true);
            File.WriteAllText(SavePath, json);
        }

        public static GameSaveData Load()
        {
            if (!File.Exists(SavePath))
            {
                return null;
            }

            var json = File.ReadAllText(SavePath);
            return JsonUtility.FromJson<GameSaveData>(json);
        }
    }

    [Serializable]
    public sealed class GameSaveData
    {
        public int gold;
        public List<InventoryStack> inventory = new List<InventoryStack>();
        public string savedAtUtc = "";
    }
}

using UnityEngine;
using System;
namespace SaveSystemTutorial
//11
//22
{    
    public class PlayerData : MonoBehaviour
    {
        #region Fields
        
        [SerializeField] string playerName = "Player Name";
        [SerializeField] int level = 0;
        [SerializeField] int coin = 0;

        [Serializable]
        class SaveData
        {
            public string playerName;
            public int playerLevel;
            public int playerCoin;
            public Vector3 playerPosition;
        }

        const string PlAYER_DATA_KEY = "PlayerData";
        private const string PLAYER_DATA_FILE_NAME = "PayerData.sav";
        #endregion

        #region Properties

        public string Name => playerName;

        public int Level => level;
        public int Coin => coin;

        public Vector3 Position => transform.position;

        #endregion

        #region Save and Load

        public void Save()
        {
            //SaveByPlayerPrefs();
            SaveByJson();
        }

        public void Load()
        {
           // LoadFromPlayerPrefs();
           LoadFromJson();
        }

        #endregion


        #region PlayerPrefs
        void SaveByPlayerPrefs()
        {
            SaveData saveData= save();
            SaveSystem.SaveByPlayerPrefs(PlAYER_DATA_KEY,saveData);
        }

        
        void LoadFromPlayerPrefs()
        {
            var json = SaveSystem.LoadFromPlayerPrefs(PlAYER_DATA_KEY);
            load( JsonUtility.FromJson<SaveData>(json));
            
        }

        [UnityEditor.MenuItem("Developer/Delete Player Data Prefs")]
        public static void DeletePlayerDataPrefs()
        {
            PlayerPrefs.DeleteKey(PlAYER_DATA_KEY);
        }
        

        #endregion

        SaveData save()
        {
            var saveData = new SaveData();
            saveData.playerName = playerName;
            saveData.playerLevel = level;
            saveData.playerCoin = coin;
            saveData.playerPosition = transform.position;
            return saveData;
        }
      void load(SaveData saveData)
      {
          playerName = saveData.playerName;
          level = saveData.playerLevel;
          coin = saveData.playerCoin;
          transform.position = saveData.playerPosition;
      }
      
      
      void SaveByJson()
      {
          SaveSystem.SaveByJson(PLAYER_DATA_FILE_NAME,save());
         // SaveSystem.SaveByJson($"{System.DateTime.Now:MM-dd-yyyy HH-mm-ss}.sav",save());
      }

      void LoadFromJson()
      {
          SaveData saveData= SaveSystem.LoadFromJson<SaveData>(PLAYER_DATA_FILE_NAME);
          load(saveData);
      }
        [UnityEditor.MenuItem("Developer/Delete Player Data Save File")]
      public static void DeletePlayerDataSaveFile()
      {
          SaveSystem.DeleteSaveFile(PLAYER_DATA_FILE_NAME);
      }
    }
}
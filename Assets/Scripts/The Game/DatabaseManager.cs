using UnityEngine;
using Mono.Data.SqliteClient;
using System.Data;
using UnityEngine.UI;
using System;
using System.IO;
using System.Collections.Generic;

public class DatabaseManager : MonoBehaviour
{
    internal static DatabaseManager instance;

    /*public Text debug;
    public InputField input;

    public InputField input2;
    public InputField input3;*/

    private string wordsConnectionString;
    private string progressConnectionString;


    void Awake()
    {
        if (instance != null)
        {
            DestroyImmediate(this);
            return;
        }

        instance = this;
        Init();
    }

    private IDbConnection dbConnection;

    internal void Init()
    {
        wordsConnectionString = "URI=file:" + Application.streamingAssetsPath + "/words.db3";

        try
        {
            dbConnection = new SqliteConnection(wordsConnectionString);
            dbConnection.Open();
        }
        catch (Exception e)
        {
            print("WTF!");
//            debug.text = e + "";
        }
    }


    public bool IsCorrect(string word)
    {
        return true;
        try
        {
            using (IDbCommand cmd = dbConnection.CreateCommand())
            {
                string sqlQuery = "SELECT * FROM `words` WHERE `word`='" + word + "'";
                cmd.CommandText = sqlQuery;

                using (IDataReader reader = cmd.ExecuteReader())
                {
                    bool result = false;
                    while (reader.Read())
                    {
                        result = true;
                    }

                    return result;
                }
            }
        }
        catch (Exception e)
        {
            Debug.Log(e);
            return false;
        }
    }

    /*private void OnDestroy()
    {
        Dispose();
    }

    private void Dispose()
    {
        dbConnection.Close();
        dbConnection.Dispose();
    }*/
}

public class NoMoneyException : Exception
{
}
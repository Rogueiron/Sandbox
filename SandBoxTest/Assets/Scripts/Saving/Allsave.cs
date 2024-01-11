using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mono.Data.Sqlite;

public class Allsave : MonoBehaviour
{
    private string dbName = "URI=file:game.db";

    public void AllSave()
    {
        DeleteOld();
        NewSave();
        UnitSave();
        buildingSave();
    }

    public void UnitSave()
    {
        foreach (GameObject bots in GameObject.FindGameObjectsWithTag("Unit"))
        {
            bots.GetComponent<Stats>().OnSave();
        }
    }
    public void buildingSave()
    {
        foreach (GameObject building in GameObject.FindGameObjectsWithTag("Building"))
        {
            building.GetComponent<Stats>().OnSave();
        }
    }

    public void NewSave()
    {
        GameObject.FindGameObjectWithTag("Database").GetComponent<instDB>().CreateDB();

    }
    public void DeleteOld()
    {
        using var connection = new SqliteConnection(dbName);
        connection.Open();
        using var command = connection.CreateCommand();
        command.CommandText = "DROP TABLE IF EXISTS building;";
        command.ExecuteNonQuery();
        command.CommandText = "DROP TABLE IF EXISTS resorces;";
        command.ExecuteNonQuery();
        command.CommandText = "DROP TABLE IF EXISTS units;";
        command.ExecuteNonQuery();
        command.CommandText = "DROP TABLE IF EXISTS user;";
        command.ExecuteNonQuery();
        connection.Close();



    }
}

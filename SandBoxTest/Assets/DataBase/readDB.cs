using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Data;
using Mono.Data.Sqlite;

public class readDB : MonoBehaviour
{

    private string dbName = "URI=file:game.db";

    public void User()
    {
        using var connction = new SqliteConnection(dbName);
        connction.Open();
        using (var command = connction.CreateCommand())
        {
            command.CommandText = "SELECT * FROM User;";
            command.ExecuteNonQuery();
        }
        connction.Close();
    }
    public void Building()
    {
        using var connction = new SqliteConnection(dbName);
        connction.Open();
        using (var command = connction.CreateCommand())
        {
            command.CommandText = "SELECT * FROM Building;";
            command.ExecuteNonQuery();
        }
        connction.Close();

    }
    public void Resorces()
    {
        using var connction = new SqliteConnection(dbName);
        connction.Open();
        using (var command = connction.CreateCommand())
        {
            command.CommandText = "SELECT * FROM User;";
            command.ExecuteNonQuery();
        }
        connction.Close();
    }



}

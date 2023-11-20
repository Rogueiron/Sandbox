using UnityEngine;
using System.Data;
using Mono.Data.Sqlite;

public class instDB : MonoBehaviour
{
    private string dbName = "URI=file:game.db";
    
    // Start is called before the first frame update
    void Start()
    {
     CreateDB();
    }
    public void CreateDB()
    {

        using var connection = new SqliteConnection(dbName);
        connection.Open();
        using var command = connection.CreateCommand();
        command.CommandText = "CREATE TABLE IF NOT EXISTS user (UserID INTEGER NOT NULL UNIQUE, Name TEXT NOT NULL UNIQUE, PRIMARY KEY(UserID AUTOINCREMENT));";
        command.ExecuteNonQuery();
        command.CommandText = "CREATE TABLE IF NOT EXISTS resorce (name TEXT NOT NULL UNIQUE, Stored INTEGER NOT NULL);";
        command.ExecuteNonQuery();
        command.CommandText = "CREATE TABLE IF NOT EXISTS building (Id INTEGER NOT NULL UNIQUE, UserID INTEGER NOT NULL,  Name TEXT, type INTEGER NOT NULL, cost INTEGER NOT NULL, descripton  TEXT NOT NULL UNIQUE, PRIMARY KEY(id AUTOINCREMENT));";
        command.ExecuteNonQuery();
        command.CommandText = "CREATE TABLE IF NOT EXISTS units (Id INTEGER NOT NULL UNIQUE, HP INTEGER NOT NULL, DPS INTEGER, Description TEXT NOT NULL UNIQUE, Cost INTEGER NOT NULL UNIQUE, Name TEXT NOT NULL UNIQUE, Type INTEGER NOT NULL, xloc REAL, yloc REAL, CONSTRAINT id PRIMARY KEY(id AUTOINCREMENT));";
        command.ExecuteNonQuery();
        connection.Close();
    }
   
}

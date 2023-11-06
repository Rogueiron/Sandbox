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
        command.CommandText = "CREATE TABLE IF NOT EXISTS user (UserID INTEGER NOT NULL UNIQUE, PRIMARY KEY(UserID AUTOINCREMENT));";
        command.ExecuteNonQuery();
        command.CommandText = "CREATE TABLE IF NOT EXISTS resorce (name VARCHAR(20) NOT NULL UNIQUE, Stored INTEGER NOT NULL);";
        command.ExecuteNonQuery();
        command.CommandText = "CREATE TABLE IF NOT EXISTS building (Id INTEGER NOT NULL UNIQUE, UserID INTEGER NOT NULL,  Name VARCHAR(20), type INTEGER NOT NULL, cost INTEGER NOT NULL, descripton  VARCHAR(50) NOT NULL UNIQUE, PRIMARY KEY(id AUTOINCREMENT));";
        command.ExecuteNonQuery();
        command.CommandText = "CREATE TABLE IF NOT EXISTS units (Id INTEGER NOT NULL UNIQUE, HP INTEGER NOT NULL, DPS INTEGER, Description VARCHAR(20) NOT NULL UNIQUE, Cost INTEGER NOT NULL UNIQUE, Name VARCHAR(20) NOT NULL UNIQUE, Type INTEGER NOT NULL, xloc REAL, yloc REAL, CONSTRAINT id PRIMARY KEY(id AUTOINCREMENT));";
        command.ExecuteNonQuery();
        connection.Close();
    }
   
}

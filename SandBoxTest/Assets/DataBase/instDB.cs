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
        command.CommandText = "CREATE TABLE IF NOT EXISTS user (UserID INTEGER NOT NULL UNIQUE, name TEXT UNIQUE, xloc REAL, yloc REAL, zloc REAL, PRIMARY KEY(UserID AUTOINCREMENT));";
        command.ExecuteNonQuery();
        command.CommandText = "CREATE TABLE IF NOT EXISTS resorces (name VARCHAR(20) NOT NULL UNIQUE, Stored INTEGER NOT NULL);";
        command.ExecuteNonQuery();
        command.CommandText = "CREATE TABLE IF NOT EXISTS building (Id INTEGER NOT NULL UNIQUE, Name VARCHAR(20), xloc REAL, yloc REAL, zloc REAL, type INTEGER NOT NULL, PRIMARY KEY(id AUTOINCREMENT));";
        command.ExecuteNonQuery();
        command.CommandText = "CREATE TABLE IF NOT EXISTS units (Id INTEGER NOT NULL UNIQUE, Name VARCHAR(20) NOT NULL UNIQUE, xloc REAL, yloc REAL, zloc REAL, type INTEGER NOT NULL, CONSTRAINT id PRIMARY KEY(id AUTOINCREMENT));";
        command.ExecuteNonQuery();
        connection.Close();
    }
   
}

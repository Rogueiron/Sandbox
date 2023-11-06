using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Data;
using Mono.Data.Sqlite;

public class InsertToDB : MonoBehaviour
{
    private string dbName = "URI=file:game.db";


    public void User()
    {
        using var connction = new SqliteConnection(dbName);
        connction.Open();
        using (var command = connction.CreateCommand())
        {
            command.CommandText = "INSERT INTO User (UserID) VALUES (UserID INTEGER '0' );";
            command.ExecuteNonQuery();
        }
        connction.Close();
    }
    public void Unit()
    {
        using var connction = new SqliteConnection(dbName);
        connction.Open();
        using (var command = connction.CreateCommand())
        {
            command.CommandText = "INSERT INTO Unit (Id INTEGER NOT NULL UNIQUE, HP INTEGER NOT NULL, DPS INTEGER, Description VARCHAR(20) NOT NULL UNIQUE, Cost INTEGER NOT NULL UNIQUE, Name VARCHAR(20) NOT NULL UNIQUE, Type INTEGER NOT NULL, xloc REAL, yloc REAL, CONSTRAINT id PRIMARY KEY(id AUTOINCREMENT) VALUES ('0'));";
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
            command.CommandText = "INSERT INTO Building (Id INT NOT NULL UNIQUE, UserID INT NOT NULL,  Name VARCHAR(20), type INT NOT NULL, cost INT NOT NULL, descripton  VARCHAR(50) NOT NULL UNIQUE, PRIMARY KEY(id AUTOINCREMENT)') VALUES ('0');";
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
            command.CommandText = "INSERT INTO User (name VARCHAR(20) NOT NULL UNIQUE, Stored INT NOT NULL) VALUES ();";
            command.ExecuteNonQuery();
        }
        connction.Close();
    }
}

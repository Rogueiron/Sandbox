using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Data;
using Mono.Data.Sqlite;
using TMPro;
using static Storage;
using static Player;
using static OutlineBuild;

public class readDB : MonoBehaviour
{

    public TMP_InputField InputName;
    public UnitToMake unitToMake;
    private string dbName = "URI=file:game.db";

    public void User()
    {
        using var connction = new SqliteConnection(dbName);
        connction.Open();
        using (var command = connction.CreateCommand())
        {
            command.CommandText = "SELECT * FROM user WHERE name= '" + InputName.text + "';";
            command.ExecuteReader();

        }
        connction.Close();
    }
    public void Building()
    {
        using var connction = new SqliteConnection(dbName);
        connction.Open();
        using (var command = connction.CreateCommand())
        {
            command.CommandText = "SELECT * FROM building WHERE xloc='" + movePoint[0] + "' , yloc='" + movePoint[1] + "' , zloc='" + movePoint[2] + "';";
            command.ExecuteReader();
        }
        connction.Close();

    }
    public void Resorces()
    {
        using var connction = new SqliteConnection(dbName);
        connction.Open();
        using (var command = connction.CreateCommand())
        {
            command.CommandText = "SELECT * FROM resorces;";
            command.ExecuteReader();
        }
        connction.Close();
    } 
    public void Units()
    {
        using var connction = new SqliteConnection( dbName);
        connction.Open();
        using ( var command = connction.CreateCommand())
        {
            
            command.CommandText = "SELECT * FROM units WHERE xloc, yloc, zloc= '" + unitToMake.spawnLocation[0] + "' , '" + unitToMake.spawnLocation[1] + "' , '" + unitToMake.spawnLocation[2] + "';";
            command.ExecuteReader();
        }
        connction.Close();
    }



}

using UnityEngine;
using Mono.Data.Sqlite;
using TMPro;
using static Storage;
using static Player;
using static OutlineBuild;

public class InsertToDB : MonoBehaviour
{
   
    private string dbName = "URI=file:game.db";
    public TMP_InputField InputName;
    public UnitToMake unitToMake;

    // "','" + playerloc.x + "','" + playerloc.y + "','" + playerloc.z + "' 



    private string Randomname(int namelangth = 10)
    {
        int stringLength = namelangth - 1;
        string name = "";
        string[] characters = new string[] { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z" };
        for (int i = 0; i <= stringLength; i++)
        {
            name = name + characters[Random.Range(0, characters.Length)];
        }
        return name;
    }

        
        


    public void User()
    {
        using var connction = new SqliteConnection(dbName);
        connction.Open();
        if (InputName == null) 
        { 
        using (var command = connction.CreateCommand())
        {
                command.CommandText = "INSERT INTO User (xloc, yloc, zloc) VALUES ('" + position[0] + "' , '" + position[1] + "' , '" + position[2] + "' ); ";
                command.ExecuteNonQuery();
            }
        }   
        else
        {
            using (var command = connction.CreateCommand())
        {
                command.CommandText = "INSERT INTO User (name) VALUES ('" + InputName.text + "' ); ";
                command.ExecuteNonQuery();
            }
        }
        connction.Close();
    }
    public void Unit()
    {
        using var connction = new SqliteConnection(dbName);
        connction.Open();
        using (var command = connction.CreateCommand())
        {
           command.CommandText = "INSERT INTO Unit (Name, xloc, yloc, zloc ) VALUES ('" + name + "' , '" + unitToMake.spawnLocation[0] + "' , '" + unitToMake.spawnLocation[1] + "' , '" + unitToMake.spawnLocation[2] + "' ));";
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
            command.CommandText = "INSERT INTO Building (Id, Name, xloc, yloc, zloc )') VALUES ('" + name + "' , '" + movePoint[0] + "' , '" + movePoint[1] + "' , '" + movePoint[3] + "');";
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
            command.CommandText = "INSERT INTO resorces (Stored) VALUES ('" + WoodStorage + "') WHERE name == wood;";
            command.ExecuteNonQuery();
            command.CommandText = "INSERT INTO resorces (Stored) VALUES ('" + IronStorage + "') WHERE name == Iron;";
            command.ExecuteNonQuery();
            command.CommandText = "INSERT INTO resorces (Stored) VALUES ('" + CoalStorage + "') WHERE name == Coal;";
            command.ExecuteNonQuery();
            command.CommandText = "INSERT INTO resorces (Stored) VALUES (''" + PopCapStorage + "') WHERE name == MaxPopulation;";
            command.ExecuteNonQuery();
            command.CommandText = "INSERT INTO resorces (Stored) VALUES ('" + researchStorage + "')WHERE name == research;";
            command.ExecuteNonQuery();
        }
        connction.Close();
    }





}

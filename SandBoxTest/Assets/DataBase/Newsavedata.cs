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
        using (var command = connction.CreateCommand())
        {
                command.CommandText = "INSERT INTO User (name, xloc, yloc, zloc) VALUES ('" + InputName.text + "' , '" + position[0] + "' , '" + position[1] + "' , '" + position[2] + "' ); ";
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
            command.CommandText = "INSERT INTO Building ( Name, xloc, yloc, zloc ) VALUES ('" + name + "' , '" + movePoint[0] + "' , '" + movePoint[1] + "' , '" + movePoint[2] + "');";
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
            command.CommandText = "INSERT INTO resorces ( name, Stored ) VALUES ('wood'," + WoodStorage + ");";
            command.ExecuteNonQuery();
            command.CommandText = "INSERT INTO resorces ( name, Stored ) VALUES ('Iron'," + IronStorage + ");";
            command.ExecuteNonQuery();
            command.CommandText = "INSERT INTO resorces ( name, Stored ) VALUES ('Coal'," + CoalStorage + ");";
            command.ExecuteNonQuery();
            command.CommandText = "INSERT INTO resorces ( name, Stored ) VALUES ('maxpop'," + PopCapStorage + ");";
            command.ExecuteNonQuery();
            command.CommandText = "INSERT INTO resorces ( name, Stored ) VALUES ('research'," + researchStorage + ");";
            command.ExecuteNonQuery();
        }
        connction.Close();
    }





}

using UnityEngine;
using Mono.Data.Sqlite;
using TMPro;
using System.IO;
using static Storage;
using static Player;
using static OutlineBuild;
using System.Data;


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
            command.CommandText = "INSERT INTO user (name, xloc, yloc, zloc) VALUES ('" + InputName.text + "' , '" + position[0] + "' , '" + position[1] + "' , '" + position[2] + "');";
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
            foreach(var unit in GameObject.FindGameObjectsWithTag("Unit"))
            {
                command.CommandText = "INSERT INTO unit (Name, xloc, yloc, zloc ) VALUES ('" + Randomname() + "' , '" + unit.transform.position.x + "' , '" + unit.transform.position.y + "' , '" + unit.transform.position.z + "' );";
                command.ExecuteNonQuery();

            }
           
        }
        connction.Close();
    }

    public void Building()
    {
        using var connction = new SqliteConnection(dbName);
        connction.Open();
        using (var command = connction.CreateCommand())
        {
            command.CommandText = "INSERT INTO building ( Name, xloc, yloc, zloc ) VALUES ('" + Randomname() + "' , '" + movePoint[0] + "' , '" + movePoint[1] + "' , '" + movePoint[2] + "');";
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
    public void DBupdate()

    {
        using var connction = new SqliteConnection(dbName);
        connction.Open();
        using (var command = connction.CreateCommand())
        {
           
               
                command.CommandText = "UPDATE resorces SET Stored=" + WoodStorage + " WHERE ROWID = 1;";
                command.ExecuteNonQuery();
                command.CommandText = "UPDATE resorces SET Stored=" + IronStorage + "' WHERE name=Iron;";
                command.ExecuteNonQuery();
                command.CommandText = "UPDATE resorces SET Stored=" + CoalStorage + "' WHERE name=Coal;";
                command.ExecuteNonQuery();
                command.CommandText = "UPDATE resorces SET Stored=" + PopCapStorage + "' WHERE name=maxpop;";
                command.ExecuteNonQuery();
                command.CommandText = "UPDATE resorces SET Stored='" + researchStorage + "' WHERE name=research;";
                command.ExecuteNonQuery();
            //foreach (var unit in GameObject.FindGameObjectsWithTag("Unit"))
            //{
                //command.CommandText = "UPDATE unit SET (xloc= '" + unit.transform.position.x + "', yloc='" + unit.transform.position.y + "', zloc='" + unit.transform.position.z + "'WHERE name='" + InputName.text + ")';";
              // command.ExecuteNonQuery();
            //}
            command.CommandText = "UPDATE building SET (xloc= '" + movePoint[0] + "', yloc='" + movePoint[1] + "', zloc='" + movePoint[2] + "');";
            command.ExecuteNonQuery();

        }
            
        

    }

}

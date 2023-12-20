using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Mono.Data.Sqlite;
using System.Data;
using System.Xml.Linq;

public class Buttons : MonoBehaviour
{
    private string dbName = "URI=file:game.db";
    public void startonClick()
    {
        SceneManager.LoadScene("Game");
    }
    public void newsaveonClick()
    {
        SceneManager.LoadScene("newSave");
        using var connction = new SqliteConnection(dbName);
        connction.Open();
        using (var command = connction.CreateCommand())
        {
            command.CommandText = "DROP DATABASE " + dbName + ";";
            command.ExecuteNonQuery();
        }


    }
    public void Quit()
    {
        Application.Quit();
    }
    public void menuonClick()
    {
        SceneManager.LoadScene("MainMenu"); 
    }
}

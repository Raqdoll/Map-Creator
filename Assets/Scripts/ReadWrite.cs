using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;
using System;
using UnityEngine.UI;

public class ReadWrite : MonoBehaviour
{
    //Handles the reading and writing to the text files

    string path;
    public string fileName = "NewMap"; //Default
    string saveFilePath;
    public InputField nameIF;
    public InputField IDIF;
    MapController mc;

    void Start()
    {
        mc = GetComponent<MapController>();
        path = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "/SA_Maps";
        saveFilePath = path + "/" + fileName + ".txt";
    }
    public void CreatePath()
    {        
        CheckFolderPath();

        ReadNameAndID();

        CreateSaveFile();
    }
    void ReadNameAndID()
    {
        //Update names from text fields
        Debug.Log(nameIF.text + "_" + IDIF.text);
        if (nameIF.text != "" || IDIF.text != "")
        {
            Debug.Log("Fields are not empty");
            fileName = nameIF.text + "_" + IDIF.text;
            saveFilePath = path + "/" + fileName + ".txt";
        }
    }

    void CheckFolderPath()
    {
        //If the folder doesn't exist, create it
        if (!Directory.Exists(path))
        {
            Debug.Log("Creating new folder");
            Directory.CreateDirectory(path);
        }
    }

    void CreateSaveFile()
    {
        //If save file doesn't exist, create it
        if (!File.Exists(saveFilePath))
        {            
            Debug.Log("Creating new save file");
            File.Create(saveFilePath);
        }
    }

    public void WriteValues()
    {
        //Buffer to write all text to
        string toWrite = "";

        //Writer to modify txt file
        StreamWriter writer = new StreamWriter(saveFilePath, true);

        //Add name and id before other values
        writer.WriteLine(nameIF.text);
        writer.WriteLine(IDIF.text);

        //Create the grid as a string
        for (int i = 0; i < mc.mapSize; i++)
        {
            for (int j = 0; j < mc.mapSize; j++)
            {
                toWrite = toWrite + mc.grid[i, j].GetComponent<Square>().currentState.ToString();
            }

            toWrite = toWrite + "\n";
        }

        //Write grid to the text file
        writer.Write(toWrite);
        writer.Close();
        
    }
}

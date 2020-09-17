using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text.RegularExpressions;
using System;

public class ReadMapFiles : MonoBehaviour
{
    //Used to search for the wanted map from the list of maps.
    //Maps are in the list as text files.
    //Insert the ID of the map you want to find from the list.
    //Map is returned as a grid of values for each tile of the map.
    
    //List of maps
    public List<TextAsset> maps;
    //Amount of rows before the actual tile data starts in the text file
    public int amountOfRowsBeforeTileData = 2;

    //Call this with the ID of the map you want to find. String can be turned to int if needed
    public int[,] SearchMapByID(string id)
    {
        string comparison = "";
        foreach (TextAsset ta in maps)
        {
            //Read full text file, then split it into lines of text
            string[] textLines = Regex.Split(ta.text, "\n");

            //Line [1] so 2nd line of the text file is the row of the ID
            comparison = textLines[1].ToString();

            //Turn strings to int for comparison
            int i_id = int.Parse(id); // If function is used with int input instead of string, remove parse.
            int i_comparison = int.Parse(comparison);

            //Compare the file to given id
            if (i_id == i_comparison)
            {
                //Map found
                Debug.Log("Found the ID!");

                //Get the size of the map
                int rowLenght = textLines[2].Length;
                int rowHeight = textLines.Length - amountOfRowsBeforeTileData -1; //-1 because file has empty row at the end
                Debug.Log(rowLenght + " x " + rowHeight);

                //Create the output grid, then assign the values
                int[,] output = new int[rowLenght,rowHeight];

                for (int i = 0; i < rowHeight; i++)
                {
                    for (int j = 0; j < rowLenght; j ++)
                    {
                        string line = textLines[i + amountOfRowsBeforeTileData].ToString();
                        char c = line[j]; // Gotta get the char, turn it to string, then to int, i know...
                        string s = c.ToString();
                        output[i, j] = int.Parse(s);
                    }
                }
                return output;
            }
        }
        //If can't find the map
        Debug.Log("No map found with given ID");
        return new int[0,0];
    }
}

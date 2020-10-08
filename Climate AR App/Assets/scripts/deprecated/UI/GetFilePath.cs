using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetFilePath : MonoBehaviour
{
    private string splitBy = "Climate AR App";
    string buildPath;
    string pathPreFix;
    string[] files;
    Texture2D[] textList;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    /**
     * pass in the folder name(s) you want to go to
     * returns the full relative path name 
     */
    public string GetBuildPathFor(string folderName)
    {
        buildPath = Application.dataPath + "/../"; //need to triverse up a folder
        //should have this in a try catch
        //string finalPath = @"C:\Users\Keely\Pictures\altspace"; //change this to be under the build's folder
        string finalPath = buildPath;

        if (buildPath.Contains(splitBy))
        {
            string[] stringSeparators = new string[] { splitBy }; //make the string into an array

            //int index = buildPath.IndexOf("MuirTouch");
            //Debug.Log("Testing Pathing logic, index is "+ index);
            string[] splitPath = buildPath.Split(stringSeparators, StringSplitOptions.None);
            //Debug.LogError("splitPath size is " + splitPath.Length + " item at 0 is " + splitPath[0]);
            //Debug.LogError("splitPath size is " + splitPath.Length + " item at 1 is " + splitPath[1]);
            finalPath = splitPath[0] + "/" + splitBy + "/" + folderName;
            //Debug.LogError("finalPath is " + finalPath);

        }
        else
        {
            //give msg
            //exit application
            Debug.LogError("path doesnt contain " + splitBy);
        }
        return finalPath;
    }



}

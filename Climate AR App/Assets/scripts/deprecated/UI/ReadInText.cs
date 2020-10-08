using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

[RequireComponent(typeof(GetFilePath))]
public class ReadInText : MonoBehaviour
{
    string folderName = "Data";
    string[] files;
    public string fileName;

    // Start is called before the first frame update
    void Start()
    {
        //Climate AR App
        ReadText(fileName);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ReadText(string NameOfTextFile)
    {
        string finalPath = this.GetComponent<GetFilePath>().GetBuildPathFor(folderName);
        Debug.Log("finalPath " + finalPath);
        files = System.IO.Directory.GetFiles(finalPath, "*.txt"); //get all of the text files
        //Debug.Log("files size " + files.Length);
        //Debug.Log("files[0] " + files[0]);

        for(int i = 0; i < files.Length; i++)
        {
            if (files[i].Contains(NameOfTextFile))
            {
                Debug.Log("Found File");
                Debug.Log("files[" + i + "] " + files[i]);
            }
        }

        Debug.Log(files[0]);
        StreamReader inp_stm = new StreamReader(files[0]);
        while (!inp_stm.EndOfStream)
        {
            string inp_ln = inp_stm.ReadLine();
            // Do Something with the input. 
            Debug.Log(inp_ln);
        }

        inp_stm.Close();
    }
}

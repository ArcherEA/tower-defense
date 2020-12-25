using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System;


public static class SaveSystem
{
    public static void SavePlayer(int i )
    {
        BinaryFormatter formatter = new BinaryFormatter();
        String path = Application.persistentDataPath +"/player" + i.ToString() + ".fun";
        FileStream stream =new FileStream(path,FileMode.Create);

        Player_data data=new Player_data();
        formatter.Serialize(stream,data);
        stream.Close();
    }
    public static Player_data LoadPlayer(int i)
    {
        String path = Application.persistentDataPath +"/player"+i.ToString()+".fun";
        if(File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream =new FileStream(path,FileMode.Open);

            Player_data data=formatter.Deserialize(stream) as Player_data;
            stream.Close();
            return data;
        }
        else
        {
            Debug.LogError("Save file not found in "+path);
            return null;
        }
    }
    public static void DeletePlayer(int i)
    {
        String path = Application.persistentDataPath +"/player"+i.ToString()+".fun";
        if(File.Exists(path))
        {
            File.Delete(path);
            Debug.Log("success");
        }
        else
        {
            Debug.LogError("Save file not found in "+path);
           
        }
    }
}
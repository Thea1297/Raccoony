using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class GameManager : MonoBehaviour
{
    public List<ScriptableObject> objects = new List<ScriptableObject>(); //make a list of scriptable objects
    
    public void ResetScriptables()
    {
        for(int i = 0;i <objects.Count; i++)
        {
            if (File.Exists(Application.persistentDataPath + string.Format("/{0}.dat", i)))
        
                {
                    File.Delete(Application.persistentDataPath+string.Format("/{0}.dat", i));
                }
            }
        }

    private void OnEnable()
    {
        LoadScriptables();
    }
    private void OnDisable()
    {
        SaveScriptables();
    }


    /*this all not included in saving data 68.
    //static means it wont change when loaded 
    public static GameManager gameSave;
    



    //awake is called at the creating of an object
    //Awake->OnEnable->Start->LateStart...
    private void Awake()
    {
        //if there is no gameSave, then its equal to this, if exists: delete it and this script
        if (gameSave == null)
        {
            gameSave = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this);
    }*/

    public void SaveScriptables()
    {
        for (int i = 0; i < objects.Count; i++)
        {
            FileStream file = File.Create(Application.persistentDataPath+string.Format("/{0}.dat", i));
            BinaryFormatter binary = new BinaryFormatter();
            var json = JsonUtility.ToJson(objects[i]);
            binary.Serialize(file, json);
            file.Close();
        }
    }

    public void LoadScriptables()
    {
        for (int i = 0; i < objects.Count; i++)
        {
            if (File.Exists(Application.persistentDataPath + string.Format("/{0}.dat", i)))
            {
                FileStream file = File.Open(Application.persistentDataPath + string.Format("/{0}.dat", i), FileMode.Open);
                BinaryFormatter binary = new BinaryFormatter();
               JsonUtility.FromJsonOverwrite((string)binary.Deserialize(file), objects[i]);
                file.Close();
            }
        }
    }
}

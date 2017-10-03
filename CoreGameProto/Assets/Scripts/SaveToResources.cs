using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class SaveToResources : MonoBehaviour 
{
    public GameObject obj;
    private Vector3 positionY;
    public float position;
    private Quaternion rotation;

	// Use this for initialization
	void Start () 
    {
        obj = gameObject;
		
	}
	
	// Update is called once per frame
	void Update () 
    {
        position = transform.position.x;
        if (Input.GetKeyDown(KeyCode.A))
        {
            Save();

        }

        if (Input.GetKeyDown(KeyCode.B))
            Load();

        if (Input.GetKeyDown(KeyCode.L))
            transform.position = new Vector2(position, transform.position.y);
	}

    void Save()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/BoyfriendData.ata");
        ObjData item = new ObjData();
        item.pos = position;

        bf.Serialize(file, item);
        file.Close();
    }

    void Load()
    {
        if (File.Exists(Application.persistentDataPath + "/BoyFriendData.ata"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/BoyfriendData.ata", FileMode.Open);
            ObjData item = (ObjData)bf.Deserialize(file);

            file.Close();


            position = item.pos;
            Debug.Log(item.pos);

        }
        
    }

    [Serializable]  
    class ObjData
    {
        public float pos;
    }

}

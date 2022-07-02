// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// using System;
// using System.Runtime.Serialization.Formatters.Binary;
// using System.IO;

// public class SaveSerial : MonoBehaviour
// {
//     int[] intArray = new int[5]{0,0,0,0,0};

//     // int intToSave;
//     // float floatToSave;
//     // bool boolToSave;
//     void OnGUI()
//     {
//         if (GUI.Button(new Rect(0, 0, 125, 50), "Raise Integer"))
//             intArray[0]++;
//         if (GUI.Button(new Rect(0, 100, 125, 50), "Raise Float"))
//             intArray[1]++;
//         // if (GUI.Button(new Rect(0, 200, 125, 50), "Change Bool"))
//         //     boolToSave = boolToSave ? boolToSave 
//         //                 = false : boolToSave = true;
//         GUI.Label(new Rect(375, 0, 125, 50), "Integer value is " 
//                     + intArray[0]);
//         GUI.Label(new Rect(375, 100, 125, 50), "Float value is " 
//                     + intArray[1]);
//         // GUI.Label(new Rect(375, 200, 125, 50), "Bool value is " 
//         //             + boolToSave);
//         if (GUI.Button(new Rect(750, 0, 125, 50), "Save Your Game"))
//             SaveGame();
//         if (GUI.Button(new Rect(950, 0, 125, 50), "Save Your Game"))
//             SaveGame();
//         if (GUI.Button(new Rect(750, 100, 125, 50), 
//                     "Load Your Game"))
//             LoadGame();
//         if (GUI.Button(new Rect(750, 200, 125, 50), 
//                     "Reset Save Data"))
//             ResetData();
//     }
    
//     void SaveGame()
//     {
//         BinaryFormatter bf = new BinaryFormatter(); 
//         FileStream file = File.Create(Application.persistentDataPath 
//                     + "/MySaveData.dat"); 
//         SaveData data = new SaveData();


//         data.intArray = intArray;



//         bf.Serialize(file, data);
//         file.Close();
//         Debug.Log("Game data saved!");
//     }

//     void LoadGame()
//     {
//         if (File.Exists(Application.persistentDataPath 
//                     + "/MySaveData.dat"))
//         {
//             BinaryFormatter bf = new BinaryFormatter();
//             FileStream file = 
//                     File.Open(Application.persistentDataPath 
//                     + "/MySaveData.dat", FileMode.Open);
//             SaveData data = (SaveData)bf.Deserialize(file);
//             file.Close();


//             intArray = data.intArray;
//             Debug.Log("Game data loaded!");
//         }
//         else
//             Debug.LogError("There is no save data!");
//     }
    
//     void ResetData()
//     {
//         if (File.Exists(Application.persistentDataPath 
//                     + "/MySaveData.dat"))
//         {
//             File.Delete(Application.persistentDataPath 
//                             + "/MySaveData.dat");
//             // intToSave = 0;
//             intArray = new int[5]{0,0,0,0,0};
//             // boolToSave = false;
//             Debug.Log("Data reset complete!");
//         }
//         else
//             Debug.LogError("No save data to delete.");
//     }
// }   

// // [Serializable]
// // class SaveData
// // {
// //     public int[] intArray = new int[5]{0,0,0,0,0};
// //     // public int savedInt;
// //     // public float savedFloat;
// //     // public bool savedBool;
// // }
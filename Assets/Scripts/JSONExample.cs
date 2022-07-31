using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JSONExample : MonoBehaviour
{

    public GameObject buttonPrefab;

    //Data 1
    public PropertiesList PropertiesList = new PropertiesList();

    public GameObject buttonAttach;
    public GameObject panel;
    public Text descritionPanel;

    //Data 2
    public PropertiesList2 PropertiesList2 = new PropertiesList2();

    public GameObject buttonAttach2;
    public GameObject panel2;
    public Text descritionPanel2;

    void Start()
    {
        Init();
        Reader();
        Reader2();
    }

    void Init()
    {
        panel.SetActive(false);
        panel2.SetActive(false);
    }


    void Reader()
    {
        //Load JSON file
        TextAsset asset = Resources.Load("File1") as TextAsset;


        if (asset != null)
        {
            //Parse JSON to get properties
            PropertiesList = JsonUtility.FromJson<PropertiesList>(asset.text);


            foreach (FileProperties fileProperties in PropertiesList.FileProperties)
            {
                CreateButton(fileProperties.id, fileProperties.title, fileProperties.content);
            }
        }
        else
        {
            Debug.LogWarning("No files!");
        }
    }


    void CreateButton(int buttonId, string buttonName, string description)
    {
        //Instanciate Button
        GameObject button = (GameObject)Instantiate(buttonPrefab);
        //Change button name
        button.name = $"Button {buttonId}";
        //Place it in the canvas
        button.transform.SetParent(buttonAttach.transform);
        //Change button name
        button.transform.GetChild(0).GetComponent<Text>().text = buttonName;


        //What button does when clicked
        button.GetComponent<Button>().onClick.AddListener(() => { OnClick(description); });
    }

    


    void OnClick(string description)
    {
        //Select description depending on which button is pressed 
        descritionPanel.text = description.ToString();
    }


    public void OnClickFile()
    {
        //Activate File menu
        if (!buttonAttach.activeInHierarchy)
        {
            panel.SetActive(true);
        }
    }







    void Reader2()
    {
        //Load JSON file
        TextAsset asset = Resources.Load("File2") as TextAsset;


        if (asset != null)
        {
            //Parse JSON to get properties
            PropertiesList2 = JsonUtility.FromJson<PropertiesList2>(asset.text);


            foreach (FileProperties2 fileProperties2 in PropertiesList2.FileProperties2)
            {
                CreateButton2(fileProperties2.id, fileProperties2.title, fileProperties2.content);
            }
        }
        else
        {
            Debug.LogWarning("No files!");
        }
    }

    void CreateButton2(int buttonId, string buttonName, string description)
    {
        //Instanciate Button
        GameObject button = (GameObject)Instantiate(buttonPrefab);
        //Change button name
        button.name = $"ButtonV2 {buttonId}";
        //Place it in the canvas
        button.transform.SetParent(buttonAttach2.transform);
        //Change button name
        button.transform.GetChild(0).GetComponent<Text>().text = buttonName;


        //What button does when clicked
        button.GetComponent<Button>().onClick.AddListener(() => { OnClick2(description); });
    }

    void OnClick2(string description)
    {
        //Select description depending on which button is pressed 
        descritionPanel2.text = description.ToString();
    }

    public void OnClickFile2()
    {
        //Activate File menu
        if (!buttonAttach.activeInHierarchy)
        {
            panel2.SetActive(true);
        }
    }
}

using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JSONExample : MonoBehaviour
{
    public PropertiesList PropertiesList = new PropertiesList();

    public GameObject buttonPrefab;
    public GameObject buttonAttach;

    public GameObject panel;
    public Text descritionPanel;




    void Start()
    {
        Reader();
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

}

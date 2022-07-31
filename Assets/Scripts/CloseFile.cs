using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CloseFile : MonoBehaviour
{
    public void Close()
    {
        Transform descritionPanel = this.transform.GetChild(1);
        descritionPanel.GetChild(0).GetComponent<Text>().text = null;
        this.gameObject.SetActive(false);
    }
}

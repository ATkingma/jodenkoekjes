using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ItemList : MonoBehaviour
{
    public List<float> itemQuantity;
    public List<string> itemTest, inChatQueue;
    public List<TextMeshProUGUI> chatPlaces;

    //privates
    private Color color0, color1, color2, color3, color4;

    public void Start()
    {
        for (int i = 0; i < 5; i++)
        {
            chatPlaces[i] = GameObject.FindGameObjectWithTag("Chat" + i).GetComponent<TextMeshProUGUI>();
        }
        color0 = chatPlaces[0].GetComponent<TextMeshProUGUI>().color;
        color1 = chatPlaces[1].GetComponent<TextMeshProUGUI>().color;
        color2 = chatPlaces[2].GetComponent<TextMeshProUGUI>().color;
        color3 = chatPlaces[3].GetComponent<TextMeshProUGUI>().color;
        color4 = chatPlaces[4].GetComponent<TextMeshProUGUI>().color;
    }
    public void GetSaves()
    {
        for (int i = 0; i < itemQuantity.Count; i++)
        {
            itemQuantity[i] = PlayerPrefs.GetFloat("itemQuantity" + i, itemQuantity[i]);
        }
    }
    public void PrintItemInChat(int damnSon)
    {
        inChatQueue[4] = inChatQueue[3];
        inChatQueue[3] = inChatQueue[2];
        inChatQueue[2] = inChatQueue[1];
        inChatQueue[1] = inChatQueue[0];
        if(damnSon < 14)
        {
            inChatQueue[0] = itemTest[damnSon] + " [" + itemQuantity[damnSon] + "]";
        }
        else
        {
            inChatQueue[0] = itemTest[damnSon];
        }

        for(int i = 0; i < 5; i++)
        {
            chatPlaces[i].text = inChatQueue[i];
        }
        color0.a = 1;
        color1.a = 1;
        color2.a = 1;
        color3.a = 1;
        color4.a = 1;
    }
    public void Save()
    {
        for(int i = 0; i < itemQuantity.Count; i++)
        {
            PlayerPrefs.SetFloat("itemQuantity" + i, itemQuantity[i]);
        }
    }
    public void DeleteSaves()
    {
        for (int i = 0; i < itemQuantity.Count; i++)
        {
            PlayerPrefs.SetFloat("itemQuantity" + i, 0);
        }
    }
    public void Update()
    {
        color0.a -= 0.5f * Time.deltaTime;
        color1.a -= 0.5f * Time.deltaTime;
        color2.a -= 0.5f * Time.deltaTime;
        color3.a -= 0.5f * Time.deltaTime;
        color4.a -= 0.5f * Time.deltaTime;

        chatPlaces[0].color = color0;
        chatPlaces[1].color = color1;
        chatPlaces[2].color = color2;
        chatPlaces[3].color = color3;
        chatPlaces[4].color = color4;
    }
}
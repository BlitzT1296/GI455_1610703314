using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using WebSocketSharp;

public class Chat : MonoBehaviour
{
    public WebSocket ws;
    public InputField url;
    public InputField port;
    public Button connect;
    public InputField ChatInput;
    public Button send;
    public GameObject Chatprefabs;
    public GameObject chatPanel;

    private void Start()
    {
        connect.onClick.AddListener(Connect);
        send.onClick.AddListener(ChatSend);

    }

    public void OtherChat(object sender,MessageEventArgs f)
    {
        var prefabs = Instantiate(Chatprefabs, chatPanel.transform);
        var child = prefabs.transform.GetChild(0);

        prefabs.GetComponent<VerticalLayoutGroup>().childAlignment = TextAnchor.LowerLeft;
        child.GetComponent<Text>().alignment = TextAnchor.MiddleLeft;
        child.GetComponent<Text>().text = f.Data;
        
       
    }

    public void Connect()
    {

        ws = new WebSocket($"ws://{url.text}:{port.text}");
        ws.OnMessage += OtherChat;
        ws.Connect();
      
    }

    public void ChatSend()
    {
        ws.Send(ChatInput.text);
        var prefab = Instantiate(Chatprefabs, chatPanel.transform);
        var child = prefab.transform.GetChild(0);
        child.GetComponent<Text>().text = ChatInput.text;
    }
}

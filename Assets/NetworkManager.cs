using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;
using UnityEngine;
using WebSocketSharp;
public class NetworkManager : Singleton<NetworkManager>
{

    public static WebSocket ws;
    public Player player;

    public class MyClass
    {
        public string status { get; set; }
        public string type { get; set; }
        public bool turn { get; set; }
    }


    public string PlayerNumber;
    public MyClass json;

    public void Awake()
    {


    var account = new Account
    {
        id = 51,
        Email = "james@example.com"
    };

        ws = new WebSocket("ws://192.168.137.185:4856/");
        ws.OnMessage += (sender, e) => _ws_OnMessage(sender, e);

        ws.Connect();
        ws.Send(JsonConvert.SerializeObject(account));
    }
    public void _ws_OnMessage(object sender, MessageEventArgs e)
    {
        Debug.Log("Laputa says: " + e.Data);
        json = JsonConvert.DeserializeObject<MyClass>(e.Data);


        if (json.type != null)
        {
            //player.PlayerNumber = json.type;
        }
        player.NextTurn = json.turn;
    }


    public void _ws_Fire()
    {

    var turninfo = new TurnInfo
    {
        shoot = true,
        time = 1,
        rotation = 0
    };

        var jsoninfo = JsonConvert.SerializeObject(turninfo);
        ws.Send(jsoninfo);
    }



}

using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;
using UnityEngine;
using WebSocketSharp;
using UnityEngine.UI;
public class NetworkManager : Singleton<NetworkManager>
{

    public static WebSocket ws;
    public Text UsernameText;
    public string Username,EnemyName;
    public MyGameManager myGameManager;
    public int PlayerNumber;
    public bool Turn;
    public bool startGame,findMatch;


    public void Awake()
    {

        ws = new WebSocket("ws://192.168.137.185:4856/");
        ws.OnMessage += (sender, e) => _ws_OnMessage(sender, e);

        ws.Connect();
        //ws.Send(JsonConvert.SerializeObject(account));
    }
    public void _ws_OnMessage(object sender, MessageEventArgs e)
    {
        Debug.Log(e.Data);

        var account = new Account{
            name = UsernameText.text.ToString(),
            type = "check_name"

        };

        var json = JsonConvert.DeserializeObject<Account>(e.Data);
        string data = e.Data.ToString();

         if(json.type == "check_name" && data.Contains("ok")){
         findMatch = true;    
        }

        if(findMatch){
        account.type = "find_match";
        ws.Send(JsonConvert.SerializeObject(account));
        var shootInfo = JsonConvert.DeserializeObject<ShootInfo>(e.Data);
        findMatch = false;
         Turn = shootInfo.turn;
        EnemyName = shootInfo.enemy_name;    

        }






        // }else if(json.type == "check_name" && e.Data.ToString().Contains("no")){
        // myGameManager.ChangeYourName();
        // }
        //var jsonturnInfo = JsonConvert.DeserializeObject<TurnInfo>(e.Data);
    }

    void Activate(){
        
    }

    public void CreateAccount(){
        var account = new Account{
            name = UsernameText.text.ToString(),
            type = "check_name"
        };
        ws.Send(JsonConvert.SerializeObject(account));
    }

        public void SendShootInfo(Vector3 shootlocatin){
            
        var shootInfo = new ShootInfo{
            self_name = UsernameText.text.ToString(),
            enemy_name = EnemyName,
            type = "shoot",
            location = shootlocatin,
            unix_time = 0,
        };
        Debug.LogError(shootInfo);
        ws.Send(JsonConvert.SerializeObject(shootInfo));
    }



    void StartGame(){
        
    }




}

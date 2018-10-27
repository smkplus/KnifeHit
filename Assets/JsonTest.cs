using UnityEngine;
using System.Collections;
using UnityEngine.Networking;
using Newtonsoft.Json;

public class JsonTest : NetworkBehaviour {

	public class Soldier{
	public string id {get;set;}
	public string Name {get;set;}
	public bool Level {get;set;}
    }
	public Soldier soldier;

	private void Start() {
	string jsonString = "{\"id\":1, \"Name\":\"Jack\", \"Level\":0}";
	CmdSendData(jsonString);
	}

	[Command]
	public void CmdSendData (string json) {
	RpcSendData(json);
	}

	[ClientRpc]
	public void RpcSendData (string json) {
		var information = JsonConvert.DeserializeObject<Soldier>(json);
		soldier.id = information.id;
		soldier.Level = information.Level;
		soldier.Name = information.Name;
	}
	

}

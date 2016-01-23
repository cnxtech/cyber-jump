using UnityEngine;
using System.Collections;

public class DeviceController : MonoBehaviour {
  public string type;
	public bool functioning;
  private GameController gameController;

  void Start() {
	functioning = true;
    gameController = GameObject.Find("GameController").GetComponent<GameController>();
  }

  public void CyberJump(PlayerController player) {
    if (type == "SecurityCamera") {
      SecurityCameraCyberJump(player);
    } else if (type == "Exit") {
      ExitCyberJump(player);
    }
  }

  void SecurityCameraCyberJump(PlayerController player) {
    Debug.Log("I am security camera");
    TransformPlayer(player);
  }

  void ExitCyberJump(PlayerController player) {
    Debug.Log("I am exit");
    gameController.Win();
    TransformPlayer(player);
  }

  void TransformPlayer(PlayerController player) {
    player.transform.position = transform.position;
    player.transform.rotation = transform.rotation;
  }

  public void Disable() {
	MeshRenderer rend = GetComponent<MeshRenderer> ();
	rend.material.SetColor ("_Color", Color.red);
	functioning = false;
  }
}

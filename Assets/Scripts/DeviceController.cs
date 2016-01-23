using UnityEngine;
using System.Collections;

public class DeviceController : MonoBehaviour {

  public string type;
  public float speed;
  public GameObject leftCam;
  public GameObject rightCam;

  private GameController gameController;
  private Quaternion leftRotation;
  private Quaternion rightRotation;
  private bool rotateRight;
  private float startTime;

  void Start() {
    gameController = GameObject.Find("GameController").GetComponent<GameController>();

    if (leftCam != null && rightCam != null) {
      leftRotation = leftCam.transform.rotation;
      rightRotation = rightCam.transform.rotation;
      rotateRight = true;
      startTime = Time.time;
    }
  }

  void Update(){
    if (leftCam == null && rightCam == null) {
      return;
    }

    if (rotateRight) {
      transform.rotation = Quaternion.Lerp(
        leftRotation,
        rightRotation,
        (Time.time - startTime) * speed
      );
    } else {
      transform.rotation = Quaternion.Lerp(
        rightRotation,
        leftRotation,
        (Time.time - startTime) * speed
      );
    }

    if (transform.rotation == rightRotation) {
      rotateRight = false;
      startTime = Time.time;
    } else if (transform.rotation == leftRotation) {
      rotateRight = true;
      startTime = Time.time;
    }

    /*if(transform.rotation > Quaternion.AngleAxis(30,Vector3.up)){
      transform.Rotate (Vector3.up * 90*Time.deltaTime);
    }*/
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
  }

  void ExitCyberJump(PlayerController player) {
    Debug.Log("I am exit");
    gameController.Win();
  }
}

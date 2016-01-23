using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

  public GameObject particle;
  public DeviceController currentDevice;
	public AudioClip jumpFx;

  private bool hasFired;

  void Start() {
    hasFired = false;
    if (currentDevice != null) {
      currentDevice.SetModel(false);
    }
  }

  void Update() {
    if (currentDevice != null) {
      transform.position = currentDevice.transform.position;
      transform.rotation = currentDevice.transform.rotation;
    }
  }

  void FixedUpdate() {
    if (!hasFired && Input.GetButtonDown("Fire1")) {
      FireRay();
      hasFired = true;
    }

    if (Input.GetButtonUp("Fire1")) {
      hasFired = false;
    }
  }

  void FireRay() {
    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
    RaycastHit hit;

    if (Physics.Raycast(ray, out hit)) {
      GameObject collidedDevice = hit.collider.gameObject;

      if (collidedDevice.CompareTag("Device")) {

        Instantiate(particle, collidedDevice.transform.position, collidedDevice.transform.rotation);

        currentDevice.SetModel(true);
        currentDevice = collidedDevice.GetComponent<DeviceController>();
        if (currentDevice.IsFunctioning()) {
          GetComponent<AudioSource>().PlayOneShot(jumpFx);
          currentDevice.CyberJump(this);
        }
      }
    }
  }

  public bool IsCurrentDevice(DeviceController otherController) {
    return currentDevice == otherController;
  }
}

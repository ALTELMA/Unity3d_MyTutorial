using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	public Transform[] cameraTargets;
	int cameraIndex;
	float CameraRotX = 0f;
	CameraSettings cameraSettings;

	// Use this for initialization
	void Start () {
		cameraSettings = cameraTargets[cameraIndex].GetComponent<CameraSettings>();
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Tab)){
			cameraIndex++;

			if(cameraIndex >= cameraTargets.Length){
				cameraIndex = 0;
			}

			cameraSettings = cameraTargets[cameraIndex].GetComponent<CameraSettings>();
		}

		if(cameraTargets[cameraIndex]){
			if(cameraSettings.smoothing == 0f){
				transform.position = cameraTargets[cameraIndex].position;
				transform.rotation = cameraTargets[cameraIndex].rotation;
			}else{
				transform.position = Vector3.Lerp(transform.position, cameraTargets[cameraIndex].position, Time.deltaTime * cameraSettings.smoothing);
				transform.rotation = cameraTargets[cameraIndex].rotation;
			}
		}
	}
}

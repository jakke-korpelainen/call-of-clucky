using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour {

    [SerializeField]
    private Vector3 cameraOffset;

    [SerializeField]
    private float damping;

    private Transform cameraLookTarget;
    private Player _localPlayer;

	void Awake()
    {
        GameManager.Instance.OnLocalPlayerJoined += HandleOnLocalPlayerJoined;
    }

    void Update()
    {
        Vector3 targetPosition = cameraLookTarget.position + 
            _localPlayer.transform.forward * cameraOffset.z + 
            _localPlayer.transform.up * cameraOffset.y + 
            _localPlayer.transform.right * cameraOffset.x;

        Quaternion targetRotation = Quaternion.LookRotation(cameraLookTarget.position - targetPosition, Vector3.up);

        transform.position = Vector3.Lerp(transform.position, targetPosition, damping * Time.deltaTime);
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, damping * Time.deltaTime);
    }

    private void HandleOnLocalPlayerJoined(Player player)
    {
        _localPlayer = player;
        cameraLookTarget = _localPlayer.transform.Find("cameraLookTarget");

        if (cameraLookTarget == null)
            cameraLookTarget = _localPlayer.transform;
    }
}

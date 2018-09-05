﻿using UnityEngine;

public class PlayerSpellsCast : MonoBehaviour {

    private GameObject _fireballPrefab;
    private CameraRaycaster _cameraRaycaster;


	// Use this for initialization
	void Start () {
        _fireballPrefab = (GameObject)Resources.Load("Fireball", typeof(GameObject));
        _cameraRaycaster = Camera.main.GetComponent<CameraRaycaster>();
    }

    private void ThrowFireball()
    {
        Vector3 hitPoint = _cameraRaycaster.hit.point;
        GameObject fireball = Instantiate(_fireballPrefab, gameObject.transform.position + (hitPoint - gameObject.transform.forward).normalized / 2, Quaternion.identity);
        SpellProperties properties = fireball.GetComponent<SpellProperties>();
        properties.Destination = hitPoint;
    }

    // Update is called once per frame
    void Update () {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            ThrowFireball();
        }
    }
}
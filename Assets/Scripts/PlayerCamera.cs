using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CameraScene : MonoBehaviour
{
    [SerializeField] GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(12, 14.5f, -14);
        transform.eulerAngles = new Vector3(35, -40, 0);
        GetComponent<Camera>().orthographic = true;
        GetComponent<Camera>().orthographicSize = 3;
    }

    private void Update()
    {

        transform.position = new Vector3(12, 14.5f, -14) + player.transform.position;
    }
}

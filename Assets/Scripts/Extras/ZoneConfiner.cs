using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class ZoneConfiner : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera virtualCamera;
    
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player")) {
            virtualCamera.gameObject.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if (other.CompareTag("Player")) {
            virtualCamera.gameObject.SetActive(false);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

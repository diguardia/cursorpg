using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private Transform restaurationPoint;
    [SerializeField] private Player player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R)) {
            if (player.PlayerLife.IsDefeated) {
                player.transform.localPosition = restaurationPoint.position;
                player.ComeBackToLife();

            }
        }
    }
}

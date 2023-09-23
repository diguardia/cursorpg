using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator _animator;
    private PlayerMovement _characterMovement;
    private int movementX = Animator.StringToHash("X");
    private int movementY = Animator.StringToHash("Y");
    private int defated = Animator.StringToHash("Defeated");
    
    [SerializeField] string layerIdle;
    [SerializeField] private string layerWalk;    

    void Awake() {
        _animator = GetComponent<Animator>();
        _characterMovement = GetComponent<PlayerMovement>();
    }
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        UpdateLayers();

        if (_characterMovement.InMovement) {
            _animator.SetFloat(movementX, _characterMovement.Direction.x);
            _animator.SetFloat(movementY, _characterMovement.Direction.y);
        }
    }

    void UpdateLayers() {
        if (_characterMovement.InMovement) {
            ActivateLayer(layerWalk);
        } else {
            ActivateLayer(layerIdle);
        }
    }
    void ActivateLayer(string layerName) {
        int idx = _animator.GetLayerIndex(layerName);

        for (var i=0;i<_animator.layerCount;i++) {
            if (i==idx) { _animator.SetLayerWeight(i,1);} else {_animator.SetLayerWeight(i,0);}
        }
    }
    private void OnEnable() {
        PlayerLife.DefeatedEvent += PlayerDefeatedCallback;
    }

    private void OnDisable() {
        PlayerLife.DefeatedEvent -= PlayerDefeatedCallback;
    }

    private void PlayerDefeatedCallback()
    {
        if (_animator.GetLayerWeight(_animator.GetLayerIndex(layerIdle)) != 1) {
            ActivateLayer(layerIdle);
        }
        
        _animator.SetBool(defated, true);
    }

    public void ComeBackToLife() {
        ActivateLayer(layerIdle);
        _animator.SetBool(defated, false);
    }
}

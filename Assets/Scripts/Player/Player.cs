using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [field: Header("References")]
    [field: SerializeField] public PlayerSO Data { get; private set; }

    [field: Header("Animations")]
    [field: SerializeField] public PlayerAnimationData AnimationData { get; private set; }

    public Rigidbody Rigidbody { get; private set; }
    public Animator Animator { get; private set; }
    public PlayerInput Input { get; private set; }
    public CharacterController Controller { get; private set; }

    public ForceReceiver ForceReceiver { get; private set; }

    [field: SerializeField] public Weapon Weapon { get; private set; }

    public Health Health { get; private set; }

    private PlayerStateMachine stateMachine; // 행동을 관리할 스테이트 머신

    private Vector3 checkPoint; // 체크포인트, 부활 위치

    private void Awake()
    {
        AnimationData.Initialize();

        Rigidbody = GetComponent<Rigidbody>();
        Animator = GetComponentInChildren<Animator>();
        Input = GetComponent<PlayerInput>();
        Controller = GetComponent<CharacterController>();
        ForceReceiver = GetComponent<ForceReceiver>();
        Health = GetComponent<Health>();

        stateMachine = new PlayerStateMachine(this);

        // 체크포인트 초기화
        checkPoint = new Vector3(0, 0, 0);
    }

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        stateMachine.ChangeState(stateMachine.IdleState);

        Health.OnDie += OnDie;
    }

    private void Update()
    {
        stateMachine.HandleInput();
        stateMachine.Update();
    }
     
    private void FixedUpdate()
    {
        stateMachine.PhysicsUpdate();
    }

    void OnDie()
    {
        Animator.SetTrigger("Die");
        enabled = false;
    }

    public void SaveCheckPoint(Vector3 position)
    {
        checkPoint = position;
    }
}

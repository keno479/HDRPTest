using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using anogamelib;
using UnityEngine.Events;
using TMPro;
using Cinemachine;

public class UnitController : StateMachineBase<UnitController>
{
    public InputAction InputMove;
    public Vector2 Movevalue;
    public InputAction InputCameraRotate;
    public float CameraRotateValue;
    private Rigidbody rb;
    public float moveSpeed = 3.0f;
    private Animator Anim;
    public bool isBattle;
    private UnityEvent AttackHitHandler = new UnityEvent();
    private UnityEvent AttackEndHandler = new UnityEvent();
    private UnityEvent FreezeHandler = new UnityEvent();
    public bool CanWalk;
    public Transform CanvasDamage;
    public Camera cam;
    public AudioSource audios;
    public CinemachineFreeLook FreeLook;

    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Anim = GetComponent<Animator>();
        audios = GetComponent<AudioSource>();
        SetState(new UnitController.Idle(this));
    }

    public void OnAttackHit()
    {
        AttackHitHandler.Invoke();
    }
    public void OnAttackEnd()
    {
        AttackEndHandler.Invoke();
    }
    public void OnFreeze()
    {
        FreezeHandler.Invoke();
    }

    private void OnEnable()
    {
        //Debug.Log("Enable");
        InputMove.Enable();
        InputCameraRotate.Enable();
    }

    private void OnDisable()
    {
        //Debug.Log("Disable");
        InputMove.Disable();
        InputCameraRotate.Enable();
    }
    protected override void OnUpdatePrev()
    {
        base.OnUpdatePrev();
        Movevalue = InputMove.ReadValue<Vector2>();

        CameraRotateValue = InputCameraRotate.ReadValue<float>();
        /*if (Input.GetMouseButtonDown(0))
        {
            Anim.SetTrigger("AttackTrigger");
        }*/

    }

    public void FightButtonDown()
    {
        isBattle = true;
        Anim.SetBool("isBattle", isBattle);
    }

    public void EscapeButtonDown()
    {
        isBattle = false;
        Anim.SetBool("isBattle", isBattle);
    }

    public void SetCanWalk(bool flag)
    {
        CanWalk = flag;
        //Debug.Log(flag);
    }

    private void FixedUpdate()
    {
        if (CanWalk)
        {
            Vector3 cameraForward = Vector3.Scale(Camera.main.transform.forward, new Vector3(1, 0, 1)).normalized;

            Vector3 moveForward = cameraForward * Movevalue.y + Camera.main.transform.right * Movevalue.x;

            rb.velocity = moveForward * moveSpeed + new Vector3(0, rb.velocity.y, 0);

            if (moveForward != Vector3.zero)
            {
                transform.rotation = Quaternion.LookRotation(moveForward);
            }

            if (Anim != null)
            {
                Anim.SetBool("isWalk", 0 < Movevalue.sqrMagnitude);
            }
        }
        else
        {
            Anim.SetBool("isWalk", false);
        }

        FreeLook.m_XAxis.m_InputAxisValue = CameraRotateValue * 0.2f;
    }

    private class Idle : StateBase<UnitController>
    {
        public override void OnEnterState()
        {
            base.OnEnterState();
            machine.CanWalk = true;
        }

        public override void OnUpdateState()
        {
            base.OnUpdateState();
            if (machine.isBattle)
            {
                machine.SetState(new UnitController.Search(machine));
            }
            if (DataManager.Instance.UnitPlayer.HP <= 0)
            {
                //machine.rb.isKinematic = true;
                machine.SetState(new UnitController.DeadState(machine));
            }
        }
        public Idle(UnitController _machine) : base(_machine)
        {
        }
    }

    private class Search : StateBase<UnitController>
    {
        public override void OnEnterState()
        {
            base.OnEnterState();
            //Debug.Log("search");
        }
        public override void OnUpdateState()
        {
            base.OnUpdateState();

            if (!machine.isBattle)
            {
                machine.SetState(new UnitController.Idle(machine));
            }
            foreach (EnemyController enemy in EnemyManager.Instance.EnemyList)
            {
                if (enemy.IsFind() && enemy.isAlive())
                {
                    machine.SetState(new UnitController.Battle(machine, enemy));
                    break;
                }
            }
        }
        public Search(UnitController _machine) : base(_machine)
        {
        }
    }

    private class Battle : StateBase<UnitController>
    {
        private EnemyController enemy;
        private float Timer;
        public float AttackSpan;
        public GameDirector director;

        public override void OnEnterState()
        {
            base.OnEnterState();
            GameDirector.Instance.EscOff();
            //machine.rb.isKinematic = true;
            //Debug.Log("battle");
            AttackSpan = 1.0f;
            machine.CanWalk = false;
        }

        public override void OnUpdateState()
        {
            base.OnUpdateState();
            machine.transform.LookAt(enemy.transform);
            Timer += Time.deltaTime;
            if (Timer >= AttackSpan)
            {
                machine.SetState(new UnitController.Attack(machine, enemy));
            }

            if (DataManager.Instance.UnitPlayer.HP <= 0)
            {
                machine.SetState(new UnitController.DeadState(machine));
            }
        }
        public Battle(UnitController machine, EnemyController enemy) : base(machine)
        {
            this.machine = machine;
            this.enemy = enemy;
        }
    }

    private class Attack : StateBase<UnitController>
    {
        private EnemyController enemy;
        public override void OnEnterState()
        {
            base.OnEnterState();
            machine.AttackHitHandler.AddListener(() =>
            {
                machine.audios.PlayOneShot(AudioManager.Instance.SE_Unit[0]);
                int attack = DataManager.Instance.UnitPlayer.GetTotalAttack();
                if (enemy.Damage(attack))
                {
                    DataManager.Instance.dataenemy.AddKillCount(enemy.Enemy_ID);
                    GameDirector.Instance.DropItem(enemy.Enemy_ID);
                    GameDirector.Instance.DropGold(enemy.usemasterparam);
                    GameDirector.Instance.EscOn();
                    machine.CanWalk = true;
                    GameDirector.Instance.GetEXP(enemy.usemasterparam.Base_EXP);
                    if (enemy.Boss)
                    {
                        GameDirector.Instance.OpenStage(enemy.Enemy_ID);
                    }
                    machine.SetState(new UnitController.Search(machine));
                    //Debug.Log(param.Base_Gold);
                };
                GameObject damage = Instantiate(PrefabHolder.Instance.DamageText,machine.CanvasDamage) as GameObject;
                damage.GetComponent<DamageText>().Initialize(attack, machine.cam, enemy.transform.position);
                //damage.transform.position = machine.cam.WorldToScreenPoint(enemy.transform.position);
                //damage.GetComponent<TextMeshProUGUI>().text = $"{attack}";
            });
            machine.AttackEndHandler.AddListener(() =>
            {
                machine.SetState(new UnitController.Battle(machine, enemy));
            });
            machine.Anim.SetTrigger("AttackTrigger");
            //Debug.Log("attack");

        }
        public override void OnUpdateState()
        {
            base.OnUpdateState();
            if (!enemy.isAlive())
            {
                
            }
        }
        public override void OnExitState()
        {
            base.OnExitState();
            machine.AttackHitHandler.RemoveAllListeners();
            machine.AttackEndHandler.RemoveAllListeners();
        }
        public Attack(UnitController machine, EnemyController enemy) : base(machine)
        {
            this.machine = machine;
            this.enemy = enemy;
        }
    }

    private class DeadState : StateBase<UnitController>
    {
        public override void OnEnterState()
        {
            base.OnEnterState();
            machine.CanWalk = false;
            machine.FreezeHandler.AddListener(() =>
            {
                machine.SetState(new UnitController.Freeze(machine));
            });
            machine.Anim.SetTrigger("DieTrigger");
        }
        public DeadState(UnitController _machine) : base(_machine)
        {
        }
    }

    private class Freeze : StateBase<UnitController>
    {
        public override void OnUpdateState()
        {
            base.OnUpdateState();
            if (DataManager.Instance.UnitPlayer.HP > 0)
            {
                //Debug.Log("revive");
                machine.Anim.SetTrigger("ReviveTrigger");
                machine.SetState(new UnitController.Idle(machine));
            }
        }
        public override void OnExitState()
        {
            base.OnExitState();
        }
        public Freeze(UnitController _machine) : base(_machine)
        {
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Home")
        {
            UIAssistant.Instance.ShowPage("Home");
            SetCanWalk(false);
        }
    }

    public void ExitHome()
    {
        UIAssistant.Instance.ShowPage("idle");
        SetCanWalk(true);
    }
}

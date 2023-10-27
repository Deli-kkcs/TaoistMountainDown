using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Character
{
    [Tooltip("����CD")]
    public List<float> skill_loadCD;
    [Tooltip("���ܳ�����")]
    public List<float> skill_loadTimer;
    [Header("���ܳ���ʱ��")]
    public List<float> skill_usingMaxTime;
    [Tooltip("���������")]
    public List<float> skill_usingTimer;
    [Tooltip("���ܹ�����Χ")]
    public List<float> skill_range;
    [Tooltip("�Ƿ������ͷż���")]
    public List<bool> skill_emit;
    protected delegate void SkillFuncs();
    protected List<SkillFuncs> skillFuncs;
    protected Vector3 target;
    protected virtual void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        skillFuncs = new() { Skill_0 };
    }
    public void Skill_0()
    {
        //anim.SetBool("Move", true);
        //anim.SetBool("Idle", false);
        Player player = PlayerManager.instance.currentPlayer;
        if (!player)
            return;
        skill_emit[0] = true;
        if (CheckNear(player.transform.position, transform.position, skill_range[0]))
        {
            //Debug.Log("Next to player : MOVE!!");
            Vector3 delta_vec = (player.transform.position - transform.position).normalized;
            transform.GetComponent<Rigidbody2D>().velocity = delta_vec * moveSpeed;
            target = player.transform.position;
            //StartCoroutine(nameof(EndSkill_1),player.transform);
        }
        else
        {
            //Debug.Log("# Random MOVE!!");
            Vector3 delta_vec = new(Random.Range(-1.2f, 1.2f), UnityEngine.Random.Range(-1.2f, 1.2f), 0f);
            //transform.GetComponent<Rigidbody2D>().velocity = delta_vec * moveSpeed;
            transform.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            target = new(1e9f, 1e9f, 0f);
            //StartCoroutine(nameof(EndSkill_1), remoteDirection);
        }
        EndSkill_0();
    }
    public void EndSkill_0()
    {
        //anim.SetBool("Idle", true);
        //anim.SetBool("Move", false);
        if (!CheckNear(transform.position, target, 0.1f) && skill_usingTimer[0] <= skill_usingMaxTime[0])
        {
            skill_usingTimer[0] += 0.02f;
            Invoke(nameof(EndSkill_0), 0.02f);
            return;
        }
        skill_emit[0] = false;
        skill_usingTimer[0] = 0;
        skill_loadTimer[0] = 0;
        //Invoke(nameof(StopMove), slidingTime);
    }
    public virtual void EmitSkill()//Ĭ�ϼ���0��������ƶ�
    {
        for (int i = 0; i < skill_loadTimer.Count; i++)
        {
            skill_loadTimer[i] += Time.deltaTime;
            if (skill_loadTimer[i] >= skill_loadCD[i] && !skill_emit[i])
            {
                skillFuncs[i]();
            }
        }
    }
}

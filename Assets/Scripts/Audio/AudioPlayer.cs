using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    public static AudioPlayer instance;
    public AudioSource music;
    public AudioClip Mshot;//������Ҫ�����������Ծ����Ч

    private void Awake()
    {
        instance = this;
        //���������һ��AudioSource���
        music = GetComponent<AudioSource>();
        //���ò�һ��ʼ�Ͳ�����Ч
        music.playOnAwake = false;
        //������Ч�ļ����Ұ���Ծ����Ƶ�ļ�����Ϊjump
        //jump = Resources.Load<AudioClip>("music/jump");
    }
    void Update()
    {
		//if (Input.GetKeyDown(KeyCode.UpArrow))//��������
  //      {
            
  //      }

    }
}

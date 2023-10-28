using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbsorbCircle : MonoBehaviour
{
    [Header("������ʱ��")]
    public float existTime;
    //[Header("�Ѿ�����ʱ��")]
    private float existTimer = 0f;
    private void Update()
    {
        if(existTimer < existTime)
        {
            existTimer += Time.deltaTime;
        }
        else
        {
            existTimer = 0f;
            gameObject.SetActive(false);
        }    
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("EBullet"))
        {
            Element.TYPE type = collision.GetComponent<Bullet>().bulletElement.type;
            if (!PlayerManager.instance.currentPlayer.AbsorbElement(type))
                return;
            Destroy(collision.gameObject);
        }
    }
}

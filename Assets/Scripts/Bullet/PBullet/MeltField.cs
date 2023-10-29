using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeltField : MonoBehaviour
{
    [Header("��ը�뾶")]
    //public float fieldRadius = 3f;
    [Header("��ը�������ʱ��")]
    public float fieldExistTime = 1.2f;
    //[Header("��ը����ʱ��")]
    private float fieldExistTimer = 0f;
    [Header("��ը�˺�")]
    public int fieldDamage = 6;

    private void Update()
    {
        //transform.localScale = new Vector3(fieldRadius, fieldRadius, 1);
        if (!gameObject.activeSelf)
            return;
        if (fieldExistTimer < fieldExistTime)
        {
            fieldExistTimer += Time.deltaTime;
        }
        else
        {
            gameObject.SetActive(false);
            fieldExistTimer = 0f;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            //Debug.Log("WindField OnTriggerEnter2D");
            collision.gameObject.GetComponent<Character>().MDanage(fieldDamage);
        }

        if (collision.CompareTag("Block"))
        {
            collision.GetComponent<Block>().MDamage(1);
        }
    }
}

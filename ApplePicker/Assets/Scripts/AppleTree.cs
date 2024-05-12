using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AppleTree : MonoBehaviour
{
    [Header("Set in Inspector")]
    public GameObject applePrefab; //Шаблон для яблука
    public float speed = 1f; //Швидкість переміщення для ялуні
    public float leftAnfRightEdge = 10f; //Ліва і права мережа екрану
    public float chanceToChangeDirections = 0.1f; //Імовірність зміни напряку руху
    public float secondsBetweenAppleDrops = 1f; //частока скидання яблук
    // Start is called before the first frame update
    void Start()
    {
        Invoke("DropApple", 2f);
    }

    void DropApple()
    {
        GameObject apple = Instantiate<GameObject>(applePrefab);
        apple.transform.position = transform.position;
        Invoke("DropApple", secondsBetweenAppleDrops);
    }

    // Update is called once per frame
    void Update()
    {
        //Отримуємо поточну позицію
        Vector3 pos = transform.position;
        pos.x += speed * Time.deltaTime;
        transform.position = pos;

        if (pos.x < -leftAnfRightEdge)
        {
            speed = Mathf.Abs(speed);
        }
        else if(pos.x > leftAnfRightEdge) 
        { 
            speed = -Mathf.Abs(speed); 
        }
    }
    private void FixedUpdate()
    {
        if (Random.value < chanceToChangeDirections)
        {
            speed *= -1;
        }
    }
}

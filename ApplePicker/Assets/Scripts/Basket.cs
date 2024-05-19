using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Basket : MonoBehaviour
{
    [Header("Set Dynamically")]
    public Text scoreGT;

    private void Start()
    {
        GameObject gameObject = GameObject.Find("ScoreCounter");
        scoreGT = gameObject.GetComponent<Text>();
        scoreGT.text = "0";
    }
    // Update is called once per frame
    void Update()
    {
        //позиція мишки
        Vector3 mousePos2D = Input.mousePosition;
        //позиція камери по z
        mousePos2D.z = -Camera.main.transform.position.z;
        
        //приведення до координат, які є в ігрі
        Vector3 mousePos3D = Camera.main.ScreenToWorldPoint(mousePos2D);

        Vector3 pos = this.transform.position;
        pos.x = mousePos3D.x;
        this.transform.position = pos;  
    }

    private void OnCollisionEnter(Collision collision)
    {
        GameObject gameObject = collision.gameObject;
        if(gameObject.tag=="Apple")
        {
            Destroy(gameObject);

            int score = int.Parse(scoreGT.text);
            score += 100;
            scoreGT.text = score.ToString();

            if(score > HighScore.score)
                HighScore.score = score;
        }
    }
}

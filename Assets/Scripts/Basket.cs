using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Basket : MonoBehaviour
{   
    [Header("Set Dynamically")]
    public Text scoreGT;
    ApplePicker test;


    void Start() {
        // Find a reference to the ScoreCounter GameObject
        GameObject scoreGO = GameObject.Find("ScoreCounter");
        // Get the Text component of that GameObject
        scoreGT = scoreGO.GetComponent<Text>();
        // Set the starting number of points to 0
        scoreGT.text = "0";
    }

    // Update is called once per frame
    void Update()
    {
       Vector3 mousePos2D = Input.mousePosition;

       mousePos2D.z = -Camera.main.transform.position.z;

       Vector3 mousePos3D = Camera.main.ScreenToWorldPoint(mousePos2D);

       Vector3 pos = this.transform.position;
       pos.x = mousePos3D.x;
       this.transform.position = pos; 
    }

    void OnCollisionEnter(Collision coll) {
        GameObject collidedWith = coll.gameObject;
        
        if (collidedWith.tag == "Apple") {
            Destroy(coll.gameObject);

            int score = int.Parse(scoreGT.text);
            score += 100;
            scoreGT.text = score.ToString();

            if (score > HighScore.score) {
                HighScore.score = score;
            }
        }

        else if (collidedWith.tag == "BadApple") {
            test = FindObjectOfType<ApplePicker>();
            test.AppleDestroyed();
        }
    }
}

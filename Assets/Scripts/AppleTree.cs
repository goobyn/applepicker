using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AppleTree : MonoBehaviour
{
    [Header("Inscribed")]

    public GameObject applePrefab;
    public GameObject badApplePrefab;

    public enum Difficulty {Easy, Medium, Hard};
    public static Difficulty DifficultyLvl = Difficulty.Medium; // default diff.

    public float appleDropDelay;        // delay between apple drops
    public float speed;                 // speed of tree
    public float changeDirChance;       // chance tree will change directions
    public float badAppleChance;         // chance apple will be bad

    public float leftAndRightEdge = 20f; // distance where tree turns around
    public float startDelay = 1.0f;       // delay before apples start dropping
    

    public static void StartEasy() {
        DifficultyLvl = Difficulty.Easy;
        SceneManager.LoadScene("Easy_Scene");
    }

    public static void StartMedium() {
        DifficultyLvl = Difficulty.Medium;
        SceneManager.LoadScene("Medium_Scene");
    }

    public static void StartHard() {
        DifficultyLvl = Difficulty.Hard;
        SceneManager.LoadScene("Hard_Scene");
    }

    async void Start()
    {
        if (DifficultyLvl == Difficulty.Easy) {
            changeDirChance = .025f;
            speed = 8f;
            appleDropDelay = 1f;
            badAppleChance = 0f;
        }

        else if (DifficultyLvl == Difficulty.Medium) {
            changeDirChance = 0.035f;
            speed = 12f;
            appleDropDelay = 1f;
            badAppleChance = .20f;

            if (this.name == "AppleTree2") {
               startDelay = .50f;
            }  
        }

        else if (DifficultyLvl == Difficulty.Hard) {
            changeDirChance = .065f;
            speed = 14f;
            appleDropDelay = .75f;
            badAppleChance = .20f;

            if (this.name == "AppleTree2") {
               startDelay = .50f;
            }   

            if (this.name == "AppleTree3") {
               startDelay = .75f;
            }
        }

        InvokeRepeating("DropApple", startDelay, appleDropDelay);
    }

    void DropApple() {
        if (Random.value > badAppleChance) {
            GameObject apple = Instantiate(applePrefab) as GameObject;
            apple.transform.position = transform.position;
        }
        else {
            GameObject apple = Instantiate(badApplePrefab) as GameObject;
            apple.transform.position = transform.position;
        }
    }

    // Update is called once per frame
    void Update()
    {
        // basic movement
        Vector3 pos = transform.position;
        pos.x += speed * Time.deltaTime;
        transform.position = pos;


        if (pos.x < -leftAndRightEdge)
        {
            speed = Mathf.Abs(speed); // move right;
        }
        else if (pos.x > leftAndRightEdge)
        {
            speed = -Mathf.Abs(speed); // move left
        }
    }

void FixedUpdate() 
    {        
            if (Random.value < changeDirChance) {
                speed *= -1;
            }
        
    }

 void OnCollisionEnter(Collision coll) {
        GameObject collidedWith = coll.gameObject;
        if (collidedWith.tag == "AppleTree") {
            speed *= -1;
        }
 }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    public void StartEasyDifficulty() {
        AppleTree.StartEasy();
    }

    public void StartMediumDifficulty() {
        AppleTree.StartMedium();
    }

    public void StartHardDifficulty() {
        AppleTree.StartHard();
    }
}

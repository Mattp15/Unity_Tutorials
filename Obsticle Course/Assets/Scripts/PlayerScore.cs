using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScore : MonoBehaviour
{
    int score = 0;
    private void OnCollisionEnter(Collision other) {
        if(other.gameObject.tag != "Hit"){
        score++;

        }
        Debug.Log($"You've bummped into an object {score} times!");
    }
}

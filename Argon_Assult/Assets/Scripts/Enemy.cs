using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update


    // Update is called once per frame

        private void OnParticleCollision(GameObject other)
        {
            Destroy(gameObject);
        }
    
}

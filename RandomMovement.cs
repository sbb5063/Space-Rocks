using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
 

public class RandomMovement : MonoBehaviour
{
    public float minx;
    public float maxx;
    public float miny;
    public float maxy;
    float speed;
    Vector2 target;
    public float diff;
    public float minspeed;
    public float maxspeed;
    
    

    
    
    void Start()
    {
        target = GetRandom();
    }

  
    void Update()
    {
        if((Vector2)transform.position != target)
        {   speed = Mathf.Lerp(minspeed, maxspeed, diffper());
            transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);
        }
        else
        {
            target = GetRandom();
        }
    }

    Vector2 GetRandom()
    {
        float Randomx = Random.Range(minx, maxx);
        float Randomy = Random.Range(miny, maxy);
        return new Vector2(Randomx, Randomy);
    }

   

    float diffper()
    {
        return Mathf.Clamp01(Time.timeSinceLevelLoad / diff);
    }
}

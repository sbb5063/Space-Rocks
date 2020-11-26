using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragandDrop : MonoBehaviour
{
    bool moveallow;
    Collider2D coll;
    public GameObject selection;
    public GameObject death;
    private GameManager gm;
    private AudioSource src;
    void Start()
    {
        src = GetComponent<AudioSource>();
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameManager>();
        coll = GetComponent<Collider2D>();
    }

    void Update()
    {
        if(Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            Vector2 touchpos = Camera.main.ScreenToWorldPoint(touch.position);

            if(touch.phase == TouchPhase.Began)
            {
              Collider2D touchcoll = Physics2D.OverlapPoint(touchpos);
              if(coll == touchcoll)
              {
                src.Play();
                Instantiate(selection, transform.position, Quaternion.identity);
                moveallow = true;
              }
            }

            if(touch.phase == TouchPhase.Moved)
            {
                if(moveallow)
                {
                    transform.position = new Vector2(touchpos.x, touchpos.y);
                }
            }

            if(touch.phase == TouchPhase.Ended)
            {
                moveallow = false;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "rocks")
        {
            Instantiate(death, transform.position, Quaternion.identity);
            gm.GameOver();
        }
    }
}

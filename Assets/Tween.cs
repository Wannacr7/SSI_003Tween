//using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
enum easing
{

}

public class Tween : MonoBehaviour
{
   

    [Range(0, 1)]
    [SerializeField]
    float t = 0;

    [SerializeField] public AnimationCurve curve;

    [SerializeField]
    float duration = 1f;
    private bool isPlaying = false;
    float accumulatedTime = 0;

    [SerializeField]
    Transform target;

    Vector2 startPos;
    Vector2 endPos;

    const float c1 = 1.70158f;
    float c3 = c1 + 1;

    Renderer color;

    private void Start()
    {
       color = this.GetComponent<Renderer>();
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartTween();
        }
        if (!isPlaying)
        {
            return;
        }
        if (t >= 1)
        {
            Debug.Log("Completed");
            MoveFinalPlace();
            isPlaying = false;
            return;

        }
        t = accumulatedTime / duration;
        transform.position = Vector2.Lerp(startPos, endPos, curve.Evaluate(t));
        color.material.color = Color.Lerp(Color.white, Color.yellow, curve.Evaluate(t));
        
        
        accumulatedTime += Time.deltaTime;
    }

    private void StartTween()
    {
        startPos = transform.position;
        endPos = target.position;
        accumulatedTime = 0;
        t = 0;
        isPlaying = true;
    }

    private void MoveFinalPlace()
    {
        target.position = new Vector2(Random.Range(-4.5f, 4.5f), Random.Range(-4.5f, 4.5f)); 
        
    }
}

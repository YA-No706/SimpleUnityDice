using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dice : MonoBehaviour {

    [SerializeField, Header("許容値")]
    private float threshould = 0.1f;

    public int GetNumber()
    {
        float dot = Vector3.Dot(Vector3.up, transform.right);
        //ワールドのY軸と同じ向き
        float judge_plus = 1.0f - threshould;
        //ワールドのY軸と反対向き
        float judge_minus = -1.0f + threshould;

        if (dot >= judge_plus)
            return 5;
        if (dot <= judge_minus)
            return 2;

        dot = Vector3.Dot(Vector3.up, transform.up);

        if (dot >= judge_plus)
            return 6;
        if (dot <= judge_minus)
            return 1;

        dot = Vector3.Dot(Vector3.up, transform.forward);

        if (dot >= judge_plus)
            return 4;
        if (dot <= judge_minus)
            return 3;

        return -1;
    }

}

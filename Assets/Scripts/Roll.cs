using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Roll : MonoBehaviour
{
    [SerializeField, Header("レイの長さ")]
    private float rayLemgth = 2.0f;
    [SerializeField, Header("打ち上げる強さ")]
    private float power = 10.0f;
    [SerializeField, Header("地面に何秒接地していたらサイコロの目を表示するか")]
    private float standOnTheGroundSecond = 1.0f;
    [SerializeField, Header("出目を表示するテキスト")]
    private Text text_number;

    private Rigidbody body;
    private Dice dice;
    private int cur_Number;
    private int pre_Number;


    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody>();
        cur_Number = 0;
        pre_Number = 0;
        dice = GetComponent<Dice>();
    }

    // Update is called once per frame
    void Update()
    {
        //サイコロを転がす
        if (Input.GetKeyDown(KeyCode.Space))
        {
            transform.Rotate(Random.Range(0, 360), Random.Range(0, 360), Random.Range(0, 360));
            body.AddForce(Vector3.up * power, ForceMode.Impulse);
        }

        if (IsGround())
        {
            cur_Number = dice.GetNumber();

            if (cur_Number == pre_Number)
                return;
            text_number.text = cur_Number.ToString();
            pre_Number = cur_Number;
        }
    }

    private bool IsGround()
    {
#if UNITY_EDITOR
        Debug.DrawRay(transform.position, transform.up * rayLemgth, Color.red);
        Debug.DrawRay(transform.position, -transform.up * rayLemgth, Color.red);
        Debug.DrawRay(transform.position, transform.right * rayLemgth, Color.red);
        Debug.DrawRay(transform.position, -transform.right * rayLemgth, Color.red);
        Debug.DrawRay(transform.position, transform.forward * rayLemgth, Color.red);
        Debug.DrawRay(transform.position, -transform.forward * rayLemgth, Color.red);
#endif

        Ray ray_up = new Ray(transform.position, transform.up);
        RaycastHit hitInfo;
        if (Physics.Raycast(ray_up, out hitInfo, rayLemgth))
        {
            return true;
        }

        Ray ray_down = new Ray(transform.position, -transform.up);
        if (Physics.Raycast(ray_down, out hitInfo, rayLemgth))
        {
            return true;
        }

        Ray ray_right = new Ray(transform.position, transform.right);
        if (Physics.Raycast(ray_right, out hitInfo, rayLemgth))
        {
            return true;
        }

        Ray ray_left = new Ray(transform.position, -transform.right);
        if (Physics.Raycast(ray_left, out hitInfo, rayLemgth))
        {
            return true;
        }

        Ray ray_forward = new Ray(transform.position, transform.forward);
        if (Physics.Raycast(ray_forward, out hitInfo, rayLemgth))
        {
            return true;
        }

        Ray ray_back = new Ray(transform.position, -transform.forward);
        if (Physics.Raycast(ray_back, out hitInfo, rayLemgth))
        {
            return true;
        }

        return false;
    }

}

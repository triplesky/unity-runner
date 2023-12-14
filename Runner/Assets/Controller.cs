using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Controller : MonoBehaviour
{
    private Animator animator;
    public RuntimeAnimatorController animatorController; // 将Animator Controller拖拽到此处
    
    public SimpleTouchController leftController;
    public SimpleTouchController rightController;
    public Transform headTrans;
    public float speedMovements = 5f;
    public float speedContinuousLook = 100f;
    public float speedProgressiveLook = 3000f;

    
    void Awake()
    {
        
        rightController.TouchEvent += RightController_TouchEvent;
    }
    
    void RightController_TouchEvent (Vector2 value)
    {
        Debug.Log("lldebug "+value);
    }
    void Start()
    {
        animator = GetComponent<Animator>(); // 添加Animator组件
        animator.runtimeAnimatorController = animatorController; // 设置Animator Controller
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // 当按下空格键时，设置触发器以触发状态转换
            animator.Play("jumprun"); // Jump 是你在 Animator Controller 中设置的触发器名称
        }
        else if (Input.GetKeyDown(KeyCode.W))
        {
            animator.Play("walkforward");
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            animator.Play("runleft");
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            animator.Play("death");
        }
    }
}

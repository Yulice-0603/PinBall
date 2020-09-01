using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FripperControllerPhone : MonoBehaviour
{
    //HingeJointコンポーネントを入れる
    private HingeJoint myHingeJoint;

    //初期の傾き
    private float defaultAngle = 20;
    //弾いた時の傾き
    private float flickAngle = -20;

    // Start is called before the first frame update
    void Start()
    {
        //HingeJointコンポーネント取得
        this.myHingeJoint = GetComponent<HingeJoint>();

        //フリッパーの傾きを設定
        SetAngle(this.defaultAngle);
    }

    // Update is called once per frame
    void Update()
    {
        //マルチタッチ入力の判定
        if (Input.touchCount > 0)
        {
            //タップの情報を取得
            Touch[] myTouch = Input.touches;

            for (int i =0; i < Input.touchCount; i++)
            {
                //左側でタップした時時左フリッパーを動かす
                if (myTouch[i].position.x < 540 && tag == "LeftFripperTag" && myTouch[i].phase == TouchPhase.Began)
                {
                    SetAngle(this.flickAngle);
                }

                //右側でタップした時時左フリッパーを動かす
                if (myTouch[i].position.x > 540 && tag == "RightFripperTag" && myTouch[i].phase == TouchPhase.Began)
                {
                    SetAngle(this.flickAngle);
                }

                //離れた時フリッパーを元に戻す
                if (myTouch[i].position.x < 540 && tag == "LeftFripperTag" && myTouch[i].phase == TouchPhase.Ended)
                {
                    SetAngle(this.defaultAngle);
                }
                if (myTouch[i].position.x > 540 && tag == "RightFripperTag" && myTouch[i].phase == TouchPhase.Ended)
                {
                    SetAngle(this.defaultAngle);
                }
            }
        }              
    }

    //フリッパーの傾きを設定
    public void SetAngle(float angle)
    {
        JointSpring jointSpr = this.myHingeJoint.spring;
        jointSpr.targetPosition = angle;
        this.myHingeJoint.spring = jointSpr;
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FripperController : MonoBehaviour {

    // HingeJointコンポーネント
    private HingeJoint myHingeJoint;
    private float defaultAngle = 20;    // 初期の傾き
    private float flickAngle = -20;     // 弾いた時の傾き

    // Use this for initialization
    void Start () {
        // HingeJointコンポーネント取得
        this.myHingeJoint = GetComponent<HingeJoint>();

        // フリッパーの傾きを設定
        SetAngle(this.defaultAngle);
    }

    // タッチ用の配列を作る
    string[] aFingers = new string[10];


    // Update is called once per frame
    void Update () {

        // ********** スマートフォン用の処理 **********
        // 現在のタッチ数を取得する
        //Debug.LogFormat("タッチ数:{0}", Input.touchCount);

        // タッチ情報
        foreach (Touch t in Input.touches)
        {
            // タッチID取得
            var id = t.fingerId;

            // タッチの状態によって処理
            switch (t.phase)
            {
                // タッチされた
                case TouchPhase.Began:
                    // フリッパーのX座標
                    //Debug.Log("Screen Width : " + t.position.x);

                    // 左右のフリッパーを動かす
                    if (Screen.width / 2 > t.position.x && tag == "LeftFripperTag")
                    {
                        // 左フリッパーを動かす
                        SetAngle(this.flickAngle);
                        aFingers[id] = tag;
                    }
                    else if (Screen.width / 2 < t.position.x && tag == "RightFripperTag")
                    {
                        // 右フリッパーを動かす
                        SetAngle(this.flickAngle);
                        aFingers[id] = tag;
                    }
                    break;

                // タッチ中、動いているとき
                case TouchPhase.Moved:
                    break;

                // タッチ中、静止しているとき
                case TouchPhase.Stationary:
                    break;

                // 離した
                case TouchPhase.Ended:
                    // 左右のフリッパーを元に戻す
                    if (aFingers[id] == "LeftFripperTag" && tag == "LeftFripperTag")
                    {
                        // 左フリッパーを戻す
                        SetAngle(this.defaultAngle);
                        aFingers[id] = "";
                    }
                    else if (aFingers[id] == "RightFripperTag" && tag == "RightFripperTag")
                    {
                        // 右フリッパーを戻す
                        SetAngle(this.defaultAngle);
                        aFingers[id] = "";
                    }
                    break;

                // キャンセルされた
                case TouchPhase.Canceled:
                    break;

            }
        }

        // ********** PC用の処理 **********
        // 左矢印キーを押した時 左フリッパーを動かす
        if (Input.GetKeyDown(KeyCode.LeftArrow) && tag == "LeftFripperTag")
        {
            SetAngle(this.flickAngle);
        }

        // 右矢印キーを押した時 右フリッパーを動かす
        if (Input.GetKeyDown(KeyCode.RightArrow) && tag == "RightFripperTag")
        {
            SetAngle(this.flickAngle);
        }

        // 左矢印キーを離した時 左フリッパーを元に戻す
        if (Input.GetKeyUp(KeyCode.LeftArrow) && tag == "LeftFripperTag")
        {
            SetAngle(this.defaultAngle);
        }

        // 右矢印キーを離した時 右フリッパーを元に戻す
        if (Input.GetKeyUp(KeyCode.RightArrow) && tag == "RightFripperTag")
        {
            SetAngle(this.defaultAngle);
        }

    }

    // フリッパーの傾きを設定
    public void SetAngle(float angle)
    {
        JointSpring jointSpr = this.myHingeJoint.spring;
        jointSpr.targetPosition = angle;
        this.myHingeJoint.spring = jointSpr;
    }


}

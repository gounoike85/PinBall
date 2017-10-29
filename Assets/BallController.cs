using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallController : MonoBehaviour {

    // ボールが見える可能性のあるz軸の最大値
    private float visiblePosZ = -6.5f;

    // ゲームオーバーを表示するテキスト
    private GameObject gameoverText;

    // ゲーム得点を表示するテキスト
    private GameObject gamepointText;

    // ゲーム得点
    private int gamePoint = 0;

    // Use this for initialization
    void Start () {
        // シーン内のGameOverTextオブジェクトを取得
        this.gameoverText = GameObject.Find("GameOverText");

        // シーン内のGamePointTextオブジェクトを取得
        this.gamepointText = GameObject.Find("GamePointText");

        // ゲーム得点の初期値
        this.gamepointText.GetComponent<Text>().text = gamePoint.ToString();
        //Debug.Log(gamePoint);
    }
	
	// Update is called once per frame
	void Update () {

		// ボールが画面外に出た場合
        if (this.transform.position.z < this.visiblePosZ)
        {
            // GameoverTextゲームオーバーを表示
            this.gameoverText.GetComponent<Text>().text = "Game Over";
        }
        //Debug.Log(gamePoint);
    }

    // 衝突判定
    void OnCollisionEnter(Collision collision)
    {
        // 各オブジェクトに衝突した際に点数を加点
        if (collision.gameObject.tag == "SmallStarTag")
        {
            // SmallStar
            gamePoint += 1;
            this.gamepointText.GetComponent<Text>().text = gamePoint.ToString();
        }
        else if (collision.gameObject.tag == "LargeStarTag")
        {
            // LargeStar
            gamePoint += 5;
            this.gamepointText.GetComponent<Text>().text = gamePoint.ToString();
        }
        else if (collision.gameObject.tag == "SmallCloudTag")
        {
            // SmallCloud
            gamePoint += 3;
            this.gamepointText.GetComponent<Text>().text = gamePoint.ToString();
        }
        else if (collision.gameObject.tag == "LargeCloudTag")
        {
            // LargeCloud
            gamePoint += 10;
            this.gamepointText.GetComponent<Text>().text = gamePoint.ToString();
        }
    }

}

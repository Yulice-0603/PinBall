using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointCounter : MonoBehaviour
{
    GameObject pointText;
    //pointを初期化
    private int point = 0;

    //各オブジェクトの得点
    int smallstarpoint = 10;
    int largestarpoint = 15;
    int smallcloudpoint = 20;
    int largecloudpoint = 40;
    // Start is called before the first frame update

    void Start()
    {
        //Pointオブジェクトの取得
        this.pointText = GameObject.Find("Point");
        //最初は0で表示
        this.pointText.GetComponent<Text>().text = point.ToString("D5");
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter(Collision other)
    {

        //ポイントの累積
        if (other.gameObject.tag == "SmallStarTag")
        {
            this.point += this.smallstarpoint;
        }
        else if (other.gameObject.tag == "LargeStarTag")
        {
            this.point += this.largestarpoint;
        }
        else if (other.gameObject.tag == "SmallCloudTag")
        {
            this.point += this.smallcloudpoint;
        }
        else if (other.gameObject.tag == "LargeCloudTag")
        {
            this.point += this.largecloudpoint;
        }

        //累積したポイントの表示
        this.pointText.GetComponent<Text>().text = point.ToString("D5");
    }

}

using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using TMPro;

public class points : MonoBehaviour
{
    public TMP_Text txt;
    public int pointst = 0;
    public string score = "Score: ";
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        pointst = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void addpoints(int point)
    {
        pointst += point;
        this.GetComponent<TMP_Text>().text = score + pointst.ToString();
    }
}

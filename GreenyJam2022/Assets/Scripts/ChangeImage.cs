using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeImage : MonoBehaviour
{
    public Image firstImage;
    public Image nextImage2_1;
    public Sprite nextImage2;
    public Image nextImage3_1;
    public Sprite nextImage3;
    public Image nextImage4_1;
    public Sprite nextImage4;
    public Image nextImage5_1;
    public Sprite nextImage5;
    public Image nextImage6_1;
    public Sprite nextImage6;
    public Image nextImage7_1;
    public Sprite nextImage7;
    public Image nextImage8_1;
    public Sprite nextImage8;
    public Image nextImage9_1;
    public Sprite nextImage9;
    public Image nextImage10_1;
    public Sprite nextImage10;
    public Image nextImage11_1;
    public Sprite nextImage11;
    public Image nextImage12_1;
    public Sprite nextImage12;
    public Image nextImage13_1;
    public Sprite nextImage13;
    public Image nextImage14_1;
    public Sprite nextImage14;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void NewImage()
    {
        firstImage.sprite = nextImage2;
        nextImage2_1.sprite = nextImage3;


    }
}


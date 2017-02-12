using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIBackround : MonoBehaviour {

    public UISprite kSpriteChick = null;
    public Animation kAnimation = null;

    public void ChangeFrame1()
    {
        if (kSpriteChick != null) kSpriteChick.spriteName = "title_pi01";
    }
    public void ChangeFrame2()
    {
        if (kSpriteChick != null) kSpriteChick.spriteName = "title_pi02";
    }

    public void PlayAnimation()
    {
        if (kAnimation != null)
        {
            kAnimation.Stop();
            kAnimation.Play("ChickTitle");
        }   
    }
}

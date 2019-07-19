using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;
public class admob : MonoBehaviour
{
    BannerView banner;
    InterstitialAd fullAdmob;

    public string idFull;
    public string bannerId;

    public bool ad_Enable;

    public int ad_rand;

    void Awake()
    {
        DontDestroyOnLoad(this);

        if (FindObjectsOfType(GetType()).Length > 1)
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        ad_rand = Random.Range(1, 5);

        if (ad_Enable)
        {
            RequestBanner();
            ShowBanner();
            RequestFull();
        }
        else
        {
            remAdBut();
        }
    }

    public void remAdBut()
    {
        if (!ad_Enable)
        {
            GameObject.FindGameObjectWithTag("adBut").SetActive(false);
        }
    }

    void RequestBanner()
    {
        if (ad_Enable)
        {
            banner = new BannerView(bannerId, AdSize.Banner, AdPosition.Top);
            AdRequest adRequest = new AdRequest.Builder().Build();
            banner.LoadAd(adRequest);
        }
    }
    public void ShowBanner()
    {
        if (ad_Enable)
        {
            banner.Show();
        }

    }
    public void RequestFull()
    {
        if (ad_Enable)
        {
            fullAdmob = new InterstitialAd(idFull);
            AdRequest adRequest = new AdRequest.Builder().Build();
            fullAdmob.LoadAd(adRequest);
        }
    }
   
    public void ShowFullAds()
    {
        if (ad_Enable)
        {
            if (fullAdmob.IsLoaded())
            {
                fullAdmob.Show();
                RequestFull();

            }
            else
            {
                RequestFull();
            }
        }
    }

}
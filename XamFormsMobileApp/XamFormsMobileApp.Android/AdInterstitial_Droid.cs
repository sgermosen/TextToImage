using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Gms.Ads;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Xamarin.Forms;
using XamFormsMobileApp.Droid;
using XamFormsMobileApp.Interface;

[assembly: Dependency(typeof(AdInterstitial_Droid))]
namespace XamFormsMobileApp.Droid
{
    public class AdInterstitial_Droid : IAdInterstitial
    {
        InterstitialAd interstitialAd;

        public AdInterstitial_Droid()
        {
            interstitialAd = new InterstitialAd(Android.App.Application.Context);
            interstitialAd.RewardedVideoAdOpened += (s, e) => {
                NotesListPage.ShouldShowAdd = false;
            };
            // TODO: change this id to your admob id  
            interstitialAd.AdUnitId = Ads.AdConstant.InterstitialUnitId ;
          //  LoadAd();
        }

        void LoadAd()
        {
            var requestbuilder = new AdRequest.Builder();
            interstitialAd.LoadAd(requestbuilder.Build());
        }

        public void ShowAd()
        {
            if (interstitialAd.IsLoaded)
                interstitialAd.Show();

            LoadAd();
        }
    }
}
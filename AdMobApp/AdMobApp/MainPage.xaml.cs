using MarcTron.Plugin;
using MarcTron.Plugin.Controls;
using MarcTron.Plugin.CustomEventArgs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AdMobApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            //AdsControl();
            CrossMTAdmob.Current.OnInterstitialLoaded += (s, args) => {
                CrossMTAdmob.Current.ShowInterstitial();
            };
            CrossMTAdmob.Current.OnRewardedVideoAdLoaded += (s, args) => {
                CrossMTAdmob.Current.ShowRewardedVideo();
            };

            CrossMTAdmob.Current.OnRewardedVideoAdClosed += Current_OnRewardedVideoAdClosed;
            CrossMTAdmob.Current.OnRewardedVideoAdFailedToLoad += Current_OnRewardedVideoAdFailedToLoad;
        }

        private void Current_OnRewardedVideoAdFailedToLoad(object sender, MTEventArgs e)
        {
            lbl.Text = "Lütren daha sonra tekrar deneyiniz.";
        }

        private void Current_OnRewardedVideoAdClosed(object sender, EventArgs e)
        {
            lbl.Text = "Video kapatıldı ödülü ver.";
        }

        private void Interstitial_Clicked(object sender, EventArgs e)
        {
            CrossMTAdmob.Current.LoadInterstitial("ca-app-pub-3940256099942544/1033173712");
        }
        private void Rewarded_Clicked(object sender, EventArgs e)
        {
            CrossMTAdmob.Current.LoadRewardedVideo("ca-app-pub-3940256099942544/5224354917");
        }
    }
}

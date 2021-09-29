using UnityEngine;
using GoogleMobileAds.Api;
using System;


public class AdmobBottom : MonoBehaviour
{
	private BannerView adBanner;

	private string idApp, idBanner;


	void Start ()
	{
		idApp = "ca-app-pub-7445424998472406~9081823450";
		idBanner = "ca-app-pub-7445424998472406/7491563709";
		MobileAds.Initialize(idApp);
		RequestBannerAd ();
	}



	#region Banner Methods --------------------------------------------------

	public void RequestBannerAd ()
	{
		adBanner = new BannerView (idBanner, AdSize.SmartBanner, AdPosition.Bottom);
		AdRequest request = AdRequestBuild ();
		adBanner.LoadAd (request);
	}

	public void DestroyBannerAd ()
	{
		if (adBanner != null)
			adBanner.Destroy ();
	}

	#endregion

	
	//------------------------------------------------------------------------
	AdRequest AdRequestBuild ()
	{
		return new AdRequest.Builder ().Build ();
	}

	void OnDestroy ()
	{
		DestroyBannerAd ();
	}

}

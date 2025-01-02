using TMPro;
using Zenject;
using UnityEngine;
using UnityEngine.UI;
using Source.StateMachine;
using Cysharp.Threading.Tasks;

namespace Helpers.StateMachine
{
public class SplashScreen : MonoBehaviour, ISplashScreen<SplashScreenInfo>
{
#region Fields

    [SerializeField] RectTransform _loadingScreen;

    [Header("Info")]
    [SerializeField] TextMeshProUGUI _txtMapName;
    [SerializeField] TextMeshProUGUI _txtModeName;
    [SerializeField] Slider _sliderProgress;

    IServiceLoadingProgress _serviceLoadingProgress;
    IServiceSplashScreen _serviceSplashScreen;

#endregion

    [Inject]
    public void Construct(IServiceSplashScreen serviceSplashScreen, IServiceLoadingProgress serviceLoadingProgress)
    {
        _serviceLoadingProgress = serviceLoadingProgress;
        _serviceSplashScreen = serviceSplashScreen;
    }

    public void Init()
    {
        _serviceSplashScreen.RegisterSplashScreen(this);
    }

    public async UniTask ShowPanel(SplashScreenInfo config) { }

    public async UniTask HidePanel() { }
}
}
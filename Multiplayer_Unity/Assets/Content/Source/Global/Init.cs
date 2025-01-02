using Helpers;
using Zenject;
using System.Linq;
using UnityEngine;
using Source.Audio;
using Source.StateMachine;
using Helpers.StateMachine;
using Cysharp.Threading.Tasks;
using System.Collections.Generic;

namespace Source.Global
{
public class Init : MonoBehaviour
{
#region Fields
    
    [Header("Debugs")]
    [SerializeField]bool _enableDebug;
    [SerializeField] GameObject _graphyObj;
    [SerializeField] GameObject _debugConsole;
    
    [Header("Cameras")]
    [SerializeField] Camera _mainCamera;
    [SerializeField] Transform _singletonsParent;
    
    IAudioService _audioService;
    IServiceSceneLoader _serviceSceneLoader;
    IServiceSplashScreen _serviceSplashScreen;
    IServiceLoadingProgress _serviceLoadingProgress;
    IServiceCamera _serviceCamera;

#endregion

#region Monobeh

    [Inject]
    public void Construct(IServiceSceneLoader serviceSceneLoader, IServiceSplashScreen serviceSplashScreen,
                          IServiceLoadingProgress serviceLoadingProgress, IServiceCamera serviceCamera,
                          IAudioService audioService)
    {
        _audioService = audioService;
        _serviceSceneLoader = serviceSceneLoader;
        _serviceSplashScreen = serviceSplashScreen;
        _serviceLoadingProgress = serviceLoadingProgress;
        _serviceCamera = serviceCamera;
    }

    async void Awake()
    {
        _serviceCamera.RegisterMainCamera(_mainCamera);

        await SetSingletons();
        
        SetDebugViews();
        SetStateMachine();
    }

#endregion

#region Private methods

    void SetDebugViews()
    {
        if (!_enableDebug) return;

        Instantiate(_graphyObj);
        Instantiate(_debugConsole);
    }
    
    async UniTask SetSingletons()
    {
        var singletons = new List<ISingleton>();
        foreach (Transform child in _singletonsParent.transform)
        {
            if (child.TryGetComponent<ISingleton>(out var singleton))
                singletons.Add(singleton);
        }

        await UniTask.WaitUntil(() => singletons.All(singleton => singleton.IsSet));
    }

    void SetStateMachine()
    {
        var states = new IState[]
        {
            new InitState(),
            new MenuState()
        };

        var stateMachine = new StatesMachine(states);
        stateMachine.Enter<InitState>().GetAwaiter();
    }

#endregion
}
}
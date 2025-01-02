using Cysharp.Threading.Tasks;
using Helpers.StateMachine;

namespace Source.StateMachine
{
public class InitState: IStateEnter
{
    public StatesMachine StatesMachine { get; set; }
    public async UniTask Exit()
    { 
    }

    public async UniTaskVoid Enter()
    {
        
    }
}
}
using Helpers.StateMachine;
using Cysharp.Threading.Tasks;

namespace Source.StateMachine
{
public class MenuState: IStateEnter
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
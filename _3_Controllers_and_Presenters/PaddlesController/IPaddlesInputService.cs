using System;

namespace PaddlesController
{
    public interface IPaddlesInputService
    {
        event Action<int, PaddlesInputDirection> OnInput;
        void StartInputHandling();
        void StopInputHandling();
    }
}

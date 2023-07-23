using System;

namespace Utils.Wizards
{
    public interface IWizardStep
    {
        WizardStepProperties Properties { get; }

        /// <returns>Next step, returns <c>null</c> if there is no next step</returns>
        IWizardStep Next { get; }

        event EventHandler Completed;

        event EventHandler Stopped;

        event EventHandler<WizardStepFailedEventArgs> Failed;

        void Run();

        void Stop();
        event EventHandler RunStarted;
    }
}
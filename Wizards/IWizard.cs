using System;
using System.Collections.Generic;

namespace Utils.Wizards
{
    public interface IWizard
    {
        IWizardStep Step { get; }
        
        event EventHandler<WizardStepEventArgs> StepCompleted;

        event EventHandler<WizardStepFailedEventArgs> StepFailed;

        event EventHandler<WizardStepEventArgs> StepStopped;
        
        event EventHandler Completed;

        void Run();

        void Stop();

        void MoveNext();
        
        void Restart();

        IEnumerable<IWizardStep> GetSteps();
    }
}
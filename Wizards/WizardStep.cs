using System;

namespace Utils.Wizards
{
    public abstract class WizardStep : IWizardStep
    {
        public WizardStep(IWizardStep next = null)
        {
            Next = next;
        }

        public WizardStep(WizardStepProperties properties) : this()
        {
            Properties = properties ?? throw new ArgumentNullException(nameof(properties));
        }

        public WizardStep(WizardStepProperties properties, IWizardStep next) : this(next)
        {
            Properties = properties;
        }

        public WizardStepProperties Properties { get; protected set; }

        public IWizardStep Next { get; }

        public event EventHandler Completed;
        
        public event EventHandler RunStarted;
        
        public event EventHandler Stopped;

        public event EventHandler<WizardStepFailedEventArgs> Failed;
        
        public abstract void Run();
        
        public abstract void Stop();

        protected void InvokeCompleted()
        {
            Completed?.Invoke(this, EventArgs.Empty);
        }

        protected void InvokeFailed(string message)
        {
            Failed?.Invoke(this, new WizardStepFailedEventArgs(this, message));
        }
        
        protected void InvokeStopped()
        {
            Stopped?.Invoke(this, EventArgs.Empty);
        }
        
        protected void InvokeRunStarted()
        {
            RunStarted?.Invoke(this, EventArgs.Empty);
        }
    }
}
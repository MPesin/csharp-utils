namespace Utils.Wizards
{
    public class WizardStepFailedEventArgs : WizardStepEventArgs
    {
        public WizardStepFailedEventArgs(IWizardStep step, string message) : base(step)
        {
            Message = message;
        }

        public string Message { get; }
    }
}
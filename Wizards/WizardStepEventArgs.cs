using System;

namespace Utils.Wizards
{
    public class WizardStepEventArgs : EventArgs
    {
        public WizardStepEventArgs(IWizardStep step)
        {
            Step = step;
        }

        public IWizardStep Step { get; }
    }
}
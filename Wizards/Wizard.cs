using System;
using System.Collections.Generic;

namespace Utils.Wizards
{
    public class Wizard : IWizard
    {
        private readonly IWizardStep _rootStep;

        public Wizard(IWizardStep rootStep)
        {
            _rootStep = rootStep ?? throw new ArgumentNullException(nameof(rootStep));
            Step = _rootStep;
            Subscribe(Step);
        }

        public event EventHandler<WizardStepEventArgs> StepCompleted;

        public event EventHandler<WizardStepFailedEventArgs> StepFailed;

        public event EventHandler<WizardStepEventArgs> StepStopped;
        
        public event EventHandler Completed;

        public IWizardStep Step { get; private set; }

        public void Run() => Step?.Run();

        public void Stop() => Step?.Stop();

        public void MoveNext()
        {
            var next = Step.Next;
            if (next == null)
            {
                Completed?.Invoke(this, EventArgs.Empty);
            }
            else
            {
                UpdateStep(next);
            }
        }

        public void Restart()
        {
            UpdateStep(_rootStep);
        }

        private void UpdateStep(IWizardStep next)
        {
            Unsubscribe(Step);
            Subscribe(next);
            Step = next;
        }

        private void Subscribe(IWizardStep step)
        {
            step.Completed += OnStepCompleted;
            step.Failed += OnStepFailed;
            step.Stopped += OnStepStopped;
        }

        private void Unsubscribe(IWizardStep step)
        {
            step.Completed -= OnStepCompleted;
            step.Failed -= OnStepFailed;
            step.Stopped -= OnStepStopped;
        }

        private void OnStepCompleted(object sender, EventArgs e)
        {
            if (sender is not IWizardStep step)
                return;

            StepCompleted?.Invoke(this, new WizardStepEventArgs(step));
        }

        private void OnStepFailed(object sender, WizardStepFailedEventArgs e)
        {
            StepFailed?.Invoke(this, e);
        }

        private void OnStepStopped(object sender, EventArgs e)
        {
            if (sender is not IWizardStep step)
                return;
            
            StepStopped?.Invoke(this, new WizardStepEventArgs(step));
        }

        public IEnumerable<IWizardStep> GetSteps()
        {
            var steps = new List<IWizardStep>();
            var current = Step;
            do
            {
                steps.Add(current);
                current = current.Next;
            } while (current != null);

            return steps;
        }
    }
}
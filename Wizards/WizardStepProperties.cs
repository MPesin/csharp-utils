using System.Linq;

namespace Utils.Wizards
{
    public class WizardStepProperties
    {
        public int Id { get; set;}
        public string Title { get; set;}
        public object[] Arguments { get; set;}
        
        public T GetArgument<T>()
        {
            return (T) Arguments?.FirstOrDefault(arg => arg is T);
        }
    }
}
using Homework_11.Infrastructure.Commands.Base;
using System.Windows;

namespace Homework_11.Infrastructure.Commands
{
    internal class CloseApplicationCommand : BaseCommand
    {
        public override bool CanExecute(object parameter) => true;

        public override void Execute(object parameter) => Application.Current.Shutdown();
    }
}

using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextTempleter
{
    public class MainWindowViewModel : ViewModelBase
    {
        private string text;

        private DelegateCommand testCommand;

        public MainWindowViewModel()
        {

        }

        public string Text
        {
            get
            {
                return this.text;
            }

            set
            {
                if (this.text == value)
                {
                    return;
                }

                this.text = value;
                this.OnPropertyChanged(nameof(this.Text));
            }
        }

        public DelegateCommand TestCommand
        {
            get
            {
                if (testCommand == null)
                {
                    testCommand = new DelegateCommand(this.Execute, this.CanExecute);
                }

                return testCommand;
            }
        }

        private int count;

        private void Execute()
        {
            this.Text = "Hoge : " + count;
            ++count;
        }

        private bool CanExecute()
        {
            return true;
        }
    }
}

using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace TextTempleter
{
    public class MainWindowViewModel : ViewModelBase
    {

        private DelegateCommand createCommand;
        private DelegateCommand editCommand;
        private DelegateCommand deleteCommand;

        public MainWindowViewModel()
        {

        }

        //public string Text
        //{
        //    get
        //    {
        //        return this.text;
        //    }

        //    set
        //    {
        //        if (this.text == value)
        //        {
        //            return;
        //        }

        //        this.text = value;
        //        this.OnPropertyChanged(nameof(this.Text));
        //    }
        //}

        public DelegateCommand CreateCommand => this.createCommand ??= new DelegateCommand(this.ExecuteCreate, this.CanExecuteCreate);
        public DelegateCommand EditCommand => this.editCommand ??= new DelegateCommand(this.ExecuteEdit, this.CanExecuteEdit);
        public DelegateCommand DeleteCommand => this.deleteCommand ??= new DelegateCommand(this.ExecuteDelete, this.CanExecuteDelete);


        private bool CanExecuteCreate()
        {
            return true;
        }

        private void ExecuteCreate()
        {
        }


        private bool CanExecuteEdit()
        {
            return true;
        }

        private void ExecuteEdit()
        {
        }


        private bool CanExecuteDelete()
        {
            return true;
        }

        private void ExecuteDelete()
        {
        }
    }
}

using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        private TemplateItemViewModel selectedItem;

        public MainWindowViewModel()
        {
            this.TemplateList = new ObservableCollection<TemplateItemViewModel>();
            this.TemplateList.Add(new TemplateItemViewModel("さんぷる", "こめんと", "ないよう"));
        }

        public DelegateCommand CreateCommand => this.createCommand ??= new DelegateCommand(this.ExecuteCreate, this.CanExecuteCreate);
        public DelegateCommand EditCommand => this.editCommand ??= new DelegateCommand(this.ExecuteEdit, this.CanExecuteEdit);
        public DelegateCommand DeleteCommand => this.deleteCommand ??= new DelegateCommand(this.ExecuteDelete, this.CanExecuteDelete);

        public ObservableCollection<TemplateItemViewModel> TemplateList { get; set; }

        public TemplateItemViewModel SelectedItem
        {
            get => this.selectedItem;
            set
            {
                if (this.selectedItem == value)
                {
                    return;
                }

                this.selectedItem = value;
                this.OnPropertyChanged(nameof(this.SelectedItem));

                // コマンド更新
                this.EditCommand.RaiseCanExecuteChanged();
                this.DeleteCommand.RaiseCanExecuteChanged();
            }
        }

        private bool CanExecuteCreate()
        {
            return true;
        }

        private void ExecuteCreate()
        {
            this.TemplateList.Add(new TemplateItemViewModel("さんぷる", "こめんと", "ないよう"));
        }

        private bool CanExecuteEdit()
        {
            return this.SelectedItem != null;
        }

        private void ExecuteEdit()
        {
            this.SelectedItem.UpdateDate = DateTime.Now;
        }

        private bool CanExecuteDelete()
        {
            return this.SelectedItem != null;
        }

        private void ExecuteDelete()
        {

            var index = this.TemplateList.IndexOf(this.SelectedItem);
            this.TemplateList.Remove(this.SelectedItem);
            if (this.TemplateList.Count <= 0)
            {
               this.SelectedItem = null;
                return;
            }

            if (this.TemplateList.Count > index)
            {
                this.SelectedItem = this.TemplateList[index];
            }
            else
            {
                this.SelectedItem = this.TemplateList[index-1];
            }
        }
    }
}

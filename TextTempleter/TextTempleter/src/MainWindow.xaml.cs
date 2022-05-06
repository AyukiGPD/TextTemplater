using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TextTempleter
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// ダブルクリックイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TemplateList_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            // 編集の実行
            if (this.DataContext is MainWindowViewModel viewModel)
            {
                if (viewModel.EditCommand.CanExecute())
                {
                    viewModel.EditCommand.Execute();
                }
            } 
        }

        /// <summary>
        /// キーイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TemplateList_KeyDown(object sender, KeyEventArgs e)
        {
            if (!(this.DataContext is MainWindowViewModel viewModel))
            {
                return;
            }

            if (e.Key == Key.Insert)
            {
                // 作成
                if (viewModel.CreateCommand.CanExecute())
                {
                    viewModel.CreateCommand.Execute();
                    ForceForcusListView();
                }
            }
            else if (e.Key == Key.Enter)
            {
                // 編集
                if (viewModel.EditCommand.CanExecute())
                {
                    viewModel.EditCommand.Execute();
                    ForceForcusListView();
                }
            }
            else if (e.Key == Key.Delete)
            {
                // 削除
                if (viewModel.DeleteCommand.CanExecute())
                {
                    viewModel.DeleteCommand.Execute();
                    ForceForcusListView();
                }
            }
        }

        /// <summary>
        /// リストを強制的にフォーカスする
        /// </summary>
        private void ForceForcusListView()
        {
            var index = this.TemplateList.SelectedIndex;
            var dObj = this.TemplateList.ItemContainerGenerator.ContainerFromIndex(index);
            if (dObj is ListViewItem target)
            {
                target.Focus();
                this.TemplateList.SelectedItem = this.TemplateList.Items[index];
            }
        }
    }
}

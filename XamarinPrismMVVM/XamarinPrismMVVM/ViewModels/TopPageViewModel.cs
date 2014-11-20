#region License
//-----------------------------------------------------------------------
// <copyright>
//     Copyright matatabi-ux 2014.
// </copyright>
//-----------------------------------------------------------------------
#endregion

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Mvvm;
using System.Windows.Input;
using Microsoft.Practices.Unity;
using Xamarin.Forms;
using XamarinPrismMVVM.Models;

namespace XamarinPrismMVVM.ViewModels
{
    /// <summary>
    /// 最初の画面の ViewModel
    /// </summary>
    public class TopPageViewModel : BindableBase
    {
        #region Privates

        /// <summary>
        /// リポジトリ
        /// </summary>
        private PhotoRepository repository;

        #endregion //Privates

        #region Items プロパティ

        /// <summary>
        /// リストアイテム
        /// </summary>
        private IList<PhotoViewModel> items = new ObservableCollection<PhotoViewModel>();

        /// <summary>
        /// リストアイテム の取得と設定
        /// </summary>
        public IList<PhotoViewModel> Items
        {
            get { return this.items; }
            set { this.SetProperty<IList<PhotoViewModel>>(ref this.items, value); }
        }

        #endregion //Items プロパティ

        #region AddCommand

        /// <summary>
        /// 追加コマンド
        /// </summary>
        private ICommand addCommand;

        /// <summary>
        /// 追加コマンド の取得
        /// </summary>
        public ICommand AddCommand
        {
            get { return this.addCommand ?? (this.addCommand = new Command(this.Add, this.CanAdd)); }
        }

        /// <summary>
        /// アイテムの追加
        /// </summary>
        private void Add()
        {
            this.Items.Add(new PhotoViewModel(this.repository.Items[this.items.Count]));

            // Xamarin.Forms では Xamarin.Forms.Command の ChangeCanExecute しか反応してくれないらしい；
            ((Command)this.addCommand).ChangeCanExecute();
            ((Command)this.removeCommand).ChangeCanExecute();
        }

        /// <summary>
        /// アイテムの追加可能状態
        /// </summary>
        /// <returns>可能な場合<code>true</code>、それ以外は<code>false</code></returns>
        private bool CanAdd()
        {
            return this.items.Count < this.repository.Items.Count;
        }

        #endregion //AddCommand

        #region RemoveCommand

        /// <summary>
        /// 削除コマンド
        /// </summary>
        private ICommand removeCommand;

        /// <summary>
        /// 削除コマンド の取得
        /// </summary>
        public ICommand RemoveCommand
        {
            get { return this.removeCommand ?? (this.removeCommand = new Command(this.Remove, this.CanRemove)); }
        }

        /// <summary>
        /// アイテムの削除
        /// </summary>
        private void Remove()
        {
            this.Items.RemoveAt(this.items.Count - 1);

            // Xamarin.Forms では Xamarin.Forms.Command の ChangeCanExecute しか反応してくれないらしい；
            ((Command)this.addCommand).ChangeCanExecute();
            ((Command)this.removeCommand).ChangeCanExecute();
        }

        /// <summary>
        /// アイテムの追加可能状態
        /// </summary>
        /// <returns>可能な場合<code>true</code>、それ以外は<code>false</code></returns>
        private bool CanRemove()
        {
            return this.items.Count > 0;
        }

        #endregion //RemoveCommand

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="repository">リポジトリ（DI コンテナにより自動注入される）</param>
        [InjectionConstructor]
        public TopPageViewModel(PhotoRepository repository)
        {
            this.repository = repository;

            for (var i = 0; i < 3; i++)
            {
                this.Items.Add(new PhotoViewModel(this.repository.Items[i]));
            }
        }
    }
}
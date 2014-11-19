#region License
//-----------------------------------------------------------------------
// <copyright>
//     Copyright matatabi-ux 2014.
// </copyright>
//-----------------------------------------------------------------------
#endregion

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.Prism.Mvvm;
using Microsoft.Practices.Unity;
using Prism.Mvvm;
using Xamarin.Forms;
using XamarinPrismMVVM.Models;
using XamarinPrismMVVM.ViewModels;
using XamarinPrismMVVM.Views;

namespace XamarinPrismMVVM
{
    /// <summary>
    /// 共通 アプリケーションクラス
    /// </summary>
    public class App
    {
        /// <summary>
        /// アプリケーションクラス参照
        /// </summary>
        public static readonly App Current;

        /// <summary>
        /// アプリ内で管理するモジュールのコンテナ
        /// </summary>
        public static readonly UnityContainer Container = new UnityContainer();

        /// <summary>
        /// コンストラクタ
        /// </summary>
        static App()
        {
            Current = new App();
        }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        private App()
            : base()
        {
            // Prism.Mvvm.Xamarin アセンブリを読み込み可能にするおまじない
            var autoWired = ViewModelLocator.AutoWireViewModelProperty.DefaultValue;

            // Model を DI コンテナに登録
            Container.RegisterType<PhotoRepository>(new ContainerControlledLifetimeManager());
        }

        /// <summary>
        /// アプリケーション起動処理
        /// </summary>
        public void OnLaunchApplication()
        {
            // ViewModel をインスタンス化するデフォルトメソッドを指定
            ViewModelLocationProvider.SetDefaultViewModelFactory((type) => Container.Resolve(type));

            var repository = Container.Resolve<PhotoRepository>();
            repository.Load();
        }

        /// <summary>
        /// メイン画面を取得
        /// </summary>
        /// <returns>メイン画面</returns>
        public static Page GetMainPage()
        {
            return new TopPage();
        }
    }
}

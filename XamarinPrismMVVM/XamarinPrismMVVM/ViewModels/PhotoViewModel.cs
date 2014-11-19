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
using System.Threading.Tasks;
using Microsoft.Practices.Prism.Mvvm;
using Xamarin.Forms;
using XamarinPrismMVVM.Models;

namespace XamarinPrismMVVM.ViewModels
{
    /// <summary>
    /// 写真アイテム
    /// </summary>
    public class PhotoViewModel : BindableBase
    {
        /// <summary>
        /// タイトル
        /// </summary>
        public string Title { get; private set; }

        /// <summary>
        /// 画像パス
        /// </summary>
        public ImageSource ImageSource { get; private set; }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="item">写真アイテム</param>
        public PhotoViewModel(PhotoItem item)
        {
            this.Title = item.Title;
            this.ImageSource = ImageSource.FromResource(item.ImageUri);
        }
    }
}

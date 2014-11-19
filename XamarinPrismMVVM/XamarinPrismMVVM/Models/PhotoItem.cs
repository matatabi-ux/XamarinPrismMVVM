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

namespace XamarinPrismMVVM.Models
{
    /// <summary>
    /// 写真アイテム
    /// </summary>
    public class PhotoItem
    {
        /// <summary>
        /// タイトル
        /// </summary>
        public string Title { get; private set; }

        /// <summary>
        /// 画像パス
        /// </summary>
        public string ImageUri { get; private set; }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="title">タイトル</param>
        /// <param name="imageUri">画像パス</param>
        public PhotoItem(string title, string imageUri)
        {
            this.Title = title;
            this.ImageUri = imageUri;
        }
    }
}

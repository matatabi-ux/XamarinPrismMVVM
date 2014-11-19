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
    /// 写真リポジトリ
    /// </summary>
    public class PhotoRepository
    {
        /// <summary>
        /// 写真アイテム
        /// </summary>
        public IList<PhotoItem> Items { get; private set; }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public PhotoRepository()
        {
        }

        /// <summary>
        /// データ読み込み
        /// </summary>
        public void Load()
        {
            this.Items = new List<PhotoItem>()
            {
                new PhotoItem("アビシニアン", @"XamarinPrismMVVM.Assets.cat01.png"), 
                new PhotoItem("アメリカンカール", @"XamarinPrismMVVM.Assets.cat02.png"), 
                new PhotoItem("アメリカンショートヘア", @"XamarinPrismMVVM.Assets.cat03.png"), 
                new PhotoItem("アメリカンボブテイル", @"XamarinPrismMVVM.Assets.cat04.png"), 
                new PhotoItem("アメリカンワイヤーヘア", @"XamarinPrismMVVM.Assets.cat05.png"), 
                new PhotoItem("エキゾチックショートヘア", @"XamarinPrismMVVM.Assets.cat06.png"), 
                new PhotoItem("エジプシャンマウ", @"XamarinPrismMVVM.Assets.cat07.png"), 
                new PhotoItem("オシキャット", @"XamarinPrismMVVM.Assets.cat08.png"), 
                new PhotoItem("オリエンタルショートヘア", @"XamarinPrismMVVM.Assets.cat09.png"), 
                new PhotoItem("サイベリアン", @"XamarinPrismMVVM.Assets.cat10.png"), 
                new PhotoItem("ジャパニーズボブテイル", @"XamarinPrismMVVM.Assets.cat11.png"), 
                new PhotoItem("シャム", @"XamarinPrismMVVM.Assets.cat12.png"), 
                new PhotoItem("ターキッシュアンゴラ", @"XamarinPrismMVVM.Assets.cat13.png"), 
                new PhotoItem("ノルウェージャンフォレストキャット", @"XamarinPrismMVVM.Assets.cat14.png"), 
                new PhotoItem("ペルシャ", @"XamarinPrismMVVM.Assets.cat15.png"), 
                new PhotoItem("メインクーン", @"XamarinPrismMVVM.Assets.cat16.png"), 
                new PhotoItem("ラグドール", @"XamarinPrismMVVM.Assets.cat17.png"), 
                new PhotoItem("マンチカン", @"XamarinPrismMVVM.Assets.cat18.png"), 
                new PhotoItem("ブリティッシュショートヘア", @"XamarinPrismMVVM.Assets.cat19.png"), 
                new PhotoItem("スコティッシュフォールド", @"XamarinPrismMVVM.Assets.cat20.png"), 
            };

            // 順番をシャッフルする
            var random = new Random(DateTime.Now.Millisecond);
            for (var i = 0; i < this.Items.Count; i++)
            {
                var swap = this.Items[random.Next(this.Items.Count)];
                this.Items.Remove(swap);
                this.Items.Insert(random.Next(this.Items.Count), swap);
            }
        }
    }
}

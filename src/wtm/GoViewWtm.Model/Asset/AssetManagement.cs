using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;

namespace GoViewWtm.Model.Asset
{
    /// <summary>
    /// 素材管理
    /// </summary>
    public class AssetManagement : TopBasePoco
    {
        public new int ID { get; set; }
        [Display(Name = "素材类型")]
        public AssetType AssetType { get; set; }
        [Required]
        [Display(Name = "素材类型")]
        public int AssetTypeId { get; set; }
        [Required]
        [Display(Name = "标题")]
        public string Title { get; set; }
        [Display(Name = "备注")]
        public string Remark { get; set; }
        [Required]
        [Display(Name = "图片")]      
        public Guid PhotoId { get; set; }
        [Display(Name = "照片")]
        public FileAttachment Photo { get; set; }



    }
}

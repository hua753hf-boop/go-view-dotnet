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
    /// 素材类型
    /// </summary>
    public class AssetType : TopBasePoco
    {
        public new int ID { get; set; }
        [Display(Name = "素材类型")]
        [Required]
        public string Name { get; set; }

    }
}

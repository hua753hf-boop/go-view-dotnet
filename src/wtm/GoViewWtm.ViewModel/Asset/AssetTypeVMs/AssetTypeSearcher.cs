using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using GoViewWtm.Model.Asset;


namespace GoViewWtm.ViewModel.Asset.AssetTypeVMs
{
    public partial class AssetTypeSearcher : BaseSearcher
    {
        [Display(Name = "素材类型")]
        public String Name { get; set; }

        protected override void InitVM()
        {
        }

    }
}

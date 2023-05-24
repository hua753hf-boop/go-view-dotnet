using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using GoViewWtm.Model.Asset;


namespace GoViewWtm.ViewModel.Asset.AssetManagementVMs
{
    public partial class AssetManagementSearcher : BaseSearcher
    {
        public List<ComboSelectListItem> AllAssetTypes { get; set; }
        [Display(Name = "素材类型")]
        public int? AssetTypeId { get; set; }
        [Display(Name = "标题")]
        public String Title { get; set; }

        protected override void InitVM()
        {
            AllAssetTypes = DC.Set<AssetType>().GetSelectListItems(Wtm, y => y.Name);
        }

    }
}

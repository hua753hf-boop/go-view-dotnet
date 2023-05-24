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
    public partial class AssetTypeBatchVM : BaseBatchVM<AssetType, AssetType_BatchEdit>
    {
        public AssetTypeBatchVM()
        {
            ListVM = new AssetTypeListVM();
            LinkedVM = new AssetType_BatchEdit();
        }

    }

	/// <summary>
    /// Class to define batch edit fields
    /// </summary>
    public class AssetType_BatchEdit : BaseVM
    {

        protected override void InitVM()
        {
        }

    }

}

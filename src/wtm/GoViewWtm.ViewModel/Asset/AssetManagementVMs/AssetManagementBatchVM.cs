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
    public partial class AssetManagementBatchVM : BaseBatchVM<AssetManagement, AssetManagement_BatchEdit>
    {
        public AssetManagementBatchVM()
        {
            ListVM = new AssetManagementListVM();
            LinkedVM = new AssetManagement_BatchEdit();
        }

    }

	/// <summary>
    /// Class to define batch edit fields
    /// </summary>
    public class AssetManagement_BatchEdit : BaseVM
    {

        protected override void InitVM()
        {
        }

    }

}

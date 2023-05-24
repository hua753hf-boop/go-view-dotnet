using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using GoViewWtm.Model.Asset;


namespace GoViewWtm.ViewModel.Asset.AssetManagementVMs
{
    public partial class AssetManagementVM : BaseCRUDVM<AssetManagement>
    {
        public List<ComboSelectListItem> AllAssetTypes { get; set; }

        public AssetManagementVM()
        {
            SetInclude(x => x.AssetType);
        }

        protected override void InitVM()
        {
            AllAssetTypes = DC.Set<AssetType>().GetSelectListItems(Wtm, y => y.Name);
        }

        public override void DoAdd()
        {           
            base.DoAdd();
        }

        public override void DoEdit(bool updateAllFields = false)
        {
            base.DoEdit(updateAllFields);
        }

        public override void DoDelete()
        {
            base.DoDelete();
        }
    }
}

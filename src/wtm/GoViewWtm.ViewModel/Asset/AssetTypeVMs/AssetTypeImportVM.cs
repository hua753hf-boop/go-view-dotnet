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
    public partial class AssetTypeTemplateVM : BaseTemplateVM
    {
        [Display(Name = "素材类型")]
        public ExcelPropety Name_Excel = ExcelPropety.CreateProperty<AssetType>(x => x.Name);

	    protected override void InitVM()
        {
        }

    }

    public class AssetTypeImportVM : BaseImportVM<AssetTypeTemplateVM, AssetType>
    {

    }

}

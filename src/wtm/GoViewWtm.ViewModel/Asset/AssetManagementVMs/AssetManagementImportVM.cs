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
    public partial class AssetManagementTemplateVM : BaseTemplateVM
    {
        [Display(Name = "素材类型")]
        public ExcelPropety AssetType_Excel = ExcelPropety.CreateProperty<AssetManagement>(x => x.AssetTypeId);
        [Display(Name = "标题")]
        public ExcelPropety Title_Excel = ExcelPropety.CreateProperty<AssetManagement>(x => x.Title);
        [Display(Name = "备注")]
        public ExcelPropety Remark_Excel = ExcelPropety.CreateProperty<AssetManagement>(x => x.Remark);

	    protected override void InitVM()
        {
            AssetType_Excel.DataType = ColumnDataType.ComboBox;
            AssetType_Excel.ListItems = DC.Set<AssetType>().GetSelectListItems(Wtm, y => y.Name);
        }

    }

    public class AssetManagementImportVM : BaseImportVM<AssetManagementTemplateVM, AssetManagement>
    {

    }

}

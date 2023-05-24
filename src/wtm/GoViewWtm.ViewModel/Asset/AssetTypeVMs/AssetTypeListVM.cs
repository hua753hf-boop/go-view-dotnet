using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using GoViewWtm.Model.Asset;


namespace GoViewWtm.ViewModel.Asset.AssetTypeVMs
{
    public partial class AssetTypeListVM : BasePagedListVM<AssetType_View, AssetTypeSearcher>
    {
        protected override List<GridAction> InitGridAction()
        {
            return new List<GridAction>
            {
                this.MakeStandardAction("AssetType", GridActionStandardTypesEnum.Create, Localizer["Sys.Create"],"Asset", dialogWidth: 800),
                this.MakeStandardAction("AssetType", GridActionStandardTypesEnum.Edit, Localizer["Sys.Edit"], "Asset", dialogWidth: 800),
                this.MakeStandardAction("AssetType", GridActionStandardTypesEnum.Delete, Localizer["Sys.Delete"], "Asset", dialogWidth: 800),
                this.MakeStandardAction("AssetType", GridActionStandardTypesEnum.Details, Localizer["Sys.Details"], "Asset", dialogWidth: 800),
                this.MakeStandardAction("AssetType", GridActionStandardTypesEnum.BatchEdit, Localizer["Sys.BatchEdit"], "Asset", dialogWidth: 800),
                this.MakeStandardAction("AssetType", GridActionStandardTypesEnum.BatchDelete, Localizer["Sys.BatchDelete"], "Asset", dialogWidth: 800),
                this.MakeStandardAction("AssetType", GridActionStandardTypesEnum.Import, Localizer["Sys.Import"], "Asset", dialogWidth: 800),
                this.MakeStandardAction("AssetType", GridActionStandardTypesEnum.ExportExcel, Localizer["Sys.Export"], "Asset"),
            };
        }


        protected override IEnumerable<IGridColumn<AssetType_View>> InitGridHeader()
        {
            return new List<GridColumn<AssetType_View>>{
                this.MakeGridHeader(x => x.Name),
                this.MakeGridHeaderAction(width: 200)
            };
        }

        public override IOrderedQueryable<AssetType_View> GetSearchQuery()
        {
            var query = DC.Set<AssetType>()
                .CheckContain(Searcher.Name, x=>x.Name)
                .Select(x => new AssetType_View
                {
				    ID = x.ID,
                    Name = x.Name,
                })
                .OrderBy(x => x.ID);
            return query;
        }

    }

    public class AssetType_View : AssetType{

    }
}

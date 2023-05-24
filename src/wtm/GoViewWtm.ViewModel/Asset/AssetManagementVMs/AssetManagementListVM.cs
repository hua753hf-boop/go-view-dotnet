using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using GoViewWtm.Model.Asset;


namespace GoViewWtm.ViewModel.Asset.AssetManagementVMs
{
    public partial class AssetManagementListVM : BasePagedListVM<AssetManagement_View, AssetManagementSearcher>
    {
        protected override List<GridAction> InitGridAction()
        {
            return new List<GridAction>
            {
                this.MakeStandardAction("AssetManagement", GridActionStandardTypesEnum.Create, Localizer["Sys.Create"],"Asset", dialogWidth: 800),
                this.MakeStandardAction("AssetManagement", GridActionStandardTypesEnum.Edit, Localizer["Sys.Edit"], "Asset", dialogWidth: 800),
                this.MakeStandardAction("AssetManagement", GridActionStandardTypesEnum.Delete, Localizer["Sys.Delete"], "Asset", dialogWidth: 800),
                this.MakeStandardAction("AssetManagement", GridActionStandardTypesEnum.Details, Localizer["Sys.Details"], "Asset", dialogWidth: 800),
                this.MakeStandardAction("AssetManagement", GridActionStandardTypesEnum.BatchEdit, Localizer["Sys.BatchEdit"], "Asset", dialogWidth: 800),
                this.MakeStandardAction("AssetManagement", GridActionStandardTypesEnum.BatchDelete, Localizer["Sys.BatchDelete"], "Asset", dialogWidth: 800),
                this.MakeStandardAction("AssetManagement", GridActionStandardTypesEnum.Import, Localizer["Sys.Import"], "Asset", dialogWidth: 800),
                this.MakeStandardAction("AssetManagement", GridActionStandardTypesEnum.ExportExcel, Localizer["Sys.Export"], "Asset"),
                this.MakeAction("AssetManagement","MakeUrl","链接地址","链接地址", GridActionParameterTypesEnum.SingleId,"Asset").SetShowInRow(true).SetHideOnToolBar(true),
            };
        }


        protected override IEnumerable<IGridColumn<AssetManagement_View>> InitGridHeader()
        {
            return new List<GridColumn<AssetManagement_View>>{
                this.MakeGridHeader(x => x.Name_view),
                this.MakeGridHeader(x => x.Title),               
                this.MakeGridHeader(x=> x.Photo_view,100).SetFormat((a,b)=>
                {
                    return  $"<img src='/api/_file/GetFile/{a.Photo_view} 'height='auto' width='100%'  />";

                }),
                this.MakeGridHeader(x => x.PhotoId).SetFormat(PhotoIdFormat),
                this.MakeGridHeader(x => x.Remark),
                this.MakeGridHeaderAction(width: 250)
            };
        }
        private List<ColumnFormatInfo> PhotoIdFormat(AssetManagement_View entity, object val)
        {
            return new List<ColumnFormatInfo>
            {
                ColumnFormatInfo.MakeDownloadButton(ButtonTypesEnum.Button,entity.PhotoId),
                ColumnFormatInfo.MakeViewButton(ButtonTypesEnum.Button,entity.PhotoId,640,480,buttonText:"放大"),
            };
        }


        public override IOrderedQueryable<AssetManagement_View> GetSearchQuery()
        {
            var query = DC.Set<AssetManagement>()
                .CheckEqual(Searcher.AssetTypeId, x=>x.AssetTypeId)
                .CheckContain(Searcher.Title, x=>x.Title)
                .Select(x => new AssetManagement_View
                {
				    ID = x.ID,
                    Name_view = x.AssetType.Name,
                    Title = x.Title,
                    Remark = x.Remark,
                    PhotoId = x.PhotoId,
                    Photo_view = x.PhotoId
                })
                .OrderBy(x => x.ID);
            return query;
        }

    }

    public class AssetManagement_View : AssetManagement{
        [Display(Name = "素材类型")]
        public String Name_view { get; set; }

        [Display(Name = "预览图")]
        public Guid Photo_view { get; set; }

      

    }
}

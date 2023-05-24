using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;

namespace GoViewWtm.ViewModel.Asset.StaticFileVMs
{

    public class StaticFileListVM : BasePagedListVM<StaticFile_View, StaticFileSearcher>
    {

        public List<string> Names { get; set; }

        public List<StaticFile_View> Data { get; set; }

        protected override List<GridAction> InitGridAction()
        {
            return new List<GridAction>
            {
               
                this.MakeAction("StaticFile","MakeUrl","看原图并复制链接","链接地址", GridActionParameterTypesEnum.SingleId,"Asset",whereStr:x=>x.PicPath).SetShowInRow(true).SetHideOnToolBar(true),
            };
        }

        protected override IEnumerable<IGridColumn<StaticFile_View>> InitGridHeader()
        {
            return new List<GridColumn<StaticFile_View>>{
                this.MakeGridHeader(x => x.Type),
                this.MakeGridHeader(x => x.Title),
                 this.MakeGridHeader(x=> x.ViewPath,100).SetTitle("缩略图").SetFormat((a,b)=>
                {

                    if (a.ViewPath.Contains(".svg"))
                    {
                        return

                        $"<object type='image/svg+xml' data='{a.ViewPath}' style='display:block;width:200px;height:200px' > " +
                           $"<param name='src' value='{a.ViewPath}' >" +
                        $"</object>";
                    }else
                    {
                        return  $"<img src='{a.ViewPath}' height='200' width='200' />";
                    }                  

                }),
                 this.MakeGridHeader(x => x.PicPath),
                this.MakeGridHeaderAction(width: 200)
            };
        }

        public override IOrderedQueryable<StaticFile_View> GetSearchQuery()
        {



            var query = Data
                .AsQueryable()
                .CheckContain(Searcher.Type, x => x.Type)
                .Select(x => new StaticFile_View
                {
                    ID = x.ID,
                    Title = x.Title,
                    Type = x.Type,
                    PicPath = x.PicPath,
                    ViewPath = x.PicPath
                })
                .OrderBy(x => x.ID);
            return query;
        }
    }

    public class StaticFile_View : TopBasePoco
    {
      
        [Display(Name = "类型")]
        public string Type { get; set; }

        [Display(Name = "文件名")]
        public string Title { get; set; }

        [Display(Name = "预览")]
        public string ViewPath { get; set; }

        [Display(Name = "地址")]
        public string PicPath { get; set; }





    }
}

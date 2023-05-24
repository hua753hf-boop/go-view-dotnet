
using GoViewWtm.ViewModel.Asset.AssetTypeVMs;
using GoViewWtm.ViewModel.Asset.StaticFileVMs;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using SixLabors.ImageSharp.Drawing;
using System.Collections.Generic;
using System.IO;
using System.Security.Policy;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using WalkingTec.Mvvm.Mvc;

namespace GoViewWtm.Areas.Asset.Controllers
{
    /// <summary>
    /// 静态文件管理
    /// </summary>
    [Area("Asset")]
    [ActionDescription("静态文件素材")]
    public class StaticFileController : BaseController
    {

        private readonly IWebHostEnvironment _hostingEnvironment;

        public StaticFileController(IWebHostEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }

        //public List<string> Names { get; set; } 

        public IActionResult Index()
        {
            var names = GetDirNames();
            List<TreeSelectListItem> Tree = new List<TreeSelectListItem>();
            foreach (var name in names)
            {
                TreeSelectListItem treeSelectListItem = new TreeSelectListItem
                {

                    Text = name,
                    Value = name
                };
                Tree.Add(treeSelectListItem);
            }

            ViewBag.Tree = Tree;

            var vm = Wtm.CreateVM<StaticFileListVM>();
            vm.Searcher.Type = names[0];
            return PartialView(vm);

            
        }

        [HttpPost]
        public string Search(StaticFileSearcher searcher)
        {
            
            var vm = Wtm.CreateVM<StaticFileListVM>(passInit: true);
            if (ModelState.IsValid)
            {
                string webRootPath = _hostingEnvironment.WebRootPath;
                var names = GetDirNames();
                List <StaticFile_View>  data = new();
                for (int i = 0; i < names.Count; i++)
                {
                    var dir = GetCustomPel() + $"\\" + names[i];
                    var files =  Directory.GetFiles(dir, "*.*", SearchOption.AllDirectories);
                    foreach (var item in files)
                    {
                        var name = item.Replace(dir + $"\\", "");

                        StaticFile_View staticFile_View = new StaticFile_View
                        {
                            //ID = item.Replace(webRootPath, ""),
                            ID= new System.Guid(),
                            Title = name,
                            PicPath = item.Replace(webRootPath, ""),
                            Type = names[i]
                        };

                        data.Add(staticFile_View);

                    }
                }
                vm.Data = data;
                vm.Searcher = searcher;
                return vm.GetJson(false);
            }
            else
            {
                return vm.GetError();
            }
        }

        public IActionResult MakeUrl(string PicPath)
        {

            var hostinfo = HttpContext.Request.Host;

            var url = $"http://" + hostinfo.Value + PicPath;

           ViewBag.url = url;


            return View();
        }


        /// <summary>
        /// 获取文件夹
        /// </summary>
        /// <returns></returns>
        private List<string> GetDirNames()
        {
            string customPel = GetCustomPel();
            var dirs = Directory.GetDirectories(customPel, "*", SearchOption.AllDirectories);
            List<string> names = new();
            foreach (var dir in dirs)
            {
                var name = dir.Replace(customPel + $"\\", "");
                names.Add(name);
            }

            return names;
        }



        private string GetCustomPel()
        {
            string webRootPath = _hostingEnvironment.WebRootPath;
            string customPel = webRootPath + $"\\customPel";
            return customPel;
        }

        

    }
}

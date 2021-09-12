using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using System.IO;

namespace ContactsUI.Helpers
{
    public static class RazorHelper
    {
        public static string RenderRazorViewToString(Controller controller, string viewName, object model = null)
        {
            controller.ViewData.Model = model;

            using (var sw = new StringWriter())
            {
                IViewEngine viewEngine = controller.HttpContext.RequestServices.GetService(typeof(ICompositeViewEngine)) as ICompositeViewEngine;
                ViewEngineResult engineResult = viewEngine.FindView(controller.ControllerContext, viewName, false);

                ViewContext viewContext = new ViewContext(
                    controller.ControllerContext,
                    engineResult.View,
                    controller.ViewData,
                    controller.TempData,
                    sw,
                    new HtmlHelperOptions());

                engineResult.View.RenderAsync(viewContext);
                return sw.GetStringBuilder().ToString();
            }
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MvcCoreGiris.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcCoreGiris.Components
{
    public enum TextColor { danger, info, warning, success, primary, secondary, light, dark };

    // https://docs.microsoft.com/en-us/aspnet/core/mvc/views/view-components?view=aspnetcore-3.1
    public class SansliKisiViewComponent : ViewComponent
    {
        private readonly OkulContext okulContext;

        public SansliKisiViewComponent(OkulContext okulContext)
        {
            this.okulContext = okulContext;
        }

        public async Task<IViewComponentResult> InvokeAsync(TextColor renk)
        {
            var adet = await okulContext.Kisiler.CountAsync();
            var index = new Random().Next(adet);
            var kisi = await okulContext.Kisiler.Skip(index).FirstOrDefaultAsync();

            ViewBag.renk = Enum.GetName(renk.GetType(), renk);

            return View(kisi);
        }
    }
}

﻿using Microsoft.AspNetCore.Mvc;

namespace AcodeX_Web_Sitesi.ViewComponent.StatisticAdminDashboard
{
    public class LastFiveEducator : Microsoft.AspNetCore.Mvc.ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
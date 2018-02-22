using XamarinStarter.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace XamarinStarter.Helpers
{
    class AppPagesHelper
    {
        public static Page GetPageFromAppPageEnum(AppPagesEnum page, object data)
        {
            switch (page)
            {
                default:
                    return new ContentPage
                    {
                        Content = new Label
                        {
                            Text = "Enum not implemented",
                            VerticalOptions = LayoutOptions.Center,
                            HorizontalOptions = LayoutOptions.Center
                        }
                    };
            }
        }
    }
}

﻿using Microsoft.JSInterop;
using System;
using System.Threading.Tasks;

namespace BlazorApp.Helpers
{
    public static class FileUtils
    {

        public static ValueTask<object> SaveAs(this IJSRuntime js, string filename, byte[] data)
      => js.InvokeAsync<object>(
          "saveAsFile",
          filename,
          Convert.ToBase64String(data));

    }
}

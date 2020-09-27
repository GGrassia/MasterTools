using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace DnD.Extensions
{
    public static class IJSRuntimeExtensions
    {
        public static void Alert(this IJSRuntime js, string message)
        {
            js.InvokeVoidAsync("alert", new object[] { message });
        }
        public static ValueTask<bool> Confirm(this IJSRuntime js, string message)
        {
            return js.InvokeAsync<bool>("confirm", new object[] { message });
        }
    }
}

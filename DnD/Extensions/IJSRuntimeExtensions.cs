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
        public static async Task Alert(this IJSRuntime js, string message)
        {
            await js.InvokeVoidAsync("alert", new object[] { message });
        }

        public static ValueTask<bool> Confirm(this IJSRuntime js, string message)
        {
            return js.InvokeAsync<bool>("confirm", new object[] { message });
        }
    }
}

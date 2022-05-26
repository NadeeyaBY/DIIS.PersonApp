using Microsoft.JSInterop;

namespace DIIS.PersonApp.Helpers
{
    public static class IJSRuntimeExtensionMethods
    {
        public static async ValueTask<bool> Confirm(this IJSRuntime JSRuntime, string Message)
        {
            return await JSRuntime.InvokeAsync<bool>("confirm", Message);
        }
        public static async ValueTask Log(this IJSRuntime JSRuntime, string Message)
        {
            await JSRuntime.InvokeVoidAsync("console.log", Message);
        }
        //    public static async ValueTask InitializeInactivityTimer<T>(this IJSRuntime JSRuntime,
        //DotNetObjectReference<T> dotNetObjectReference) where T : class
        //    {
        //        await JSRuntime.InvokeVoidAsync("initializeInactivityTimer", dotNetObjectReference);
        //    }
    }
}

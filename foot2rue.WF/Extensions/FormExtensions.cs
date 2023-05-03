namespace foot2rue.WF.Extensions
{
    internal static class FormExtensions
    {
        public static async Task Wait(this Form form, Func<Task> loadingFunction)
        {
            form.UseWaitCursor = true;
            await loadingFunction();
            form.UseWaitCursor = false;
        }
    }
}

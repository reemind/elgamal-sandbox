using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace ElgamalSandbox.Desktop.Extensions
{
    public static class DialogExtensions
    {
        public static async Task<TReturnValue?> RunDialog<TDialog, TReturnValue>(
            this IDialogService dialogService,
            string name,
            DialogParameters parameters)
            where TDialog : ComponentBase
        {
            ArgumentNullException.ThrowIfNull(name);

            var dialog = await dialogService.ShowAsync<TDialog>(
                name,
                parameters,
                new DialogOptions()
                {
                    MaxWidth = MaxWidth.Small,
                    FullWidth = true,
                    CloseButton = true,
                });

            return (await dialog.Result).Canceled
                ? default
                : await dialog.GetReturnValueAsync<TReturnValue>();
        }
    }
}

using System;

using Avalonia.Controls;
using Avalonia.Controls.Templates;

using Tabloid.MVVM.Core.ViewModels;

namespace Tabloid.Avalonia;

public class ViewLocator : IDataTemplate
{
    public Control? Build(object? data)
    {
        if (data is null)
        {
            return null;
        }

        var name = data.GetType().FullName?.Replace("ViewModel", "View", StringComparison.Ordinal);
        var type = Type.GetType(name ?? "");

        if (type is not null)
        {
            if (Activator.CreateInstance(type) is not Control control)
            {
                return null;
            }

            control.DataContext = data;
            return control;
        }

        return new TextBlock { Text = "Not Found: " + name };
    }

    public bool Match(object? data)
    {
        return data is ViewModelBase;
    }
}

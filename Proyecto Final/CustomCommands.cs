using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Proyecto_Final
{
    public static class CustomCommands
    {
        public static readonly RoutedUICommand Add = new RoutedUICommand(
            "Add", "Add",
            typeof(CustomCommands),
            new InputGestureCollection
            { new KeyGesture(Key.A, ModifierKeys.Control) }
        );

        public static readonly RoutedUICommand Delete = new RoutedUICommand(
            "Delete", "Delete",
            typeof(CustomCommands),
            new InputGestureCollection
            { new KeyGesture(Key.Delete) }
        );

        public static readonly RoutedUICommand Edit = new RoutedUICommand(
            "Edit", "Edit",
            typeof(CustomCommands),
            new InputGestureCollection
            { new KeyGesture(Key.F4, ModifierKeys.Alt) }
        );

        public static readonly RoutedUICommand Save = new RoutedUICommand(
            "Save", "Save",
            typeof(CustomCommands),
            new InputGestureCollection
            { new KeyGesture(Key.S, ModifierKeys.Control) }
        );

        public static readonly RoutedCommand AddDataBase = new RoutedUICommand(
            "AddDataBase", "AddDataBase",
            typeof(CustomCommands),
            null
        );

        public static readonly RoutedCommand LoadDataBase = new RoutedUICommand(
            "LoadDataBase", "LoadDataBase",
            typeof(CustomCommands),
            null
        );

        public static readonly RoutedCommand AddTerm = new RoutedUICommand(
            "AddTerm", "AddTerm",
            typeof(CustomCommands),
            null
        );

        public static readonly RoutedCommand DeleteTerm = new RoutedUICommand(
            "DeleteTerm", "DeleteTerm",
            typeof(CustomCommands),
            new InputGestureCollection
            { new KeyGesture(Key.S, ModifierKeys.Control)}
        );

        public static readonly RoutedCommand Exit = new RoutedUICommand(
            "Exit", "Exit",
            typeof(CustomCommands),
            new InputGestureCollection
            { new KeyGesture(Key.Escape) }
        );

        public static readonly RoutedCommand Help = new RoutedUICommand(
            "Help", "Help",
            typeof(CustomCommands),
            new InputGestureCollection
            { new KeyGesture(Key.H, ModifierKeys.Control) }
        );
    }
}

#pragma checksum "..\..\..\Windows\InstructionXAML.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "C5AB4E178B266871583BABFEFD7580D17112613C14D2DD3B3D6DBFB72D81F4E3"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using Employee;
using MaterialDesignThemes.Wpf;
using MaterialDesignThemes.Wpf.Converters;
using MaterialDesignThemes.Wpf.Transitions;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace Employee.Windows/Employee/Employee
{


    /// <summary>
    /// InstructionXAML
    /// </summary>
    public partial class InstructionXAML : System.Windows.Window, System.Windows.Markup.IComponentConnector
{


#line 32 "..\..\..\Windows\InstructionXAML.xaml"
    [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
    internal System.Windows.Controls.DataGrid dgInstruction;

#line default
#line hidden


#line 49 "..\..\..\Windows\InstructionXAML.xaml"
    [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
    internal System.Windows.Controls.DatePicker datePicker1;

#line default
#line hidden


#line 55 "..\..\..\Windows\InstructionXAML.xaml"
    [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
    internal System.Windows.Controls.ComboBox cbName;

#line default
#line hidden


#line 67 "..\..\..\Windows\InstructionXAML.xaml"
    [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
    internal System.Windows.Controls.ComboBox cbView;

#line default
#line hidden


#line 78 "..\..\..\Windows\InstructionXAML.xaml"
    [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
    internal System.Windows.Controls.TextBox txtNote;

#line default
#line hidden

    private bool _contentLoaded;

    /// <summary>
    /// InitializeComponent
    /// </summary>
    [System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
    public void InitializeComponent()
    {
        if (_contentLoaded)
        {
            return;
        }
        _contentLoaded = true;
        System.Uri resourceLocater = new System.Uri("/Employee;component/windows/instructionxaml.xaml", System.UriKind.Relative);

#line 1 "..\..\..\Windows\InstructionXAML.xaml"
        System.Windows.Application.LoadComponent(this, resourceLocater);

#line default
#line hidden
    }

    [System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
    [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
    [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
    [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
    void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target)
    {
        switch (connectionId)
        {
            case 1:

#line 15 "..\..\..\Windows\InstructionXAML.xaml"
                ((Employee.InstructionXAML)(target)).Loaded += new System.Windows.RoutedEventHandler(this.Window_Loaded);

#line default
#line hidden
                return;
            case 2:
                this.dgInstruction = ((System.Windows.Controls.DataGrid)(target));
                return;
            case 3:
                this.datePicker1 = ((System.Windows.Controls.DatePicker)(target));
                return;
            case 4:
                this.cbName = ((System.Windows.Controls.ComboBox)(target));
                return;
            case 5:
                this.cbView = ((System.Windows.Controls.ComboBox)(target));
                return;
            case 6:
                this.txtNote = ((System.Windows.Controls.TextBox)(target));
                return;
            case 7:

#line 91 "..\..\..\Windows\InstructionXAML.xaml"
                ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Close_Click);

#line default
#line hidden
                return;
            case 8:

#line 98 "..\..\..\Windows\InstructionXAML.xaml"
                ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Add_Click);

#line default
#line hidden
                return;
            case 9:

#line 106 "..\..\..\Windows\InstructionXAML.xaml"
                ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Delete_Click);

#line default
#line hidden
                return;
        }
        this._contentLoaded = true;
    }
}
}


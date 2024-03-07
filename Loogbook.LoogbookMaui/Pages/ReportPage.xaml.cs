using LogBook.LogbookCore.ViewModel;

namespace Loogbook.LoogbookMaui.Pages;

public partial class ReportPage : ContentPage
{
	public ReportPage(ReportViewModel viewModel)
	{
		InitializeComponent();
		this.BindingContext = viewModel;
	}
}
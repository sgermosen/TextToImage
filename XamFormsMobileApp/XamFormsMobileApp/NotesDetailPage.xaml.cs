using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamFormsMobileApp.Model;

namespace XamFormsMobileApp
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class NotesDetailPage : ContentPage
	{
        NotesDetailPageViewModel viewModel;
        public NotesDetailPage (NotesModel notesModel)
		{
			InitializeComponent ();

            BindingContext = viewModel=new NotesDetailPageViewModel();
            viewModel.Initilize(notesModel);

		}
	}
}
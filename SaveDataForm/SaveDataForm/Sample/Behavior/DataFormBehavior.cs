using Syncfusion.Maui.DataForm;
using System.ComponentModel;

namespace SaveDataForm
{
    public class DataFormBehavior : Behavior<ContentPage>
    {
        private SfDataForm dataForm;

        private Button cancelButton;

        private Button saveButton;
        protected override void OnAttachedTo(ContentPage bindable)
        {
            base.OnAttachedTo(bindable);
            this.dataForm = bindable.FindByName<SfDataForm>("dataForm");
            this.dataForm.ItemsSourceProvider = new ItemSourceProvider();
            if (this.dataForm != null)
            {
                this.dataForm.RegisterEditor("EventName", DataFormEditorType.ComboBox);
            }
            this.saveButton = bindable.FindByName<Button>("saveButton");
            this.cancelButton = bindable.FindByName<Button>("cancelButton");
            if (this.cancelButton != null)
            {
                this.cancelButton.Clicked += OnCancelButtonClicked;
            }
            if (this.saveButton != null)
            {
                this.saveButton.Clicked += OnSaveButtonClicked;
            }
        }
        private void OnCancelButtonClicked(object sender, EventArgs e)
        {
            if (this.dataForm != null)
            {
                this.dataForm.DataObject = new DataFormModel();
            }
        }
        private async void OnSaveButtonClicked(object sender, EventArgs e)
        {
            if (this.dataForm != null && App.Current.MainPage != null)
            {
                if (this.dataForm.Validate())
                {
                    this.dataForm.Commit();
                    await App.Current.MainPage.DisplayAlert("", "Feedback saved", "OK");
                }
                else
                {
                    await App.Current.MainPage.DisplayAlert("", "Please enter the required details", "OK");
                }
            }
        }
        protected override void OnDetachingFrom(ContentPage bindable)
        {
            base.OnDetachingFrom(bindable);
            if (this.dataForm != null)
            {
                this.cancelButton.Clicked -= this.OnCancelButtonClicked;
                this.saveButton.Clicked -= this.OnSaveButtonClicked;
                this.dataForm = null;
            }
        }
    }
}
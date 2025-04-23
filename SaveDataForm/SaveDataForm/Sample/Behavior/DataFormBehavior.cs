using Syncfusion.Maui.DataForm;
using System.ComponentModel;

namespace SaveDataForm
{
    public class DataFormBehavior : Behavior<ContentPage>
    {
        private SfDataForm? dataForm;

        private Button? cancelButton;

        private Button? saveButton;
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
        private void OnCancelButtonClicked(object? sender, EventArgs e)
        {
            if (this.dataForm != null)
            {
                this.dataForm.DataObject = new DataFormModel();
            }
        }
        private async void OnSaveButtonClicked(object? sender, EventArgs e)
        {
            if (this.dataForm != null)
            {
                if (this.dataForm.Validate())
                {
                    this.dataForm.Commit();
                    await DisplayAlert("", "Feedback saved", "OK");
                }
                else
                {
                    await DisplayAlert("", "Please enter the required details", "OK");
                }
            }
        }
        protected override void OnDetachingFrom(ContentPage bindable)
        {
            base.OnDetachingFrom(bindable);
            if (this.dataForm != null && this.cancelButton != null && this.saveButton != null)
            {
                this.cancelButton.Clicked -= this.OnCancelButtonClicked;
                this.saveButton.Clicked -= this.OnSaveButtonClicked;
                this.dataForm = null;
            }
        }

        /// <summary>
        /// Displays an alert dialog to the user.
        /// </summary>
        /// <param name="title">The title of the alert dialog.</param>
        /// <param name="message">The message to display.</param>
        /// <param name="cancel">The text for the cancel button.</param>
        /// <returns>A task representing the asynchronous alert display operation.</returns>
        private Task DisplayAlert(string title, string message, string cancel)
        {
            return App.Current?.Windows?[0]?.Page!.DisplayAlert(title, message, cancel)
                   ?? Task.FromResult(false);
        }
    }
}
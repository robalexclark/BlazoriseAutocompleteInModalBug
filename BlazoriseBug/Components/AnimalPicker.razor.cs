using Blazorise;
using Blazorise.Components;
using Blazorise.DataGrid;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazoriseBug.Components
{
    public partial class AnimalPicker
    {
        private Modal modal;

        private string title;

        private List<string> autoCompleteAnimalNos;

        private readonly List<AnimalSelection> selectedAnimalNos = new List<AnimalSelection>();


        public void ShowAnimalPicker()
        {
            selectedAnimalNos.Clear();

            title = "Picker";

            this.autoCompleteAnimalNos = new List<string>();

            for (int i = 0; i <= 500; i++)
            {
                autoCompleteAnimalNos.Add("AAA-"+i);
            }

            modal.Show();
        }


        private string autocompleteSelectedAnimalNo;

        private Autocomplete<string, string> animalNosAutoComplete;

        private void ValidateAnimalNo(ValidatorEventArgs e)
        {
            //If its empty (so not searching on it) or it matches and existing study then ok, else validation error
            if (!String.IsNullOrWhiteSpace(animalNosAutoComplete.SelectedText))
            {
                e.Status = (autoCompleteAnimalNos != null && autoCompleteAnimalNos.Any(x => x == e.Value?.ToString())) ? ValidationStatus.Success : ValidationStatus.Error;

                if (e.Status == ValidationStatus.Error)
                {
                    e.ErrorText = "Invalid Animal. Ensure that an animal is selected";
                }
                else
                {
                    e.ErrorText = null;
                }
            }
            else //not entered
            {
                e.Status = ValidationStatus.None;
            }
        }

        private void AddAnimal()
        {
            if (autocompleteSelectedAnimalNo != null)
            {
                selectedAnimalNos.Add(new AnimalSelection { AnimalNo = autocompleteSelectedAnimalNo });

                autocompleteSelectedAnimalNo = null;
            }
        }

        private void DeleteAnimalNo(CommandContext<AnimalSelection> commandContext)
        {
            AnimalSelection animalNo = commandContext.Item;

            selectedAnimalNos.Remove(animalNo);
        }

        //private void OnClosing(ModalClosingEventArgs e)
        //{
        //    if (e.CloseReason != CloseReason.UserClosing)
        //    {
        //        e.Cancel = true;
        //    }
        //}

        public string SelectedAnimalNosText
        {
            get
            {
                return String.Join(",", selectedAnimalNos.Select(x => x.AnimalNo));
            }
        }

        private void  CloseAnimalPicker()
        {
            modal.Hide();
        }
    }

    public class AnimalSelection
    {
        public string AnimalNo { get; set; }
    }
}